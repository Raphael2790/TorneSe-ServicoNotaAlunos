using TorneSe.ServicoNotaAlunos.Domain.Messages;
using TorneSe.ServicoNotaAlunos.Domain.Notification;
using TorneSe.ServicoNotaAlunos.MessageBus.Messages;
using TorneSe.ServicoNotaAlunos.MessageBus.SQS.Context.Interfaces;

namespace TorneSe.ServicoNotaAlunos.MessageBus.SQS.Clients;

public class LancarNotaAlunoFakeClient : SqsClient<RegistrarNotaAluno>,ILancarNotaAlunoFakeClient
{
    private readonly Queue<QueueMessage<RegistrarNotaAluno>> _filaNotasParaRegistrar;
    private readonly ContextoNotificacao _contextoNotificao;

    private const string NOME_FILA_CONFIGURACAO = "FilaConfiguracaoFake";
    public LancarNotaAlunoFakeClient(ISqsContext context,ContextoNotificacao contextoNotificao) :
            base(context,contextoNotificao,NOME_FILA_CONFIGURACAO)
    {
        _filaNotasParaRegistrar = NotasParaProcessar();
        _contextoNotificao = contextoNotificao;
    }

    public override async Task<QueueMessage<RegistrarNotaAluno>> GetMessageAsync()
    {
        QueueMessage<RegistrarNotaAluno> mensagem = null;
        
        try
        {
            mensagem = await Task.FromResult(_filaNotasParaRegistrar.FirstOrDefault());
        }
        catch(Exception ex)
        {
            _contextoNotificao.Add(ex.Message);
        }

        return mensagem;
    }

    private Queue<QueueMessage<RegistrarNotaAluno>> NotasParaProcessar()
    {
        var queue = new Queue<QueueMessage<RegistrarNotaAluno>>();
        queue.Enqueue(new()
        {
            MessageId = Guid.NewGuid().ToString(),
            MessageHandle = Guid.NewGuid().ToString(),
            ReceiveCount = 0,
            MessageBody = new RegistrarNotaAluno()
            {
                AlunoId = 1234,
                AtividadeId = 2,
                CorrelationId = Guid.NewGuid(),
                ProfessorId = 1282727,
                ValorNota = 8,
                NotaSubstitutiva = true
            }
        });
        return queue;
    }
}
