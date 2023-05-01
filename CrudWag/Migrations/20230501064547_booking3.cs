using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudWag.Migrations
{
    /// <inheritdoc />
    public partial class booking3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbBooking_TbMotorista_MotoristaId",
                table: "TbBooking");

            migrationBuilder.DropIndex(
                name: "IX_TbBooking_MotoristaId",
                table: "TbBooking");

            migrationBuilder.DropColumn(
                name: "MotoristaId",
                table: "TbBooking");

            migrationBuilder.AddColumn<int>(
                name: "BookingModelId",
                table: "TbMotorista",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MovieGenre",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieGenre", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TbMotorista_BookingModelId",
                table: "TbMotorista",
                column: "BookingModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_TbMotorista_TbBooking_BookingModelId",
                table: "TbMotorista",
                column: "BookingModelId",
                principalTable: "TbBooking",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbMotorista_TbBooking_BookingModelId",
                table: "TbMotorista");

            migrationBuilder.DropTable(
                name: "MovieGenre");

            migrationBuilder.DropIndex(
                name: "IX_TbMotorista_BookingModelId",
                table: "TbMotorista");

            migrationBuilder.DropColumn(
                name: "BookingModelId",
                table: "TbMotorista");

            migrationBuilder.AddColumn<int>(
                name: "MotoristaId",
                table: "TbBooking",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TbBooking_MotoristaId",
                table: "TbBooking",
                column: "MotoristaId");

            migrationBuilder.AddForeignKey(
                name: "FK_TbBooking_TbMotorista_MotoristaId",
                table: "TbBooking",
                column: "MotoristaId",
                principalTable: "TbMotorista",
                principalColumn: "Id");
        }
    }
}
