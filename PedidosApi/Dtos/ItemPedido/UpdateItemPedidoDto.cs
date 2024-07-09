﻿using System.ComponentModel.DataAnnotations;

namespace PedidosApi.Dtos.ItemPedido
{
    public class UpdateItemPedidoDto
    {
        //[Required]
        //public int ProdutoId { get; set; }

        [Required(ErrorMessage = "É necessário informar uma quantidade!")]
        [Range(1, 50, ErrorMessage = "A quantidade deve ser entre 1 e 50")]
        public int Quantidade { get; set; }
    }
}
