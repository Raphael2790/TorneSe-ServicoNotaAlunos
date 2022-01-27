namespace TorneSe.ServicoNotaAlunos.Domain.DomainObjects;

public abstract class Mensagem
{
    public DateTime MensagemCriada { get; set; }
    public Mensagem()
    {
        
    }

    public virtual bool MensagemEstaValida()
    {
        throw new NotImplementedException();
    }
}
