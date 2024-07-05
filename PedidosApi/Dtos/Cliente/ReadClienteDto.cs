namespace PedidosApi.Dtos.Cliente
{
    public class ReadClienteDto
    {
        public string NomeCompleto { get; set; }
        public string Cpf { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public DateTime DataDeCadastro { get; set; }
    }
}
