using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalManagement.Migrations
{
    /// <inheritdoc />
    public partial class DanTocDB_NgheNghiepDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DatLich_PhongPham_IdPhong",
                table: "DatLich");

            migrationBuilder.DropIndex(
                name: "IX_DatLich_IdPhong",
                table: "DatLich");

            migrationBuilder.DropColumn(
                name: "DanToc",
                table: "DatLich");

            migrationBuilder.DropColumn(
                name: "NgheNghiep",
                table: "DatLich");

            migrationBuilder.AddColumn<int>(
                name: "IdDanToc",
                table: "DatLich",
                type: "int",
                maxLength: 11,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdNgheNghiep",
                table: "DatLich",
                type: "int",
                maxLength: 11,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DanToc",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", maxLength: 11, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenDanToc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanToc", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "NgheNghiep",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", maxLength: 11, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenNgheNghiep = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NgheNghiep", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DatLich_IdDanToc",
                table: "DatLich",
                column: "IdDanToc",
                unique: true,
                filter: "[IdDanToc] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DatLich_IdNgheNghiep",
                table: "DatLich",
                column: "IdNgheNghiep",
                unique: true,
                filter: "[IdNgheNghiep] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_DatLich_DanToc_IdDanToc",
                table: "DatLich",
                column: "IdDanToc",
                principalTable: "DanToc",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DatLich_NgheNghiep_IdNgheNghiep",
                table: "DatLich",
                column: "IdNgheNghiep",
                principalTable: "NgheNghiep",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_DatLich_PhongPham_IdNgheNghiep",
                table: "DatLich",
                column: "IdNgheNghiep",
                principalTable: "PhongPham",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DatLich_DanToc_IdDanToc",
                table: "DatLich");

            migrationBuilder.DropForeignKey(
                name: "FK_DatLich_NgheNghiep_IdNgheNghiep",
                table: "DatLich");

            migrationBuilder.DropForeignKey(
                name: "FK_DatLich_PhongPham_IdNgheNghiep",
                table: "DatLich");

            migrationBuilder.DropTable(
                name: "DanToc");

            migrationBuilder.DropTable(
                name: "NgheNghiep");

            migrationBuilder.DropIndex(
                name: "IX_DatLich_IdDanToc",
                table: "DatLich");

            migrationBuilder.DropIndex(
                name: "IX_DatLich_IdNgheNghiep",
                table: "DatLich");

            migrationBuilder.DropColumn(
                name: "IdDanToc",
                table: "DatLich");

            migrationBuilder.DropColumn(
                name: "IdNgheNghiep",
                table: "DatLich");

            migrationBuilder.AddColumn<string>(
                name: "DanToc",
                table: "DatLich",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NgheNghiep",
                table: "DatLich",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DatLich_IdPhong",
                table: "DatLich",
                column: "IdPhong",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DatLich_PhongPham_IdPhong",
                table: "DatLich",
                column: "IdPhong",
                principalTable: "PhongPham",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
