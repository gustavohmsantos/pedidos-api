﻿using Microsoft.EntityFrameworkCore;
using PedidosApi.Models;

namespace PedidosApi.Data
{
    public class PedidosApiContext: DbContext
    {
        public PedidosApiContext(DbContextOptions<PedidosApiContext> options): base(options)
        {
            
        }

        public DbSet<ClienteModel> Clientes { get; set; }
        public DbSet<PedidoModel> Pedidos { get; set; }
        public DbSet<ProdutoModel> Produtos { get; set; }
        public DbSet<ItemPedidoModel> ItensPedidos { get; set; }
    }
}
