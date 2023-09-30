using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Repositorios.Interfaces;

namespace WebApplication1.Repositorios
{
    public class TarefaRepositorio : ITarefaRepositorio
    {
        private readonly SistemaTarefasDBContex _dbContext;

        public TarefaRepositorio(SistemaTarefasDBContex sistemaTarefasDBContex)
        {
            _dbContext = sistemaTarefasDBContex;
        }

        public async Task<TarefaModel> BuscarPorId(int id)
        {
            // Busca uma tarefa pelo ID, incluindo a referência para o usuário associado.
            return await _dbContext.Tarefas
                .Include(x => x.Usuario)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<TarefaModel>> BuscarTodasTarefas()
        {
            // Busca todas as tarefas, incluindo a referência para o usuário associado.
            return await _dbContext.Tarefas
                .Include(x => x.Usuario)
                .ToListAsync();
        }

        public async Task<TarefaModel> Adicionar(TarefaModel tarefa)
        {
            // Adiciona uma nova tarefa ao contexto e salva as alterações no banco de dados.
            await _dbContext.Tarefas.AddAsync(tarefa);
            await _dbContext.SaveChangesAsync();
            return tarefa;
        }

        public async Task<TarefaModel> Atualizar(TarefaModel tarefa, int id)
        {
            // Busca a tarefa pelo ID.
            TarefaModel tarefaPorId = await BuscarPorId(id);

            if (tarefaPorId == null)
            {
                throw new Exception($"Tarefa para o ID:{id} não foi encontrada no banco de dados.");
            }

            // Atualiza os dados da tarefa com os novos valores.
            tarefaPorId.Name = tarefa.Name;
            tarefaPorId.Descricao = tarefa.Descricao;
            tarefaPorId.Status = tarefa.Status;
            tarefaPorId.UsuarioId = tarefa.UsuarioId;

            // Atualiza a tarefa no contexto e salva as alterações no banco de dados.
            _dbContext.Tarefas.Update(tarefaPorId);
            await _dbContext.SaveChangesAsync();
            return tarefaPorId;
        }

        public async Task<bool> Apagar(int id)
        {
            // Busca a tarefa pelo ID.
            TarefaModel tarefaPorId = await BuscarPorId(id);

            if (tarefaPorId == null)
            {
                throw new Exception($"Tarefa para o ID:{id} não foi encontrada no banco de dados.");
            }

            // Remove a tarefa do contexto e salva as alterações no banco de dados.
            _dbContext.Tarefas.Remove(tarefaPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}