using System.ComponentModel.DataAnnotations;

namespace PedidosApi.Models
{
    public class PedidoModel
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public int ClienteId { get; set; }

        public virtual ClienteModel Cliente { get; set; }
    }
}
