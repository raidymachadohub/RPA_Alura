﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RPA.Alura.Infrastructure.Context;

#nullable disable

namespace RPA.Alura.Infrastructure.Migrations.Entities
{
    [DbContext(typeof(RPAContext))]
    [Migration("20230606214556_InicioBancoDeDados")]
    partial class InicioBancoDeDados
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.16");

            modelBuilder.Entity("RPA.Alura.Domain.Model.Courses", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long>("IdRoutine")
                        .HasColumnType("INTEGER")
                        .HasColumnName("IdRoutine");

                    b.Property<string>("Teacher")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("WorkLoad")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("IdRoutine");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("RPA.Alura.Domain.Model.Routine", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Active")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TitleSearch")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Routine");
                });

            modelBuilder.Entity("RPA.Alura.Domain.Model.Courses", b =>
                {
                    b.HasOne("RPA.Alura.Domain.Model.Routine", "Routine")
                        .WithMany()
                        .HasForeignKey("IdRoutine")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Routine");
                });
#pragma warning restore 612, 618
        }
    }
}