using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechChallenge.GameStore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPerfilToUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Perfil",
                table: "usuario",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Perfil",
                table: "usuario");
        }
    }
}
