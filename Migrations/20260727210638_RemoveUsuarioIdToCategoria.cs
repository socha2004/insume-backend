using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace insume_backend.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUsuarioIdToCategoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Categorias"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
            name: "UsuarioId",
            table: "Categorias",
            type: "integer",
            nullable: false
            );
            
        }
    }
}
