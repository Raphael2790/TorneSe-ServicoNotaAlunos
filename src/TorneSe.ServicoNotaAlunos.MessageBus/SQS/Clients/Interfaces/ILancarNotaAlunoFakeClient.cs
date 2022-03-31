using TorneSe.ServicoNotaAlunos.Domain.Messages;

namespace TorneSe.ServicoNotaAlunos.MessageBus.SQS.Clients;

public interface ILancarNotaAlunoFakeClient : IQueueClient<RegistrarNotaAluno>
{
    
}
