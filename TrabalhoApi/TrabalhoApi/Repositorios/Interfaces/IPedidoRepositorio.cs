using TrabalhoApi.Models;

namespace TrabalhoApi.Repositorios.Interfaces
{
    public interface IPedidoRepositorio
    {
        Task<List<PedidosModel>> BuscarTodosPedidos();

        Task<PedidosModel> BuscarPorId(int id);

        Task<PedidosModel> Adicionar(PedidosModel pedido);

        Task<PedidosModel> Atualizar(PedidosModel pedido, int id);

        Task<bool> Apagar(int id);
    }
}
