using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalManagement.Migrations
{
    /// <inheritdoc />
    public partial class changeIdStringDatLich : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "PhongPham",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", maxLength: 11, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoLuongToiDa = table.Column<int>(type: "int", nullable: false),
                    TenPhongKham = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhongPham", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "QuocTich",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", maxLength: 11, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenQuocTich = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenVietTat = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuocTich", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "HoSo",
                columns: table => new
                {
                    MaHoSo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CCCD = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    HoDem = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    SDT = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    GioiTinh = table.Column<bool>(type: "bit", nullable: false),
                    IdPhuong = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Duong = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    NgayTaoHoSo = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdQuocTich = table.Column<int>(type: "int", nullable: false),
                    IdNgheNghiep = table.Column<int>(type: "int", nullable: false),
                    IdDanToc = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoSo", x => x.MaHoSo);
                    table.ForeignKey(
                        name: "FK_HoSo_DanToc_IdDanToc",
                        column: x => x.IdDanToc,
                        principalTable: "DanToc",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HoSo_NgheNghiep_IdNgheNghiep",
                        column: x => x.IdNgheNghiep,
                        principalTable: "NgheNghiep",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HoSo_QuocTich_IdQuocTich",
                        column: x => x.IdQuocTich,
                        principalTable: "QuocTich",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DatLich",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", maxLength: 100, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    STT = table.Column<int>(type: "int", nullable: false),
                    NgayKham = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdPhong = table.Column<int>(type: "int", maxLength: 11, nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GioKham = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChiTietChuanDoan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoiDan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaHoSo = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatLich", x => x.id);
                    table.ForeignKey(
                        name: "FK_DatLich_HoSo_MaHoSo",
                        column: x => x.MaHoSo,
                        principalTable: "HoSo",
                        principalColumn: "MaHoSo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DatLich_PhongPham_IdPhong",
                        column: x => x.IdPhong,
                        principalTable: "PhongPham",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DatLich_IdPhong",
                table: "DatLich",
                column: "IdPhong");

            migrationBuilder.CreateIndex(
                name: "IX_DatLich_MaHoSo",
                table: "DatLich",
                column: "MaHoSo");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DatLich");

            migrationBuilder.DropTable(
                name: "HoSo");

            migrationBuilder.DropTable(
                name: "PhongPham");

            migrationBuilder.DropTable(
                name: "DanToc");

            migrationBuilder.DropTable(
                name: "NgheNghiep");

            migrationBuilder.DropTable(
                name: "QuocTich");
        }
    }
}
