using FluentValidation.Results;

namespace TorneSe.ServicoNotaAlunos.Domain.DomainObjects;

public abstract class Mensagem
{
    public DateTime MensagemCriada { get; protected set; }
    public ValidationResult Validacoes { get; protected set; }
    public Mensagem()
    {
        
    }

    public virtual bool MensagemEstaValida()
    {
        throw new NotImplementedException();
    }
}
