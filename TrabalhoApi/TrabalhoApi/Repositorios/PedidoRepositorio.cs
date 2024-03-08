using Microsoft.EntityFrameworkCore;
using TrabalhoApi.Data;
using TrabalhoApi.Models;
using TrabalhoApi.Repositorios.Interfaces;

namespace TrabalhoApi.Repositorios
{
    public class PedidoRepositorio : IPedidoRepositorio
    {
        private readonly TrabalhoApiDbContext _dbContext;

        public PedidoRepositorio(TrabalhoApiDbContext trabalhoApidbContext)
        {
            _dbContext = trabalhoApidbContext;
        }
        public async Task<PedidosModel> BuscarPorId(int id)
        {
            return await _dbContext.Pedidos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<PedidosModel>> BuscarTodosPedidos()
        {
            return await _dbContext.Pedidos.ToListAsync();
        }

        public async Task<PedidosModel> Adicionar(PedidosModel pedido)
        {
            await _dbContext.Pedidos.AddAsync(pedido);
            await _dbContext.SaveChangesAsync();

            return pedido;
        }
        public async Task<bool> Apagar(int id)
        {
            PedidosModel pedidoPorId = await BuscarPorId(id);
            if (pedidoPorId == null)
            {
                throw new Exception($"Pedido do Id : {id} não foi encontrado!");
            }
            _dbContext.Pedidos.Remove(pedidoPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<PedidosModel> Atualizar(PedidosModel pedido, int id)
        {
            PedidosModel pedidoPorId = await BuscarPorId(id);
            if (pedidoPorId == null)
            {
                throw new Exception($"Pedido do Id : {id} não foi encontrado!");
            }
          
            pedidoPorId.EnderecoEntrega = pedido.EnderecoEntrega;
            pedidoPorId.UsuarioId = pedido.UsuarioId;

            _dbContext.Pedidos.Update(pedidoPorId);
            await _dbContext.SaveChangesAsync();

            return pedidoPorId;
        }


    }
}

