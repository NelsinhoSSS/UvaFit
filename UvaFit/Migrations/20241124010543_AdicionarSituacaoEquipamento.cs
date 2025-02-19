using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UvaFit.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarSituacaoEquipamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Equipamentos");

            migrationBuilder.RenameColumn(
                name: "SituaçãoMatricula",
                table: "Matriculas",
                newName: "SituacaoMatricula");

            migrationBuilder.AddColumn<int>(
                name: "SituacaoEquipamento",
                table: "Equipamentos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SituacaoEquipamento",
                table: "Equipamentos");

            migrationBuilder.RenameColumn(
                name: "SituacaoMatricula",
                table: "Matriculas",
                newName: "SituaçãoMatricula");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Equipamentos",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
