using PedidosApi.Dtos.Cliente;

namespace PedidosApi.Dtos.Pedido
{
    public class ReadPedidoDto
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
    }
}
