﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TeaTimeDemo.DataAccess.Data;

#nullable disable

namespace TeaTimeDemo.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250106063637_addProuductsToDb")]
    partial class addProuductsToDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TeaTimeDemo.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DisplayOrder = 1,
                            Name = "果汁"
                        },
                        new
                        {
                            Id = 2,
                            DisplayOrder = 2,
                            Name = "茶"
                        },
                        new
                        {
                            Id = 3,
                            DisplayOrder = 3,
                            Name = "咖啡"
                        });
                });

            modelBuilder.Entity("TeaTimeDemo.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "天然果飲，迷人多變",
                            Name = "台灣水果茶",
                            Price = 60.0,
                            Size = "大杯"
                        },
                        new
                        {
                            Id = 2,
                            Description = "品鐵觀音，享人生的味道",
                            Name = "鐵觀音",
                            Price = 35.0,
                            Size = "中杯"
                        },
                        new
                        {
                            Id = 3,
                            Description = "用咖啡體悟悠閒時光",
                            Name = "美式咖啡",
                            Price = 50.0,
                            Size = "中杯"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
