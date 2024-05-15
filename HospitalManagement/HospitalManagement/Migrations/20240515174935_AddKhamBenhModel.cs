using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalManagement.Migrations
{
    /// <inheritdoc />
    public partial class AddKhamBenhModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdHuyen",
                table: "HoSo");

            migrationBuilder.DropColumn(
                name: "IdTinh",
                table: "HoSo");

            migrationBuilder.AddColumn<int>(
                name: "SoLuongToiDa",
                table: "PhongPham",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "STT",
                table: "DatLich",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "KhamBenhs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaHoSo = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    IdPhongKham = table.Column<int>(type: "int", nullable: false),
                    ThoiGianHen = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayKham = table.Column<DateTime>(type: "datetime2", nullable: false),
                    STT = table.Column<int>(type: "int", nullable: false),
                    Mota = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChiTietChuanDoan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoiDan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdBacSi = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhamBenhs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KhamBenhs_HoSo_MaHoSo",
                        column: x => x.MaHoSo,
                        principalTable: "HoSo",
                        principalColumn: "MaHoSo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KhamBenhs_PhongPham_IdPhongKham",
                        column: x => x.IdPhongKham,
                        principalTable: "PhongPham",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KhamBenhs_IdPhongKham",
                table: "KhamBenhs",
                column: "IdPhongKham");

            migrationBuilder.CreateIndex(
                name: "IX_KhamBenhs_MaHoSo",
                table: "KhamBenhs",
                column: "MaHoSo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KhamBenhs");

            migrationBuilder.DropColumn(
                name: "SoLuongToiDa",
                table: "PhongPham");

            migrationBuilder.DropColumn(
                name: "STT",
                table: "DatLich");

            migrationBuilder.AddColumn<int>(
                name: "IdHuyen",
                table: "HoSo",
                type: "int",
                maxLength: 5,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdTinh",
                table: "HoSo",
                type: "int",
                maxLength: 5,
                nullable: false,
                defaultValue: 0);
        }
    }
}
