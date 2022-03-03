using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TorneSe.ServicoNotaAlunos.Domain.Entidades;

namespace TorneSe.ServicoNotaAlunos.Data.Mappings;

public class AtividadeMapping : IEntityTypeConfiguration<Atividade>
{
    public void Configure(EntityTypeBuilder<Atividade> builder)
    {
        throw new NotImplementedException();
    }
}
