using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PedidosApi.Migrations
{
    /// <inheritdoc />
    public partial class ItemPedidoRefatorado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ItensPedidos",
                table: "ItensPedidos");

            migrationBuilder.DropIndex(
                name: "IX_ItensPedidos_PedidoId",
                table: "ItensPedidos");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ItensPedidos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItensPedidos",
                table: "ItensPedidos",
                columns: new[] { "PedidoId", "ProdutoId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ItensPedidos",
                table: "ItensPedidos");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ItensPedidos",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItensPedidos",
                table: "ItensPedidos",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ItensPedidos_PedidoId",
                table: "ItensPedidos",
                column: "PedidoId");
        }
    }
}
