using TorneSe.ServicoNotaAlunos.Domain.DomainObjects;
using TorneSe.ServicoNotaAlunos.Domain.Interfaces.Repositories;

namespace TorneSe.ServicoNotaAlunos.Data.Repositories;

public class DisciplinaRepository : IDisciplinaRepository
{
    public IUnitOfWork UnitOfWork => throw new NotImplementedException();

    public void Dispose()
    {
    }
}