using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudWag.Migrations
{
    /// <inheritdoc />
    public partial class resolved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TbMotorista",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotoristaImagem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DOB = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    data_adesao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sexo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbMotorista", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TbTransporte",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    CapacidadePassageiro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaxaAluguer = table.Column<float>(type: "real", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    TransporteTipo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbTransporte", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TbUsuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Perfil = table.Column<int>(type: "int", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbUsuarios", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TbMotorista");

            migrationBuilder.DropTable(
                name: "TbTransporte");

            migrationBuilder.DropTable(
                name: "TbUsuarios");
        }
    }
}
