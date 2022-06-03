﻿// <auto-generated />
using Menu.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Menu.Migrations
{
    [DbContext(typeof(MenuContext))]
    partial class MenuContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.14")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Menu.Models.Category", b =>
                {
                    b.Property<string>("CategoryId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = "A",
                            Name = "Appetizers"
                        },
                        new
                        {
                            CategoryId = "B",
                            Name = "Burgers"
                        },
                        new
                        {
                            CategoryId = "D",
                            Name = "Desserts"
                        },
                        new
                        {
                            CategoryId = "S",
                            Name = "Sandwiches and Salads"
                        });
                });

            modelBuilder.Entity("Menu.Models.Food", b =>
                {
                    b.Property<int>("FoodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("FoodId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Foods");

                    b.HasData(
                        new
                        {
                            FoodId = 1,
                            CategoryId = "B",
                            Description = "1/2lb Angus Patty Between a Sesame seed bun.",
                            ImagePath = "burger.jpeg",
                            Name = "Cheese Burger",
                            Price = 9.99m
                        },
                        new
                        {
                            FoodId = 2,
                            CategoryId = "S",
                            Description = "Hot Ham and cheese on open faced french bread.",
                            ImagePath = "burger.jpeg",
                            Name = "Open-Face Ham Sandwich",
                            Price = 8.99m
                        },
                        new
                        {
                            FoodId = 3,
                            CategoryId = "S",
                            Description = "Lettuce,Tomatoe,Red Onion, and Artichoke Hearts tossed in Italian Dressing.",
                            ImagePath = "burger.jpeg",
                            Name = "House Salad",
                            Price = 7.99m
                        });
                });

            modelBuilder.Entity("Menu.Models.Food", b =>
                {
                    b.HasOne("Menu.Models.Category", "category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("category");
                });
#pragma warning restore 612, 618
        }
    }
}
