using TorneSe.ServicoNotaAlunos.Domain.Messages;
using TorneSe.ServicoNotaAlunos.Domain.Notification;
using TorneSe.ServicoNotaAlunos.MessageBus.SQS.Clients.Interfaces;
using TorneSe.ServicoNotaAlunos.MessageBus.SQS.Context.Interfaces;

namespace TorneSe.ServicoNotaAlunos.MessageBus.SQS.Clients;

public class LancarNotaAlunoRespostaClient : SqsClient<NotaRegistradaAluno>, ILancarNotaAlunoRespostaClient
{
    private const string NOME_FILA_CONFIGURACAO = "FilaConfiguracaoResposta";
    public LancarNotaAlunoRespostaClient(ISqsContext context, 
                                        ContextoNotificacao contextoNotificacao) 
                                        : base(context, contextoNotificacao, NOME_FILA_CONFIGURACAO)
    {
    }
}
