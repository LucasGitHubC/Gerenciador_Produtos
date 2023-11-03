using ApiTarefa.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiTarefa.Data.Map
{
    public class UsuarioMap : IEntityTypeConfiguration<UsuarioModel>
    {
        public void Configure(EntityTypeBuilder<UsuarioModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Descricao).HasMaxLength(500); // Ajuste o tamanho máximo apropriado
            builder.Property(x => x.Preco).HasColumnType("decimal(18, 2)"); // Define o tipo de dados para preço (decimal com 2 casas decimais)
            builder.Property(x => x.DataCriacao).IsRequired(); // Suponhamos que a data de criação é obrigatória


        }
    }
}
