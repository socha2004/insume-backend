using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace insume_backend.Migrations
{
    /// <inheritdoc />
    public partial class AddUsuarioIdToCategorias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "idUsuario",
                table: "Categorias");
            //migrationBuilder.DropIndex(
            //    name: "IX_Categorias_IdUsuario",
            //    table: "Categorias"
            //    );
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Categorias_Usuarios_IdUsuario",
            //    table: "Categorias"
            //    );

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Categorias",
                type: "integer",
                nullable: false
                );

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_UsuarioId",
                table: "Categorias",
                column: "UsuarioId"
                );

            migrationBuilder.AddForeignKey(
                name: "FK_Categorias_Usuarios_UsuarioId",
                table: "Categorias",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade
                );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "idUsuario",
                table: "Categorias",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Categorias"
                );

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

            migrationBuilder.DropForeignKey(
           name: "FK_Categorias_Usuarios_UsuarioId",
           table: "Categorias");

            migrationBuilder.DropIndex(
                name: "IX_Categorias_UsuarioId",
                table: "Categorias");
        }
    }
}
