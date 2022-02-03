using TorneSe.ServicoNotaAlunos.Domain.Messages;

namespace TorneSe.ServicoNotaAlunos.Domain.Interfaces.Services;

public interface IServicoNotaAluno
{
    Task LancarNota(RegistrarNotaAluno registrarNotaAluno);
}
