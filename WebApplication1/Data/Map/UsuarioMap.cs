using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models;

namespace WebApplication1.Data.Map
{
    /// <summary>
    /// Mapeamento da entidade UsuarioModel para o Entity Framework Core.
    /// </summary>
    public class UsuarioMap : IEntityTypeConfiguration<UsuarioModel>
    {
        /// <summary>
        /// Configura as propriedades da entidade UsuarioModel.
        /// </summary>
        /// <param name="builder">Builder para configuração da entidade.</param>
        public void Configure(EntityTypeBuilder<UsuarioModel> builder)
        {
            // Define a chave primária da entidade como a propriedade Id.
            builder.HasKey(x => x.Id);

            // Configura a propriedade Name como obrigatória e com no máximo 255 caracteres.
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);

            // Configura a propriedade Email como obrigatória e com no máximo 150 caracteres.
            builder.Property(x => x.Email).IsRequired().HasMaxLength(150);

            // Configura a propriedade Sexo como obrigatória e com no máximo 100 caracteres.
            builder.Property(x => x.Sexo).IsRequired().HasMaxLength(100);

            // Configura a propriedade Telefone como obrigatória e com no máximo 150 caracteres.
            builder.Property(x => x.Telefone).IsRequired().HasMaxLength(150);

            // Configura a propriedade Endereco como obrigatória e com no máximo 255 caracteres.
            builder.Property(x => x.Endereco).IsRequired().HasMaxLength(255);
        }
    }
}