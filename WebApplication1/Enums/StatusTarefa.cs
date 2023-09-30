using System.ComponentModel;

namespace WebApplication1.Enums
{
    /// <summary>
    /// Enumeração que representa o status de uma tarefa.
    /// </summary>
    public enum StatusTarefa
    {
        /// <summary>
        /// Tarefa a fazer.
        /// </summary>
        [Description("A fazer")]
        AFazer = 1,

        /// <summary>
        /// Tarefa em andamento.
        /// </summary>
        [Description("Em andamento")]
        EmAndamento = 2,

        /// <summary>
        /// Tarefa concluída.
        /// </summary>
        [Description("Concluído")]
        Concluido = 3,
    }
}