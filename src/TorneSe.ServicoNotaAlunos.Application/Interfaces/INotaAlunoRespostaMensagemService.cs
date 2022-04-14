using TorneSe.ServicoNotaAlunos.Domain.Messages;

namespace TorneSe.ServicoNotaAlunos.Application.Interfaces;

public interface INotaAlunoRespostaMensagemService
{
    Task EnviarMensagem(RegistrarNotaAluno notaRegistrada);
}
