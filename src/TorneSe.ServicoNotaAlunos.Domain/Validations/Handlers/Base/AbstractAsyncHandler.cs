using TorneSe.ServicoNotaAlunos.Domain.DomainObjects;
using TorneSe.ServicoNotaAlunos.Domain.Validations.Handlers.Interfaces;

namespace TorneSe.ServicoNotaAlunos.Domain.Validations.Handlers.Base;

public class AbstractAsyncHandler<T> : IAsyncHandler<T> where T : ServicoNotaValidacaoRequest
{
    private IAsyncHandler<T> _nextHandler;

    public virtual async Task Handle(T request)
    {
        if (this._nextHandler != null)
        {
            await this._nextHandler.Handle(request);
        }
    }

    public IAsyncHandler<T> SetNext(IAsyncHandler<T> handler)
    {
         _nextHandler = handler;
        return handler;
    }
}
