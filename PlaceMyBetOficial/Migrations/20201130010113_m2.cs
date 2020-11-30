using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PlaceMyBetOficial.Migrations
{
    public partial class m2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "dineroUnder",
                table: "Mercados",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "dineroOver",
                table: "Mercados",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "cuotaUnder",
                table: "Mercados",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "cuotaOver",
                table: "Mercados",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "float");

            migrationBuilder.InsertData(
                table: "Apuestas",
                columns: new[] { "ApuestaId", "dinero", "fecha", "mercadoId", "tipoApuesta", "tipoMercado", "usuarioId" },
                values: new object[] { 1, 50, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "under", "1.5", null });

            migrationBuilder.InsertData(
                table: "Eventos",
                columns: new[] { "eventoId", "MercadoId", "fecha", "local", "visitante" },
                values: new object[] { 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "madrid", "valencia" });

            migrationBuilder.InsertData(
                table: "Mercados",
                columns: new[] { "MercadoId", "cuotaOver", "cuotaUnder", "dineroOver", "dineroUnder", "eventoId", "overUnder" },
                values: new object[] { 1, 3.7999999999999998, 1.45, 950.0, 300.0, 1, "1.5" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "usuarioId", "apellidos", "edad", "nombre" },
                values: new object[] { "jordigarcia@gmail.com", "Garcia Ibor", 39, "jordi" });

            migrationBuilder.InsertData(
                table: "Cuentas",
                columns: new[] { "cuentaId", "nombreBanco", "saldo", "usuarioId" },
                values: new object[] { 1234567876543212L, "bankia", 100, "jordigarcia@gmail.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Apuestas",
                keyColumn: "ApuestaId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cuentas",
                keyColumn: "cuentaId",
                keyValue: 1234567876543212L);

            migrationBuilder.DeleteData(
                table: "Eventos",
                keyColumn: "eventoId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Mercados",
                keyColumn: "MercadoId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "usuarioId",
                keyValue: "jordigarcia@gmail.com");

            migrationBuilder.AlterColumn<float>(
                name: "dineroUnder",
                table: "Mercados",
                type: "float",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<float>(
                name: "dineroOver",
                table: "Mercados",
                type: "float",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<float>(
                name: "cuotaUnder",
                table: "Mercados",
                type: "float",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<float>(
                name: "cuotaOver",
                table: "Mercados",
                type: "float",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
