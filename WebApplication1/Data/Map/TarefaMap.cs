using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models;

namespace WebApplication1.Data.Map
{
    /// <summary>
    /// Mapeamento da entidade TarefaModel para o Entity Framework Core.
    /// </summary>
    public class TarefaMap : IEntityTypeConfiguration<TarefaModel>
    {
        /// <summary>
        /// Configura as propriedades e relacionamentos da entidade TarefaModel.
        /// </summary>
        /// <param name="builder">Builder para configuração da entidade.</param>
        public void Configure(EntityTypeBuilder<TarefaModel> builder)
        {
            // Define a chave primária da entidade como a propriedade Id.
            builder.HasKey(x => x.Id);

            // Configura a propriedade Name como obrigatória e com no máximo 255 caracteres.
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);

            // Configura a propriedade Descricao como obrigatória e com no máximo 1000 caracteres.
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(1000);

            // Configura a propriedade Status como obrigatória.
            builder.Property(x => x.Status).IsRequired();

            // Configura a propriedade UsuarioId.
            builder.Property(x => x.UsuarioId);

            // Configura o relacionamento com a entidade UsuarioModel.
            builder.HasOne(x => x.Usuario);
        }
    }
}