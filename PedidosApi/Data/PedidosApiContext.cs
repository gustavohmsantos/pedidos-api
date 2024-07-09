using Microsoft.EntityFrameworkCore;
using PedidosApi.Models;

namespace PedidosApi.Data
{
    public class PedidosApiContext: DbContext
    {
        public PedidosApiContext(DbContextOptions<PedidosApiContext> options): base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemPedidoModel>()
                .HasKey(itemPedidoModel => new { itemPedidoModel.PedidoId, itemPedidoModel.ProdutoId });

            modelBuilder.Entity<ItemPedidoModel>()
                .HasOne(itemPedidoModel => itemPedidoModel.Pedido)
                .WithMany(pedidoModel => pedidoModel.ItensPedido)
                .HasForeignKey(itemPedidoModel => itemPedidoModel.PedidoId);

            modelBuilder.Entity<ItemPedidoModel>()
                .HasOne(itemPedidoModel => itemPedidoModel.Produto)
                .WithMany(produtoModel => produtoModel.ItensPedido)
                .HasForeignKey(itemPedidoModel => itemPedidoModel.ProdutoId);
        }

        public DbSet<ClienteModel> Clientes { get; set; }
        public DbSet<PedidoModel> Pedidos { get; set; }
        public DbSet<ProdutoModel> Produtos { get; set; }
        public DbSet<ItemPedidoModel> ItensPedidos { get; set; }
    }
}
