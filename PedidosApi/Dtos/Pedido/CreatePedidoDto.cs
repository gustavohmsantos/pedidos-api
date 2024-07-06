using PedidosApi.Models;
using System.ComponentModel.DataAnnotations;

namespace PedidosApi.Dtos.Pedido
{
    public class CreatePedidoDto
    {
        [Required]
        public int ClienteId { get; set; }
    }
}
