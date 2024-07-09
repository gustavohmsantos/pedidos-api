using System.ComponentModel.DataAnnotations;

namespace PedidosApi.Models
{
    public class ProdutoModel
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório!")]
        [MaxLength(80, ErrorMessage = "O nome não pode exceder o limite de 80 caracteres!")]
        public string Nome { get; set; }

        public virtual ICollection<ItemPedidoModel> ItensPedido { get; set; }
    }
}
