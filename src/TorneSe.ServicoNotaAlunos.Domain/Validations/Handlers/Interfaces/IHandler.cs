namespace TorneSe.ServicoNotaAlunos.Domain.Validations.Handlers.Interfaces;

public interface IHandler<T>
{
    IHandler<T> SetNext(IHandler<T> handler);
        
    void Handle(T request);
}
