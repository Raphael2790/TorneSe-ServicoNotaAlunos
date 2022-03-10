using TorneSe.ServicoNotaAlunos.Domain.DomainObjects;
using TorneSe.ServicoNotaAlunos.Domain.Entidades;

namespace TorneSe.ServicoNotaAlunos.Domain.Interfaces.Repositories;

public interface IDisciplinaRepository : IRepository<Disciplina>
{
    Task<Disciplina> BuscarDisciplinaPorAtividadeId(int atividadeId);
    Task<Disciplina> BuscarDisciplinaPorAtividadeIdDb(int atividadeId);
    Task<bool> ConectadoAoBanco();
}
