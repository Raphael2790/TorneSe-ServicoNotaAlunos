using TorneSe.ServicoNotaAlunos.MessageBus.Messages;

namespace TorneSe.ServicoNotaAlunos.MessageBus.SQS.Clients;

public interface IQueueClient<T>
{
    Task SendMessageAsync(T message);
    Task SendMessageAsync(List<T> messageList);
    Task<QueueMessage<T>> GetMessageAsync();
    Task<List<QueueMessage<T>>> GetMessageAsync(int count);
    Task DeleteMessageAsync(string messageHandle);
}
