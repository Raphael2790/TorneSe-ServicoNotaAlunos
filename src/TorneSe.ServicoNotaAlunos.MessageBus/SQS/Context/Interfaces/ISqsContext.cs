using Amazon.SQS;

namespace TorneSe.ServicoNotaAlunos.MessageBus.SQS.Context.Interfaces;

public interface ISqsContext
{
    AmazonSQSClient Sqs { get;}
    int SegundosTempoEspera { get; }
    string BuscarUrlFila(string nomeFila);
}
