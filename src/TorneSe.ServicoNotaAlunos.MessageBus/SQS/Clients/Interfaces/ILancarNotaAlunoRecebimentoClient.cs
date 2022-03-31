using TorneSe.ServicoNotaAlunos.Domain.Messages;

namespace TorneSe.ServicoNotaAlunos.MessageBus.SQS.Clients.Interfaces;

public interface ILancarNotaAlunoRecebimentoClient : IQueueClient<RegistrarNotaAluno>{}
