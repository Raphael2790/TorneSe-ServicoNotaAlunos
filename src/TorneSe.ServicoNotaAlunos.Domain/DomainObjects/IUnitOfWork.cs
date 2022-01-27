using System.Threading.Tasks;

namespace TorneSe.ServicoNotaAlunos.Domain.DomainObjects;

public interface IUnitOfWork
{
    Task<bool> Commit();
}
