using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TorneSe.ServicoNotaAlunos.Domain.Entidades;

namespace TorneSe.ServicoNotaAlunos.Data.Mappings;

public class ConteudoMapping : IEntityTypeConfiguration<Conteudo>
{
    public void Configure(EntityTypeBuilder<Conteudo> builder)
    {
        
    }
}
