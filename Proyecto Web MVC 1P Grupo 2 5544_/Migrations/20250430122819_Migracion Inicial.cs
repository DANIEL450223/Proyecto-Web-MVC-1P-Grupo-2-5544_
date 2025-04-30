using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto_Web_MVC_1P_Grupo_2_5544_.Migrations
{
    /// <inheritdoc />
    public partial class MigracionInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    clienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreCliente = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    telefonoCliente = table.Column<int>(type: "int", nullable: false),
                    correoCliente = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.clienteId);
                });

            migrationBuilder.CreateTable(
                name: "Vehiculo",
                columns: table => new
                {
                    vehiculoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    placaVehiculo = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    modeloVehiculo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    marcaVehiculo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    colorVehiculo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    fechaIngreso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fechaSalida = table.Column<DateTime>(type: "datetime2", nullable: true),
                    clienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculo", x => x.vehiculoId);
                    table.ForeignKey(
                        name: "FK_Vehiculo_Cliente_clienteId",
                        column: x => x.clienteId,
                        principalTable: "Cliente",
                        principalColumn: "clienteId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Espacios",
                columns: table => new
                {
                    espacioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    estadoEspacio = table.Column<bool>(type: "bit", nullable: false),
                    vehiculoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Espacios", x => x.espacioId);
                    table.ForeignKey(
                        name: "FK_Espacios_Vehiculo_vehiculoId",
                        column: x => x.vehiculoId,
                        principalTable: "Vehiculo",
                        principalColumn: "vehiculoId");
                });

            migrationBuilder.CreateTable(
                name: "Pago",
                columns: table => new
                {
                    pagoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    clienteId = table.Column<int>(type: "int", nullable: false),
                    vehiculoId = table.Column<int>(type: "int", nullable: false),
                    fechaPago = table.Column<DateTime>(type: "datetime2", nullable: false),
                    montoPagado = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pago", x => x.pagoId);
                    table.ForeignKey(
                        name: "FK_Pago_Cliente_clienteId",
                        column: x => x.clienteId,
                        principalTable: "Cliente",
                        principalColumn: "clienteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pago_Vehiculo_vehiculoId",
                        column: x => x.vehiculoId,
                        principalTable: "Vehiculo",
                        principalColumn: "vehiculoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Registros",
                columns: table => new
                {
                    registroId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    vehiculoId = table.Column<int>(type: "int", nullable: false),
                    clienteId = table.Column<int>(type: "int", nullable: false),
                    fechaEntrada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fechaSalida = table.Column<DateTime>(type: "datetime2", nullable: true),
                    pagoRealizado = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registros", x => x.registroId);
                    table.ForeignKey(
                        name: "FK_Registros_Cliente_clienteId",
                        column: x => x.clienteId,
                        principalTable: "Cliente",
                        principalColumn: "clienteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Registros_Vehiculo_vehiculoId",
                        column: x => x.vehiculoId,
                        principalTable: "Vehiculo",
                        principalColumn: "vehiculoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Espacios_vehiculoId",
                table: "Espacios",
                column: "vehiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pago_clienteId",
                table: "Pago",
                column: "clienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Pago_vehiculoId",
                table: "Pago",
                column: "vehiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_Registros_clienteId",
                table: "Registros",
                column: "clienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Registros_vehiculoId",
                table: "Registros",
                column: "vehiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculo_clienteId",
                table: "Vehiculo",
                column: "clienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Espacios");

            migrationBuilder.DropTable(
                name: "Pago");

            migrationBuilder.DropTable(
                name: "Registros");

            migrationBuilder.DropTable(
                name: "Vehiculo");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
