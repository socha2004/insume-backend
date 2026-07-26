using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace insume_backend.Migrations
{
    /// <inheritdoc />
    public partial class RemoverCampoDuplicadoInsumos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Insumos_Categorias_CategoriaId",
                table: "Insumos");

            migrationBuilder.DropForeignKey(
                name: "FK_Insumos_Usuarios_UsuarioId",
                table: "Insumos");

            migrationBuilder.DropIndex(
                name: "IX_Insumos_CategoriaId",
                table: "Insumos");

            migrationBuilder.DropIndex(
                name: "IX_Insumos_UsuarioId",
                table: "Insumos");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "Insumos");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Insumos");

            migrationBuilder.CreateIndex(
                name: "IX_Insumos_IdCategoria",
                table: "Insumos",
                column: "IdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Insumos_IdUsuario",
                table: "Insumos",
                column: "IdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Insumos_Categorias_IdCategoria",
                table: "Insumos",
                column: "IdCategoria",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Insumos_Usuarios_IdUsuario",
                table: "Insumos",
                column: "IdUsuario",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Insumos_Categorias_IdCategoria",
                table: "Insumos");

            migrationBuilder.DropForeignKey(
                name: "FK_Insumos_Usuarios_IdUsuario",
                table: "Insumos");

            migrationBuilder.DropIndex(
                name: "IX_Insumos_IdCategoria",
                table: "Insumos");

            migrationBuilder.DropIndex(
                name: "IX_Insumos_IdUsuario",
                table: "Insumos");

            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "Insumos",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Insumos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Insumos_CategoriaId",
                table: "Insumos",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Insumos_UsuarioId",
                table: "Insumos",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Insumos_Categorias_CategoriaId",
                table: "Insumos",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Insumos_Usuarios_UsuarioId",
                table: "Insumos",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
