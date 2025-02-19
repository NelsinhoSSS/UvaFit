using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UvaFit.Migrations
{
    /// <inheritdoc />
    public partial class AddPlanoMatriculaToMatricula : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlanoMatricula",
                table: "Matriculas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlanoMatricula",
                table: "Matriculas");
        }
    }
}
