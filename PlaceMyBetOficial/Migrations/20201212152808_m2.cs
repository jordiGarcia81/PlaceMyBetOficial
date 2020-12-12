using Microsoft.EntityFrameworkCore.Migrations;

namespace PlaceMyBetOficial.Migrations
{
    public partial class m2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_Mercados_MercadoId",
                table: "Eventos");

            migrationBuilder.DropIndex(
                name: "IX_Eventos_MercadoId",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "MercadoId",
                table: "Eventos");

            migrationBuilder.CreateIndex(
                name: "IX_Mercados_EventoId",
                table: "Mercados",
                column: "EventoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mercados_Eventos_EventoId",
                table: "Mercados",
                column: "EventoId",
                principalTable: "Eventos",
                principalColumn: "EventoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mercados_Eventos_EventoId",
                table: "Mercados");

            migrationBuilder.DropIndex(
                name: "IX_Mercados_EventoId",
                table: "Mercados");

            migrationBuilder.AddColumn<int>(
                name: "MercadoId",
                table: "Eventos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_MercadoId",
                table: "Eventos",
                column: "MercadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_Mercados_MercadoId",
                table: "Eventos",
                column: "MercadoId",
                principalTable: "Mercados",
                principalColumn: "MercadoId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
