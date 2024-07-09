using System.ComponentModel.DataAnnotations;

namespace PedidosApi.Dtos.Pedido
{
    public class UpdatePedidoDto
    {
        [Required]
        public int ClienteId { get; set; }
    }
}
