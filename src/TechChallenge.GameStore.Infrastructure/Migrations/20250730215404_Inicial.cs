using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TechChallenge.GameStore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "jogo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Preco = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jogo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "promocao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    DescontoPercentual = table.Column<decimal>(type: "numeric", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataFim = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_promocao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Senha = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Perfil = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "promocao_jogo",
                columns: table => new
                {
                    PromocaoId = table.Column<int>(type: "integer", nullable: false),
                    JogoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_promocao_jogo", x => new { x.PromocaoId, x.JogoId });
                    table.ForeignKey(
                        name: "FK_promocao_jogo_jogo_JogoId",
                        column: x => x.JogoId,
                        principalTable: "jogo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_promocao_jogo_promocao_PromocaoId",
                        column: x => x.PromocaoId,
                        principalTable: "promocao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BibliotecaJogos",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "integer", nullable: false),
                    JogoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BibliotecaJogos", x => new { x.UsuarioId, x.JogoId });
                    table.ForeignKey(
                        name: "FK_BibliotecaJogos_jogo_JogoId",
                        column: x => x.JogoId,
                        principalTable: "jogo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BibliotecaJogos_usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HistoricoCompras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UsuarioId = table.Column<int>(type: "integer", nullable: false),
                    DataCompra = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoCompras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoricoCompras_usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItensCompra",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HistoricoCompraId = table.Column<int>(type: "integer", nullable: false),
                    JogoId = table.Column<int>(type: "integer", nullable: false),
                    PrecoPago = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensCompra", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItensCompra_HistoricoCompras_HistoricoCompraId",
                        column: x => x.HistoricoCompraId,
                        principalTable: "HistoricoCompras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItensCompra_jogo_JogoId",
                        column: x => x.JogoId,
                        principalTable: "jogo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BibliotecaJogos_JogoId",
                table: "BibliotecaJogos",
                column: "JogoId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoCompras_UsuarioId",
                table: "HistoricoCompras",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ItensCompra_HistoricoCompraId",
                table: "ItensCompra",
                column: "HistoricoCompraId");

            migrationBuilder.CreateIndex(
                name: "IX_ItensCompra_JogoId",
                table: "ItensCompra",
                column: "JogoId");

            migrationBuilder.CreateIndex(
                name: "IX_jogo_Nome",
                table: "jogo",
                column: "Nome");

            migrationBuilder.CreateIndex(
                name: "IX_promocao_jogo_JogoId",
                table: "promocao_jogo",
                column: "JogoId");

            migrationBuilder.CreateIndex(
                name: "IX_usuario_Email",
                table: "usuario",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BibliotecaJogos");

            migrationBuilder.DropTable(
                name: "ItensCompra");

            migrationBuilder.DropTable(
                name: "promocao_jogo");

            migrationBuilder.DropTable(
                name: "HistoricoCompras");

            migrationBuilder.DropTable(
                name: "jogo");

            migrationBuilder.DropTable(
                name: "promocao");

            migrationBuilder.DropTable(
                name: "usuario");
        }
    }
}
