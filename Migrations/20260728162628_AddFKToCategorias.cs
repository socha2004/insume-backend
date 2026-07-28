using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace insume_backend.Migrations
{
    /// <inheritdoc />
    public partial class AddFKToCategorias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Categorias_IdUsuario",
                table: "Categorias",
                column: "idUsuario"
            );

            migrationBuilder.AddForeignKey(
           name: "FK_Categorias_Usuarios_IdUsuario",
           table: "Categorias",
           column: "idUsuario",
           principalTable: "Usuarios",
           principalColumn: "Id",
           onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
            name: "FK_Categorias_Usuarios_IdUsuario",
            table: "Categorias");

            migrationBuilder.DropIndex(
                name: "IX_Categorias_IdUsuario",
                table: "Categorias");
        }
    }
}
