using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalManagement.Migrations
{
    /// <inheritdoc />
    public partial class changeIdStringDatLichNew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoSo_DanToc_IdDanToc",
                table: "HoSo");

            migrationBuilder.DropForeignKey(
                name: "FK_HoSo_NgheNghiep_IdNgheNghiep",
                table: "HoSo");

            migrationBuilder.DropForeignKey(
                name: "FK_HoSo_QuocTich_IdQuocTich",
                table: "HoSo");

            migrationBuilder.AlterColumn<int>(
                name: "IdQuocTich",
                table: "HoSo",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdNgheNghiep",
                table: "HoSo",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdDanToc",
                table: "HoSo",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_HoSo_DanToc_IdDanToc",
                table: "HoSo",
                column: "IdDanToc",
                principalTable: "DanToc",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_HoSo_NgheNghiep_IdNgheNghiep",
                table: "HoSo",
                column: "IdNgheNghiep",
                principalTable: "NgheNghiep",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_HoSo_QuocTich_IdQuocTich",
                table: "HoSo",
                column: "IdQuocTich",
                principalTable: "QuocTich",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoSo_DanToc_IdDanToc",
                table: "HoSo");

            migrationBuilder.DropForeignKey(
                name: "FK_HoSo_NgheNghiep_IdNgheNghiep",
                table: "HoSo");

            migrationBuilder.DropForeignKey(
                name: "FK_HoSo_QuocTich_IdQuocTich",
                table: "HoSo");

            migrationBuilder.AlterColumn<int>(
                name: "IdQuocTich",
                table: "HoSo",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdNgheNghiep",
                table: "HoSo",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdDanToc",
                table: "HoSo",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
    }
}
