using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudWag.Migrations
{
    /// <inheritdoc />
    public partial class Booking2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TbBooking",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PrecoTotal = table.Column<float>(type: "real", nullable: false),
                    ProvaCartaConducao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: true),
                    TransporteId = table.Column<int>(type: "int", nullable: true),
                    MotoristaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbBooking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TbBooking_TbMotorista_MotoristaId",
                        column: x => x.MotoristaId,
                        principalTable: "TbMotorista",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TbBooking_TbTransporte_TransporteId",
                        column: x => x.TransporteId,
                        principalTable: "TbTransporte",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TbBooking_TbUsuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "TbUsuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TbBooking_MotoristaId",
                table: "TbBooking",
                column: "MotoristaId");

            migrationBuilder.CreateIndex(
                name: "IX_TbBooking_TransporteId",
                table: "TbBooking",
                column: "TransporteId");

            migrationBuilder.CreateIndex(
                name: "IX_TbBooking_UsuarioId",
                table: "TbBooking",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TbBooking");
        }
    }
}
