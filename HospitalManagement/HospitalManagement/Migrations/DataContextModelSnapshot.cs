﻿// <auto-generated />
using System;
using HospitalManagement.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HospitalManagement.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HospitalManagement.Data.DanToc", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(11)
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("TenDanToc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("DanToc");
                });

            modelBuilder.Entity("HospitalManagement.Data.DatLich", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(100)
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("ChiTietChuanDoan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GioKham")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("IdPhong")
                        .HasMaxLength(11)
                        .HasColumnType("int");

                    b.Property<string>("LoiDan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MaHoSo")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("MoTa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NgayKham")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<int>("STT")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("IdPhong");

                    b.HasIndex("MaHoSo");

                    b.ToTable("DatLich");
                });

            modelBuilder.Entity("HospitalManagement.Data.DonThuoc", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("idBacSi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("idDatLich")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("idDatLich")
                        .IsUnique()
                        .HasFilter("[idDatLich] IS NOT NULL");

                    b.ToTable("DonThuoc");
                });

            modelBuilder.Entity("HospitalManagement.Data.DonThuocChiTiet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IdDonThuoc")
                        .HasColumnType("int");

                    b.Property<int>("IdThuoc")
                        .HasColumnType("int");

                    b.Property<string>("LieuDung")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdDonThuoc");

                    b.HasIndex("IdThuoc");

                    b.ToTable("DonThuocChiTiet");
                });

            modelBuilder.Entity("HospitalManagement.Data.HoSo", b =>
                {
                    b.Property<string>("MaHoSo")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("CCCD")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("Duong")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<bool>("GioiTinh")
                        .HasColumnType("bit");

                    b.Property<string>("HoDem")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<int?>("IdDanToc")
                        .HasColumnType("int");

                    b.Property<int?>("IdNgheNghiep")
                        .HasColumnType("int");

                    b.Property<string>("IdPhuong")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<int?>("IdQuocTich")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgaySinh")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayTaoHoSo")
                        .HasColumnType("datetime2");

                    b.Property<string>("SDT")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("MaHoSo");

                    b.HasIndex("IdDanToc");

                    b.HasIndex("IdNgheNghiep");

                    b.HasIndex("IdQuocTich");

                    b.ToTable("HoSo");
                });

            modelBuilder.Entity("HospitalManagement.Data.NgheNghiep", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(11)
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("TenNgheNghiep")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("NgheNghiep");
                });

            modelBuilder.Entity("HospitalManagement.Data.PhongKham", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(11)
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("SoLuongToiDa")
                        .HasColumnType("int");

                    b.Property<string>("TenPhongKham")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("PhongPham");
                });

            modelBuilder.Entity("HospitalManagement.Data.QuocTich", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(11)
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("TenQuocTich")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenVietTat")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("QuocTich");
                });

            modelBuilder.Entity("HospitalManagement.Data.Thuoc", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(11)
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<decimal>("GiaTien")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("SoLuongConLai")
                        .HasColumnType("int");

                    b.Property<string>("TenThuoc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Thuoc");
                });

            modelBuilder.Entity("HospitalManagement.Data.DatLich", b =>
                {
                    b.HasOne("HospitalManagement.Data.PhongKham", "PhongKham")
                        .WithMany("DatLichs")
                        .HasForeignKey("IdPhong")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HospitalManagement.Data.HoSo", "HoSo")
                        .WithMany("DatLichs")
                        .HasForeignKey("MaHoSo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HoSo");

                    b.Navigation("PhongKham");
                });

            modelBuilder.Entity("HospitalManagement.Data.DonThuoc", b =>
                {
                    b.HasOne("HospitalManagement.Data.DatLich", "DatLich")
                        .WithOne("DonThuoc")
                        .HasForeignKey("HospitalManagement.Data.DonThuoc", "idDatLich");

                    b.Navigation("DatLich");
                });

            modelBuilder.Entity("HospitalManagement.Data.DonThuocChiTiet", b =>
                {
                    b.HasOne("HospitalManagement.Data.DonThuoc", "DonThuoc")
                        .WithMany("DonThuocChiTiets")
                        .HasForeignKey("IdDonThuoc")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HospitalManagement.Data.Thuoc", "Thuoc")
                        .WithMany("DonThuocChiTiets")
                        .HasForeignKey("IdThuoc")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DonThuoc");

                    b.Navigation("Thuoc");
                });

            modelBuilder.Entity("HospitalManagement.Data.HoSo", b =>
                {
                    b.HasOne("HospitalManagement.Data.DanToc", "DanToc")
                        .WithMany()
                        .HasForeignKey("IdDanToc");

                    b.HasOne("HospitalManagement.Data.NgheNghiep", "NgheNghiep")
                        .WithMany()
                        .HasForeignKey("IdNgheNghiep");

                    b.HasOne("HospitalManagement.Data.QuocTich", "QuocTich")
                        .WithMany()
                        .HasForeignKey("IdQuocTich");

                    b.Navigation("DanToc");

                    b.Navigation("NgheNghiep");

                    b.Navigation("QuocTich");
                });

            modelBuilder.Entity("HospitalManagement.Data.DatLich", b =>
                {
                    b.Navigation("DonThuoc")
                        .IsRequired();
                });

            modelBuilder.Entity("HospitalManagement.Data.DonThuoc", b =>
                {
                    b.Navigation("DonThuocChiTiets");
                });

            modelBuilder.Entity("HospitalManagement.Data.HoSo", b =>
                {
                    b.Navigation("DatLichs");
                });

            modelBuilder.Entity("HospitalManagement.Data.PhongKham", b =>
                {
                    b.Navigation("DatLichs");
                });

            modelBuilder.Entity("HospitalManagement.Data.Thuoc", b =>
                {
                    b.Navigation("DonThuocChiTiets");
                });
#pragma warning restore 612, 618
        }
    }
}
