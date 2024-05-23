using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalManagement.Migrations
{
    /// <inheritdoc />
    public partial class UpdateWithDonThuocChiTiet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DonThuocChiTiet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdThuoc = table.Column<int>(type: "int", nullable: false),
                    IdDonThuoc = table.Column<int>(type: "int", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    LieuDung = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonThuocChiTiet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DonThuocChiTiet_DonThuoc_IdDonThuoc",
                        column: x => x.IdDonThuoc,
                        principalTable: "DonThuoc",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DonThuocChiTiet_Thuoc_IdThuoc",
                        column: x => x.IdThuoc,
                        principalTable: "Thuoc",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DonThuoc_idDatLich",
                table: "DonThuoc",
                column: "idDatLich",
                unique: true,
                filter: "[idDatLich] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DonThuocChiTiet_IdDonThuoc",
                table: "DonThuocChiTiet",
                column: "IdDonThuoc");

            migrationBuilder.CreateIndex(
                name: "IX_DonThuocChiTiet_IdThuoc",
                table: "DonThuocChiTiet",
                column: "IdThuoc");

            migrationBuilder.AddForeignKey(
                name: "FK_DonThuoc_DatLich_idDatLich",
                table: "DonThuoc",
                column: "idDatLich",
                principalTable: "DatLich",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DonThuoc_DatLich_idDatLich",
                table: "DonThuoc");

            migrationBuilder.DropTable(
                name: "DonThuocChiTiet");

            migrationBuilder.DropIndex(
                name: "IX_DonThuoc_idDatLich",
                table: "DonThuoc");
        }
    }
}
