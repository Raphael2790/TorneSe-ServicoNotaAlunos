using TorneSe.ServicoNotaAlunos.Application.Interfaces;
using TorneSe.ServicoNotaAlunos.Domain.Messages;
using TorneSe.ServicoNotaAlunos.Domain.Notification;
using TorneSe.ServicoNotaAlunos.MessageBus.SQS.Clients.Interfaces;

namespace TorneSe.ServicoNotaAlunos.Application.Services;

public class NotaAlunoRespostaMensagemService : INotaAlunoRespostaMensagemService
{
    private readonly ILancarNotaAlunoRespostaClient _respostaClient;
    private readonly ContextoNotificacao _contextoNotificacao;

    public NotaAlunoRespostaMensagemService(ILancarNotaAlunoRespostaClient respostaClient,
                                            ContextoNotificacao contextoNotificacao)
    {
        _respostaClient = respostaClient;
        _contextoNotificacao = contextoNotificacao;
    }

    public async Task EnviarMensagem(RegistrarNotaAluno registrarNotaAluno)
    {
        await _respostaClient.SendMessageAsync(new NotaRegistradaAluno
                {
                    AlunoId = registrarNotaAluno.AlunoId,
                    AtividadeId = registrarNotaAluno.AtividadeId,
                    CorrelationId = registrarNotaAluno.CorrelationId,
                    PossuiErros = _contextoNotificacao.TemNotificacoes,
                    Erros = _contextoNotificacao.ToList()
                });
    }
}
