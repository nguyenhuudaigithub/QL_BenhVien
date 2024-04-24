﻿// <auto-generated />
using System;
using HospitalManagement.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HospitalManagement.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240424021546_DatLich")]
    partial class DatLich
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HospitalManagement.Data.DatLich", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("DanToc")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("GioKham")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("IdPhong")
                        .HasMaxLength(11)
                        .HasColumnType("int");

                    b.Property<string>("MaHoSo")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("NgayKham")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<string>("NgheNghiep")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("QuocTich")
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("id");

                    b.HasIndex("IdPhong")
                        .IsUnique();

                    b.HasIndex("MaHoSo");

                    b.ToTable("DatLich");
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

                    b.Property<int>("IdHuyen")
                        .HasMaxLength(5)
                        .HasColumnType("int");

                    b.Property<int>("IdTinh")
                        .HasMaxLength(5)
                        .HasColumnType("int");

                    b.Property<int>("IdXa")
                        .HasMaxLength(5)
                        .HasColumnType("int");

                    b.Property<DateTime>("NgaySinh")
                        .HasColumnType("datetime2");

                    b.Property<string>("SDT")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("SoNha")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("MaHoSo");

                    b.ToTable("HoSo");
                });

            modelBuilder.Entity("HospitalManagement.Data.PhongKham", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(11)
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("TenPhongKham")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("PhongPham");
                });

            modelBuilder.Entity("HospitalManagement.Data.DatLich", b =>
                {
                    b.HasOne("HospitalManagement.Data.PhongKham", "PhongKham")
                        .WithOne("DatLich")
                        .HasForeignKey("HospitalManagement.Data.DatLich", "IdPhong")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("HospitalManagement.Data.HoSo", "HoSo")
                        .WithMany("DatLichs")
                        .HasForeignKey("MaHoSo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HoSo");

                    b.Navigation("PhongKham");
                });

            modelBuilder.Entity("HospitalManagement.Data.HoSo", b =>
                {
                    b.Navigation("DatLichs");
                });

            modelBuilder.Entity("HospitalManagement.Data.PhongKham", b =>
                {
                    b.Navigation("DatLich")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
