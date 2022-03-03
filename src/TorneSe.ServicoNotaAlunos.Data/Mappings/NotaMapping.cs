using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TorneSe.ServicoNotaAlunos.Domain.Entidades;

namespace TorneSe.ServicoNotaAlunos.Data.Mappings;

public class NotaMapping : IEntityTypeConfiguration<Nota>
{
    public void Configure(EntityTypeBuilder<Nota> builder)
    {
        throw new NotImplementedException();
    }
}
