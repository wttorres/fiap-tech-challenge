using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechChallenge.GameStore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CadastroJogo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "jogo",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Preco",
                table: "jogo",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_jogo_Nome",
                table: "jogo",
                column: "Nome");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_jogo_Nome",
                table: "jogo");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "jogo");

            migrationBuilder.DropColumn(
                name: "Preco",
                table: "jogo");
        }
    }
}
