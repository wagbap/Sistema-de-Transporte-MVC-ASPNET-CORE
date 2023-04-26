using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudWag.Migrations
{
    /// <inheritdoc />
    public partial class Booking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageURL",
                table: "TbTransporte",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioModelId",
                table: "TbTransporte",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioModelId",
                table: "TbMotorista",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TbTransporte_UsuarioModelId",
                table: "TbTransporte",
                column: "UsuarioModelId");

            migrationBuilder.CreateIndex(
                name: "IX_TbMotorista_UsuarioModelId",
                table: "TbMotorista",
                column: "UsuarioModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_TbMotorista_TbUsuarios_UsuarioModelId",
                table: "TbMotorista",
                column: "UsuarioModelId",
                principalTable: "TbUsuarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TbTransporte_TbUsuarios_UsuarioModelId",
                table: "TbTransporte",
                column: "UsuarioModelId",
                principalTable: "TbUsuarios",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbMotorista_TbUsuarios_UsuarioModelId",
                table: "TbMotorista");

            migrationBuilder.DropForeignKey(
                name: "FK_TbTransporte_TbUsuarios_UsuarioModelId",
                table: "TbTransporte");

            migrationBuilder.DropIndex(
                name: "IX_TbTransporte_UsuarioModelId",
                table: "TbTransporte");

            migrationBuilder.DropIndex(
                name: "IX_TbMotorista_UsuarioModelId",
                table: "TbMotorista");

            migrationBuilder.DropColumn(
                name: "UsuarioModelId",
                table: "TbTransporte");

            migrationBuilder.DropColumn(
                name: "UsuarioModelId",
                table: "TbMotorista");

            migrationBuilder.AlterColumn<string>(
                name: "ImageURL",
                table: "TbTransporte",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
