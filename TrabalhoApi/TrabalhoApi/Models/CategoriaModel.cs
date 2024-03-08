using Sistemade_Tarefas.Enums;

namespace TrabalhoApi.Models
{
    public class CategoriaModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public StatusCategoria Status { get; }
    }
}
