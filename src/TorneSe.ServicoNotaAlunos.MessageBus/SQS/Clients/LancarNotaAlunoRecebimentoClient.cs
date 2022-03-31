using TorneSe.ServicoNotaAlunos.Domain.Messages;
using TorneSe.ServicoNotaAlunos.Domain.Notification;
using TorneSe.ServicoNotaAlunos.MessageBus.SQS.Clients.Interfaces;
using TorneSe.ServicoNotaAlunos.MessageBus.SQS.Context.Interfaces;

namespace TorneSe.ServicoNotaAlunos.MessageBus.SQS.Clients;

public class LancarNotaAlunoRecebimentoClient : SqsClient<RegistrarNotaAluno>, ILancarNotaAlunoRecebimentoClient
{
    private const string NOME_FILA_CONFIGURACAO = "FilaConfiguracaoRecebimento";
    public LancarNotaAlunoRecebimentoClient(ISqsContext context, 
                                            ContextoNotificacao contextoNotificacao) 
    : base(context, contextoNotificacao, NOME_FILA_CONFIGURACAO)
    {
    }
}
