using Microsoft.EntityFrameworkCore;
using TrabalhoApi.Data;
using TrabalhoApi.Models;
using TrabalhoApi.Repositorios.Interfaces;

namespace TrabalhoApi.Repositorios
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        private readonly TrabalhoApiDbContext _dbContext;
        
        public CategoriaRepositorio(TrabalhoApiDbContext trabalhoApidbContext)
        {
            _dbContext = trabalhoApidbContext;
        }
        public async Task<CategoriaModel> BuscarPorId(int id)
        {
            return await _dbContext.Categoria.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<CategoriaModel>> BuscarTodasCategoria()
        {
            return await _dbContext.Categoria.ToListAsync();
        }

        public async Task<CategoriaModel> Adicionar(CategoriaModel categoria)
        {
            await _dbContext.Categoria.AddAsync(categoria);
            await _dbContext.SaveChangesAsync();

            return categoria;
        }
        public async Task<bool> Apagar(int id)
        {
            CategoriaModel categoriaPorId = await BuscarPorId(id);
            if (categoriaPorId == null)
            {
                throw new Exception($"Categoria do Id : {id} não foi encontrada!");
            }
            _dbContext.Categoria.Remove(categoriaPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<CategoriaModel> Atualizar(CategoriaModel categoria, int id)
        {
            CategoriaModel categoriaPorId = await BuscarPorId(id);
            if (categoriaPorId == null)
            {
                throw new Exception($"Categoria do Id : {id} não foi encontrada!");
            }
            categoriaPorId.Nome = categoria.Nome;

            _dbContext.Categoria.Update(categoriaPorId);
            await _dbContext.SaveChangesAsync();

            return categoriaPorId;
        }

    }
}

