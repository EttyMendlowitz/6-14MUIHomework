﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _6_14MUIHomework.Data;

#nullable disable

namespace _6_14MUIHomework.Data.Migrations
{
    [DbContext(typeof(MaaserDb))]
    [Migration("20230619150400_Second")]
    partial class Second
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("_6_14MUIHomework.Data.Income", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("SourceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SourceId");

                    b.ToTable("Income");
                });

            modelBuilder.Entity("_6_14MUIHomework.Data.Maaser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Recipient")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Maaser");
                });

            modelBuilder.Entity("_6_14MUIHomework.Data.Source", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("SourceName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Sources");
                });

            modelBuilder.Entity("_6_14MUIHomework.Data.Income", b =>
                {
                    b.HasOne("_6_14MUIHomework.Data.Source", "Source")
                        .WithMany("Incomes")
                        .HasForeignKey("SourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Source");
                });

            modelBuilder.Entity("_6_14MUIHomework.Data.Source", b =>
                {
                    b.Navigation("Incomes");
                });
#pragma warning restore 612, 618
        }
    }
}
