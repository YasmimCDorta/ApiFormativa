namespace TrabalhoApi.Models
{
    public class PedidosProdutosModel
    {
        public int Id { get; set; }
        public int CategoriaId { get; set; }
        public CategoriaModel? Categoria { get; set; }
        public int ProdutoId { get; set; }
        public ProdutoModel? Produto { get; set; }
        public int Quantidade { get; set; }
    }
}
