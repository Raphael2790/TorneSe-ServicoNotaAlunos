using System;

namespace TorneSe.ServicoNotaAlunos.Domain.DomainObjects;

public interface IRepository<T> : IDisposable where T : IRaizAgregacao
{
}
