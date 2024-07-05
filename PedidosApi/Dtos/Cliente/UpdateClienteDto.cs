using System.ComponentModel.DataAnnotations;

namespace PedidosApi.Dtos.Cliente
{
    public class UpdateClienteDto
    {
        [Required(ErrorMessage = "O nome completo é obrigatório!")]
        [StringLength(80, ErrorMessage = "O nome completo não pode exceder o limite de 80 caracteres!")]
        public string NomeCompleto { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório!")]
        [RegularExpression(@"^[0-9]{3}[\.]?[0-9]{3}[\.]?[0-9]{3}[-]?[0-9]{2}$",
            ErrorMessage = "Formato de CPF inválido.")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O número de celular é obrigatório!")]
        [RegularExpression(@"^\(?(?:[14689][1-9]|2[12478]|3[1234578]|5[1345]|7[134579])\)? ?(?:[2-8]|9[0-9])[0-9]{3}\-?[0-9]{4}$",
            ErrorMessage = "Número de celular inválido.")]
        public string Celular { get; set; }

        [Required(ErrorMessage = "O endereço de email é obrigatório!")]
        [StringLength(256, ErrorMessage = "O endereço de email não pode exceder o limite de 256 caracteres!")]
        [RegularExpression(@"^[a-z0-9.]+@[a-z0-9]+\.[a-z]+(\.[a-z]+)?$",
            ErrorMessage = "Email inválido.")]
        public string Email { get; set; }
    }
}
