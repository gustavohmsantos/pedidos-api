using System.ComponentModel.DataAnnotations;

namespace PedidosApi.Models
{
    public class ItemPedidoModel
    {
        [Required]
        public int PedidoId { get; set; }

        public virtual PedidoModel Pedido { get; set; }

        [Required]
        public int ProdutoId { get; set; }
        public virtual ProdutoModel Produto { get; set; }

        [Required(ErrorMessage = "É necessário informar uma quantidade")]
        [Range(1, 50, ErrorMessage = "A quantidade deve ser entre 1 e 50")]
        public int Quantidade { get; set; }
    }
}
