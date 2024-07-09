using PedidosApi.Dtos.Produto;

namespace PedidosApi.Dtos.ItemPedido
{
    public class ReadItemPedidoDto
    {
        public int PedidoId { get; set; }
        public ReadProdutoDto Produto { get; set; }
        public int Quantidade { get; set; }
    }
}
