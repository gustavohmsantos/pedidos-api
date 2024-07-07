using System.ComponentModel.DataAnnotations;

namespace PedidosApi.Dtos.Produto {
    public class CreateProdutoDto
    {
        [Required(ErrorMessage = "O nome é obrigatório!")]
        [StringLength(80, ErrorMessage = "O nome não pode exceder o limite de 80 caracteres!")]
        public string Nome { get; set; }
    }
}
