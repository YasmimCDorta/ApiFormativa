using TrabalhoApi.Models;

namespace TrabalhoApi.Repositorios.Interfaces
{
    public interface ICategoriaRepositorio
    {
        Task<List<CategoriaModel>> BuscarTodasCategoria();

        Task<CategoriaModel> BuscarPorId(int id);

        Task<CategoriaModel> Adicionar(CategoriaModel categoria);

        Task<CategoriaModel> Atualizar(CategoriaModel categoria, int id);

        Task<bool> Apagar(int id);
    }
}
