using Microsoft.EntityFrameworkCore;
using WebApplication1.Data.Map;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    /// <summary>
    /// Contexto de banco de dados para o sistema de tarefas.
    /// </summary>
    public class SistemaTarefasDBContex : DbContext
    {
        /// <summary>
        /// Construtor da classe SistemaTarefasDBContex.
        /// </summary>
        /// <param name="options">Opções de configuração do contexto.</param>
        public SistemaTarefasDBContex(DbContextOptions<SistemaTarefasDBContex> options)
            : base(options)
        {

        }

        /// <summary>
        /// Conjunto de entidades representando usuários no banco de dados.
        /// </summary>
        public DbSet<UsuarioModel> Usuarios { get; set; }

        /// <summary>
        /// Conjunto de entidades representando tarefas no banco de dados.
        /// </summary>
        public DbSet<TarefaModel> Tarefas { get; set; }

        /// <summary>
        /// Configuração do modelo ao criar o contexto.
        /// </summary>
        /// <param name="modelBuilder">Builder para configuração do modelo.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Aplica as configurações de mapeamento para as entidades.
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new TarefaMap());

            // Chama o método base para completar a configuração do modelo.
            base.OnModelCreating(modelBuilder);
        }
    }
}