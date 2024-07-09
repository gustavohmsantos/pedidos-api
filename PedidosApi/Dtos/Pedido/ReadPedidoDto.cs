using PedidosApi.Dtos.Cliente;
using PedidosApi.Dtos.ItemPedido;

namespace PedidosApi.Dtos.Pedido
{
    public class ReadPedidoDto
    {
        public int Id { get; set; }
        public ReadClienteDto Cliente { get; set; }
        public ICollection<ReadItemPedidoDto> Itens { get; set; }
    }
}
