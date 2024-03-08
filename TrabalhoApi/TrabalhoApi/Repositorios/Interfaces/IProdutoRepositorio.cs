using TrabalhoApi.Models;

namespace TrabalhoApi.Repositorios.Interfaces
{
    public interface IProdutoRepositorio
    {
        Task<List<ProdutoModel>> BuscarTodosProduto();

        Task<ProdutoModel> BuscarPorId(int id);

        Task<ProdutoModel> Adicionar(ProdutoModel produto);

        Task<ProdutoModel> Atualizar(ProdutoModel produto, int id);

        Task<bool> Apagar(int id);
    }
}
