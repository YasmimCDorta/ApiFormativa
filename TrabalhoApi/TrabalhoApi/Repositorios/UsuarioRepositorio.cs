using Microsoft.EntityFrameworkCore;
using TrabalhoApi.Data;
using TrabalhoApi.Models;
using TrabalhoApi.Repositorios.Interfaces;

namespace TrabalhoApi.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly TrabalhoApiDbContext _dbContext;
        
        public UsuarioRepositorio(TrabalhoApiDbContext TrabalhoApidbContext)
        {
            _dbContext = TrabalhoApidbContext;
        }
        public async Task<UsuarioModel> BuscarPorId(int id)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }

        public async Task<UsuarioModel> Adicionar(UsuarioModel usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            

            return usuario;
        }
        public async Task<bool> Apagar(int id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id);
            if (usuarioPorId == null)
            {
                throw new Exception($"Usuario do Id : {id} não foi encontrado!");
            }
            _dbContext.Usuarios.Remove(usuarioPorId);

            return true;
        }

        public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id);
            if (usuarioPorId == null)
            {
                throw new Exception($"Usuario do Id : {id} não foi encontrado!");
            }
            usuarioPorId.Nome = usuario.Nome;
            usuarioPorId.Email = usuario.Email;
            usuarioPorId.DataNascimento = usuario.DataNascimento;

            _dbContext.Usuarios.Update(usuarioPorId);

            return usuarioPorId;
        }

    }
}

