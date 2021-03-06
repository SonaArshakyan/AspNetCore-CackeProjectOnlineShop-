﻿// <auto-generated />
using AspnetCoreProjectExample.OnlineShop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AspnetCoreProjectExample.OnlineShop.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20201005100307_addNote")]
    partial class addNote
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AspnetCoreProjectExample.OnlineShop.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "Chees cacke"
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "White cacke"
                        },
                        new
                        {
                            CategoryId = 3,
                            CategoryName = "Black cacke"
                        });
                });

            modelBuilder.Entity("AspnetCoreProjectExample.OnlineShop.Models.Pie", b =>
                {
                    b.Property<int>("PieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AllergyInformation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("ImageThumbnailUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("InStock")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPieOfWeek")
                        .HasColumnType("bit");

                    b.Property<string>("LongDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Prices")
                        .HasColumnType("int");

                    b.Property<string>("ShortDescription")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PieId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Pies");

                    b.HasData(
                        new
                        {
                            PieId = 1,
                            CategoryId = 0,
                            ImageUrl = "~/ images / cacke.jpg",
                            InStock = true,
                            IsPieOfWeek = false,
                            LongDescription = "Lorem jan",
                            Name = "Apple Pie",
                            Prices = 12,
                            ShortDescription = "Our Famous apple pies"
                        },
                        new
                        {
                            PieId = 2,
                            CategoryId = 1,
                            ImageUrl = "~/ images / cacke.jpg",
                            InStock = true,
                            IsPieOfWeek = false,
                            LongDescription = "Lorem jan",
                            Name = "Apple Pie",
                            Prices = 12,
                            ShortDescription = "Our Famous apple pies"
                        },
                        new
                        {
                            PieId = 3,
                            CategoryId = 2,
                            ImageUrl = "~/ images / cacke.jpg",
                            InStock = true,
                            IsPieOfWeek = false,
                            LongDescription = "Lorem jan",
                            Name = "Apple Pie",
                            Prices = 12,
                            ShortDescription = "Our Famous apple pies"
                        },
                        new
                        {
                            PieId = 4,
                            CategoryId = 3,
                            ImageUrl = "~/ images / cacke.jpg",
                            InStock = true,
                            IsPieOfWeek = true,
                            LongDescription = "Lorem jan",
                            Name = "Apple Pie",
                            Prices = 12,
                            ShortDescription = "Our Famous apple pies"
                        });
                });

            modelBuilder.Entity("AspnetCoreProjectExample.OnlineShop.Models.Pie", b =>
                {
                    b.HasOne("AspnetCoreProjectExample.OnlineShop.Models.Category", "Category")
                        .WithMany("Pies")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
