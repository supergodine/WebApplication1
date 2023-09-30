using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Repositorios.Interfaces;

namespace WebApplication1.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly SistemaTarefasDBContex _dbContext;

        public UsuarioRepositorio(SistemaTarefasDBContex sistemaTarefasDBContex)
        {
            _dbContext = sistemaTarefasDBContex;
        }

        public async Task<UsuarioModel> BuscarPorId(int id)
        {
            // Busca um usuário pelo ID.
            return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            // Busca todos os usuários.
            return await _dbContext.Usuarios.ToListAsync();
        }

        public async Task<UsuarioModel> Adicionar(UsuarioModel usuario)
        {
            // Adiciona um novo usuário ao contexto e salva as alterações no banco de dados.
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();
            return usuario;
        }

        public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id)
        {
            // Busca o usuário pelo ID.
            UsuarioModel usuarioPorId = await BuscarPorId(id);

            if (usuarioPorId == null)
            {
                throw new Exception($"Usuário para o ID:{id} não foi encontrado no banco de dados.");
            }

            // Atualiza os dados do usuário com os novos valores.
            usuarioPorId.Name = usuario.Name;
            usuarioPorId.Email = usuario.Email;

            // Atualiza o usuário no contexto e salva as alterações no banco de dados.
            _dbContext.Usuarios.Update(usuarioPorId);
            await _dbContext.SaveChangesAsync();
            return usuarioPorId;
        }

        public async Task<bool> Apagar(int id)
        {
            // Busca o usuário pelo ID.
            UsuarioModel usuarioPorId = await BuscarPorId(id);

            if (usuarioPorId == null)
            {
                throw new Exception($"Usuário para o ID:{id} não foi encontrado no banco de dados.");
            }

            // Remove o usuário do contexto e salva as alterações no banco de dados.
            _dbContext.Usuarios.Remove(usuarioPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}