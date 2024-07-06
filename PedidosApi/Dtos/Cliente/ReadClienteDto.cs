using PedidosApi.Dtos.Pedido;

namespace PedidosApi.Dtos.Cliente
{
    public class ReadClienteDto
    {
        public string NomeCompleto { get; set; }
        public string Cpf { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public DateTime DataDeCadastro { get; set; }
        public ICollection<ReadPedidoDto> Pedidos { get; set; }
    }
}
