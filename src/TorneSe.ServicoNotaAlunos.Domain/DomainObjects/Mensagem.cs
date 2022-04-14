using System.Text.Json.Serialization;
using FluentValidation.Results;

namespace TorneSe.ServicoNotaAlunos.Domain.DomainObjects;

public abstract class Mensagem
{
    [JsonIgnore]
    public DateTime MensagemCriada { get; protected set; }
    [JsonIgnore]
    public ValidationResult Validacoes { get; protected set; }
    public Mensagem()
    {
        
    }

    public virtual bool MensagemEstaValida()
    {
        throw new NotImplementedException();
    }
}
