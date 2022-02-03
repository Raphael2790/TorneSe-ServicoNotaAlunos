using TorneSe.ServicoNotaAlunos.Application.Interfaces;
using TorneSe.ServicoNotaAlunos.Domain.Notification;
using TorneSe.ServicoNotaAlunos.MessageBus.SQS.Clients;

namespace TorneSe.ServicoNotaAlunos.Worker;

public class ServicoNotaAlunoWorker : BackgroundService
{
    private readonly ILogger<ServicoNotaAlunoWorker> _logger;
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public ServicoNotaAlunoWorker(ILogger<ServicoNotaAlunoWorker> logger, 
                                  IServiceScopeFactory serviceScopeFactory)
    {
        _logger = logger;
        _serviceScopeFactory = serviceScopeFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Iniciando o serviço de notas");
            using var scope = _serviceScopeFactory.CreateScope();
            var servicoNotaAlunoApp = scope.ServiceProvider.GetRequiredService<IServicoAplicacaoNotaAluno>();
            var clienteMensagens = scope.ServiceProvider.GetRequiredService<ILancarNotaAlunoFakeClient>();
            var contextoNotificacao = scope.ServiceProvider.GetRequiredService<ContextoNotificacao>();

            var mensagem = await clienteMensagens.GetMessageAsync();

            if(contextoNotificacao.TemNotificacoes)
            {
                _logger.LogError(contextoNotificacao.ToJson());
                continue;
            }

            if(mensagem is null)
            {
                _logger.LogInformation("Não possuem mensagens a ser processadas na fila...");
                continue;
            }

            await servicoNotaAlunoApp.ProcessarLancamentoNota(mensagem.MessageBody);
        }
    } 
}
