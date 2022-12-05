﻿// <auto-generated />
using System;
using APISchool.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace APISchool.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20221201035431_AddKhoa")]
    partial class AddKhoa
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("APISchool.Entity.Diem", b =>
                {
                    b.Property<string>("MaDiem")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("DiemThi")
                        .HasColumnType("float");

                    b.Property<string>("MaMon")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MaSV")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("MaDiem");

                    b.HasIndex("MaMon");

                    b.HasIndex("MaSV");

                    b.ToTable("Diems");
                });

            modelBuilder.Entity("APISchool.Entity.Khoa", b =>
                {
                    b.Property<string>("MaKhoa")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TenKhoa")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("MaKhoa");

                    b.ToTable("Khoas");
                });

            modelBuilder.Entity("APISchool.Entity.Lop", b =>
                {
                    b.Property<string>("MaLop")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MaKhoa")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("SiSo")
                        .HasColumnType("int");

                    b.Property<string>("TenLop")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("MaLop");

                    b.HasIndex("MaKhoa");

                    b.ToTable("Lops");
                });

            modelBuilder.Entity("APISchool.Entity.MonHoc", b =>
                {
                    b.Property<string>("MaMon")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TenMon")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("TinChi")
                        .HasColumnType("int");

                    b.HasKey("MaMon");

                    b.ToTable("MonHocs");
                });

            modelBuilder.Entity("APISchool.Entity.SinhVien", b =>
                {
                    b.Property<string>("MaSV")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("GioiTinh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MaLop")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("NgaySinh")
                        .HasColumnType("datetime2");

                    b.Property<string>("QueQuan")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("TenSV")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("MaSV");

                    b.HasIndex("MaLop");

                    b.ToTable("SinhViens");
                });

            modelBuilder.Entity("APISchool.Entity.Diem", b =>
                {
                    b.HasOne("APISchool.Entity.MonHoc", "MonHocs")
                        .WithMany("Diems")
                        .HasForeignKey("MaMon")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APISchool.Entity.SinhVien", "SinhViens")
                        .WithMany("Diems")
                        .HasForeignKey("MaSV")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MonHocs");

                    b.Navigation("SinhViens");
                });

            modelBuilder.Entity("APISchool.Entity.Lop", b =>
                {
                    b.HasOne("APISchool.Entity.Khoa", "Khoas")
                        .WithMany("Lops")
                        .HasForeignKey("MaKhoa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Khoas");
                });

            modelBuilder.Entity("APISchool.Entity.SinhVien", b =>
                {
                    b.HasOne("APISchool.Entity.Lop", "Lops")
                        .WithMany("SinhViens")
                        .HasForeignKey("MaLop")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lops");
                });

            modelBuilder.Entity("APISchool.Entity.Khoa", b =>
                {
                    b.Navigation("Lops");
                });

            modelBuilder.Entity("APISchool.Entity.Lop", b =>
                {
                    b.Navigation("SinhViens");
                });

            modelBuilder.Entity("APISchool.Entity.MonHoc", b =>
                {
                    b.Navigation("Diems");
                });

            modelBuilder.Entity("APISchool.Entity.SinhVien", b =>
                {
                    b.Navigation("Diems");
                });
#pragma warning restore 612, 618
        }
    }
}
