using Microsoft.EntityFrameworkCore;
using TrabalhoApi.Data;
using TrabalhoApi.Models;

namespace TrabalhoApi.Repositorios
{
    public class PedidosProdutosRepositorio : IPedidosProdutosRepositorio
    {
        private readonly TrabalhoApiDbContext _dbContext;

        public PedidosProdutosRepositorio(TrabalhoApiDbContext trabalhoApidbContext)
        {
            _dbContext = trabalhoApidbContext;
        }
        public async Task<PedidosProdutosModel> BuscarPorId(int id)
        {
            return await _dbContext.PedidosProdutos.
                Include(x => x.Categoria).
                Include(y => y.Produto).
                FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<PedidosProdutosModel>> BuscarTodosPedidosProdutos()
        {
            return await _dbContext.PedidosProdutos.
                Include(y => y.Produto).
                ToListAsync();
        }

        public async Task<PedidosProdutosModel> Adicionar(PedidosProdutosModel pedidosProdutos)
        {
            await _dbContext.PedidosProdutos.AddAsync(pedidosProdutos);
            await _dbContext.SaveChangesAsync();

            return pedidosProdutos;
        }
        public async Task<bool> Apagar(int id)
        {
            PedidosProdutosModel pedidosProdutosPorId = await BuscarPorId(id);
            if (pedidosProdutosPorId == null)
            {
                throw new Exception($"PedidosProdutos do Id : {id} não foi encontrado!");
            }
            _dbContext.PedidosProdutos.Remove(pedidosProdutosPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<PedidosProdutosModel> Atualizar(PedidosProdutosModel pedidosProdutos, int id)
        {
            PedidosProdutosModel pedidosProdutosPorId = await BuscarPorId(id);
            if (pedidosProdutosPorId == null)
            {
                throw new Exception($"PedidosProdutos do Id : {id} não foi encontrado!");
            }

            pedidosProdutosPorId.CategoriaId = pedidosProdutos.CategoriaId;
            pedidosProdutosPorId.ProdutoId = pedidosProdutos.CategoriaId;
            pedidosProdutosPorId.Quantidade = pedidosProdutos.Quantidade;

            _dbContext.PedidosProdutos.Update(pedidosProdutosPorId);
            await _dbContext.SaveChangesAsync();

            return pedidosProdutosPorId;
        }


    }
}

