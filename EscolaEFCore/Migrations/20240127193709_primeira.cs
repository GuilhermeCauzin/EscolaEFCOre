using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EscolaEFCore.Migrations
{
    /// <inheritdoc />
    public partial class primeira : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_Classe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Classe", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_Escola",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Escola", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_Aluno",
                columns: table => new
                {
                    RM = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Classe = table.Column<int>(type: "int", nullable: false),
                    Escola = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Aluno", x => x.RM);
                    table.ForeignKey(
                        name: "FK_TB_Aluno_TB_Classe_Classe",
                        column: x => x.Classe,
                        principalTable: "TB_Classe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_Aluno_TB_Escola_Escola",
                        column: x => x.Escola,
                        principalTable: "TB_Escola",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_Professor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Escola = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Professor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_Professor_TB_Escola_Escola",
                        column: x => x.Escola,
                        principalTable: "TB_Escola",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_Aula",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfessorId = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HorarioInicio = table.Column<TimeSpan>(type: "time", nullable: false),
                    HorarioTermino = table.Column<TimeSpan>(type: "time", nullable: false),
                    Classe = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Aula", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_Aula_TB_Classe_Classe",
                        column: x => x.Classe,
                        principalTable: "TB_Classe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_Aula_TB_Professor_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "TB_Professor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_Aluno_Classe",
                table: "TB_Aluno",
                column: "Classe");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Aluno_Escola",
                table: "TB_Aluno",
                column: "Escola");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Aula_Classe",
                table: "TB_Aula",
                column: "Classe");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Aula_ProfessorId",
                table: "TB_Aula",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Professor_Escola",
                table: "TB_Professor",
                column: "Escola");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_Aluno");

            migrationBuilder.DropTable(
                name: "TB_Aula");

            migrationBuilder.DropTable(
                name: "TB_Classe");

            migrationBuilder.DropTable(
                name: "TB_Professor");

            migrationBuilder.DropTable(
                name: "TB_Escola");
        }
    }
}
