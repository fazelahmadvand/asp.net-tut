﻿// <auto-generated />
using Bulky.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bulky.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231029101115_addImageUrlToProduct")]
    partial class addImageUrlToProduct
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-rc.2.23480.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Bulky.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DisplayIndex")
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
                            DisplayIndex = 1,
                            Name = "Action"
                        },
                        new
                        {
                            Id = 2,
                            DisplayIndex = 2,
                            Name = "SciFi"
                        },
                        new
                        {
                            Id = 3,
                            DisplayIndex = 3,
                            Name = "History"
                        });
                });

            modelBuilder.Entity("Bulky.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ListPrice")
                        .HasColumnType("float");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<double>("Price100")
                        .HasColumnType("float");

                    b.Property<double>("Price50")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "John Wick",
                            CategoryId = 1,
                            Description = "How you doing?",
                            ISBN = "SWD132309",
                            ImageUrl = "",
                            ListPrice = 99.0,
                            Price = 95.0,
                            Price100 = 85.0,
                            Price50 = 90.0,
                            Title = "First Book"
                        },
                        new
                        {
                            Id = 2,
                            Author = "IDK",
                            CategoryId = 1,
                            Description = "Some Day You Will Have It Too",
                            ISBN = "SJKCPE2309",
                            ImageUrl = "",
                            ListPrice = 97.0,
                            Price = 92.0,
                            Price100 = 82.0,
                            Price50 = 87.0,
                            Title = "Love Book"
                        },
                        new
                        {
                            Id = 3,
                            Author = "A Man Life",
                            CategoryId = 1,
                            Description = "A Man Will Do Everything For When Someone Enter His Life Be Good",
                            ISBN = "SWKVLR09",
                            ImageUrl = "",
                            ListPrice = 79.0,
                            Price = 65.0,
                            Price100 = 55.0,
                            Price50 = 60.0,
                            Title = "Work"
                        });
                });

            modelBuilder.Entity("Bulky.Models.Product", b =>
                {
                    b.HasOne("Bulky.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}
