using Microsoft.EntityFrameworkCore;
using TrabalhoApi.Data;
using TrabalhoApi.Models;
using TrabalhoApi.Repositorios.Interfaces;

namespace TrabalhoApi.Repositorios
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly TrabalhoApiDbContext _dbContext;

        public ProdutoRepositorio(TrabalhoApiDbContext trabalhoApidbContext)
        {
            _dbContext = trabalhoApidbContext;
        }
        public async Task<ProdutoModel> BuscarPorId(int id)
        {
            return await _dbContext.Produto.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<ProdutoModel>> BuscarTodosProduto()
        {
            return await _dbContext.Produto.ToListAsync();
        }

        public async Task<ProdutoModel> Adicionar(ProdutoModel produto)
        {
            await _dbContext.Produto.AddAsync(produto);
            await _dbContext.SaveChangesAsync();

            return produto;
        }
        public async Task<bool> Apagar(int id)
        {
            ProdutoModel produtoPorId = await BuscarPorId(id);
            if (produtoPorId == null)
            {
                throw new Exception($"Produto do Id : {id} não foi encontrado!");
            }
            _dbContext.Produto.Remove(produtoPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<ProdutoModel> Atualizar(ProdutoModel produto, int id)
        {
            ProdutoModel produtoPorId = await BuscarPorId(id);
            if (produtoPorId == null)
            {
                throw new Exception($"Produto do Id : {id} não foi encontrado!");
            }

            produtoPorId.Nome = produto.Nome;
            

            _dbContext.Produto.Update(produtoPorId);
            await _dbContext.SaveChangesAsync();

            return produtoPorId;
        }


    }
}

