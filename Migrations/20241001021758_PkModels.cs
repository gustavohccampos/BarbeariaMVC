using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarbeariaMVC.Migrations
{
    /// <inheritdoc />
    public partial class PkModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "AtendimentoServicos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "AtendimentoServicos");
        }
    }
}
