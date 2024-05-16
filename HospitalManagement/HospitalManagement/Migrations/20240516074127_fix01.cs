using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalManagement.Migrations
{
    /// <inheritdoc />
    public partial class fix01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "QuocTich",
                table: "DatLich");

            migrationBuilder.RenameColumn(
                name: "SoNha",
                table: "HoSo",
                newName: "Duong");

            migrationBuilder.AddColumn<int>(
                name: "IdDanToc",
                table: "HoSo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdNgheNghiep",
                table: "HoSo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdQuocTich",
                table: "HoSo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ChiTietChuanDoan",
                table: "DatLich",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LoiDan",
                table: "DatLich",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MoTa",
                table: "DatLich",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HoSo_IdDanToc",
                table: "HoSo",
                column: "IdDanToc");

            migrationBuilder.CreateIndex(
                name: "IX_HoSo_IdNgheNghiep",
                table: "HoSo",
                column: "IdNgheNghiep");

            migrationBuilder.CreateIndex(
                name: "IX_HoSo_IdQuocTich",
                table: "HoSo",
                column: "IdQuocTich");

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

            migrationBuilder.AddForeignKey(
                name: "FK_HoSo_DanToc_IdDanToc",
                table: "HoSo",
                column: "IdDanToc",
                principalTable: "DanToc",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HoSo_NgheNghiep_IdNgheNghiep",
                table: "HoSo",
                column: "IdNgheNghiep",
                principalTable: "NgheNghiep",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HoSo_QuocTich_IdQuocTich",
                table: "HoSo",
                column: "IdQuocTich",
                principalTable: "QuocTich",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DatLich_PhongPham_IdPhong",
                table: "DatLich");

            migrationBuilder.DropForeignKey(
                name: "FK_HoSo_DanToc_IdDanToc",
                table: "HoSo");

            migrationBuilder.DropForeignKey(
                name: "FK_HoSo_NgheNghiep_IdNgheNghiep",
                table: "HoSo");

            migrationBuilder.DropForeignKey(
                name: "FK_HoSo_QuocTich_IdQuocTich",
                table: "HoSo");

            migrationBuilder.DropIndex(
                name: "IX_HoSo_IdDanToc",
                table: "HoSo");

            migrationBuilder.DropIndex(
                name: "IX_HoSo_IdNgheNghiep",
                table: "HoSo");

            migrationBuilder.DropIndex(
                name: "IX_HoSo_IdQuocTich",
                table: "HoSo");

            migrationBuilder.DropIndex(
                name: "IX_DatLich_IdPhong",
                table: "DatLich");

            migrationBuilder.DropColumn(
                name: "IdDanToc",
                table: "HoSo");

            migrationBuilder.DropColumn(
                name: "IdNgheNghiep",
                table: "HoSo");

            migrationBuilder.DropColumn(
                name: "IdQuocTich",
                table: "HoSo");

            migrationBuilder.DropColumn(
                name: "ChiTietChuanDoan",
                table: "DatLich");

            migrationBuilder.DropColumn(
                name: "LoiDan",
                table: "DatLich");

            migrationBuilder.DropColumn(
                name: "MoTa",
                table: "DatLich");

            migrationBuilder.RenameColumn(
                name: "Duong",
                table: "HoSo",
                newName: "SoNha");

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

            migrationBuilder.AddColumn<string>(
                name: "QuocTich",
                table: "DatLich",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true);

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
    }
}
