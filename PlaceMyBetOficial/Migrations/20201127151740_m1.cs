using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PlaceMyBetOficial.Migrations
{
    public partial class m1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mercados",
                columns: table => new
                {
                    MercadoId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    overUnder = table.Column<string>(nullable: true),
                    cuotaOver = table.Column<float>(nullable: false),
                    cuotaUnder = table.Column<float>(nullable: false),
                    dineroOver = table.Column<float>(nullable: false),
                    dineroUnder = table.Column<float>(nullable: false),
                    eventoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mercados", x => x.MercadoId);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    usuarioId = table.Column<string>(nullable: false),
                    nombre = table.Column<string>(nullable: true),
                    apellidos = table.Column<string>(nullable: true),
                    edad = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.usuarioId);
                });

            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    eventoId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    visitante = table.Column<string>(nullable: true),
                    local = table.Column<string>(nullable: true),
                    fecha = table.Column<DateTime>(nullable: false),
                    MercadoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.eventoId);
                    table.ForeignKey(
                        name: "FK_Eventos_Mercados_MercadoId",
                        column: x => x.MercadoId,
                        principalTable: "Mercados",
                        principalColumn: "MercadoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Apuestas",
                columns: table => new
                {
                    ApuestaId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tipoApuesta = table.Column<string>(nullable: true),
                    tipoMercado = table.Column<string>(nullable: true),
                    dinero = table.Column<int>(nullable: false),
                    fecha = table.Column<DateTime>(nullable: false),
                    mercadoId = table.Column<int>(nullable: false),
                    usuarioId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apuestas", x => x.ApuestaId);
                    table.ForeignKey(
                        name: "FK_Apuestas_Mercados_mercadoId",
                        column: x => x.mercadoId,
                        principalTable: "Mercados",
                        principalColumn: "MercadoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Apuestas_Usuarios_usuarioId",
                        column: x => x.usuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "usuarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cuentas",
                columns: table => new
                {
                    cuentaId = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombreBanco = table.Column<string>(nullable: true),
                    saldo = table.Column<int>(nullable: false),
                    usuarioId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuentas", x => x.cuentaId);
                    table.ForeignKey(
                        name: "FK_Cuentas_Usuarios_usuarioId",
                        column: x => x.usuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "usuarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Apuestas_mercadoId",
                table: "Apuestas",
                column: "mercadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Apuestas_usuarioId",
                table: "Apuestas",
                column: "usuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Cuentas_usuarioId",
                table: "Cuentas",
                column: "usuarioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_MercadoId",
                table: "Eventos",
                column: "MercadoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Apuestas");

            migrationBuilder.DropTable(
                name: "Cuentas");

            migrationBuilder.DropTable(
                name: "Eventos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Mercados");
        }
    }
}
