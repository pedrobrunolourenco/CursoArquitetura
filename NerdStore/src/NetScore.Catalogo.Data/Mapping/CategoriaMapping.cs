using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetStore.Catalogo.Domain;

namespace NetScore.Catalogo.Data.Mapping
{
    public class CategoriaMapping : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .IsRequired().HasColumnType("varchar(250)");

            // 1 - N => Categorias tem N Produtos
            builder.HasMany(c => c.Produtos).WithOne(p => p.Categoria).HasForeignKey(p => p.CategoriaId);



            builder.ToTable("Categorias");

        }
    }
}
