﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Papu.Entities;

namespace Papu.Migrations
{
    [DbContext(typeof(PapuDbContext))]
    partial class PapuDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Papu.Entities.Breakfast", b =>
                {
                    b.Property<int>("BreakfastId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("BreakfastId");

                    b.ToTable("Breakfasts");
                });

            modelBuilder.Entity("Papu.Entities.BreakfastDish", b =>
                {
                    b.Property<int>("BreakfastId")
                        .HasColumnType("int");

                    b.Property<int>("DishId")
                        .HasColumnType("int");

                    b.HasKey("BreakfastId", "DishId");

                    b.HasIndex("DishId");

                    b.ToTable("DishBreakfasts");
                });

            modelBuilder.Entity("Papu.Entities.BreakfastProduct", b =>
                {
                    b.Property<int>("BreakfastId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("BreakfastId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductBreakfasts");
                });

            modelBuilder.Entity("Papu.Entities.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Papu.Entities.Dinner", b =>
                {
                    b.Property<int>("DinnerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("DinnerId");

                    b.ToTable("Dinners");
                });

            modelBuilder.Entity("Papu.Entities.DinnerDish", b =>
                {
                    b.Property<int>("DinnerId")
                        .HasColumnType("int");

                    b.Property<int>("DishId")
                        .HasColumnType("int");

                    b.HasKey("DinnerId", "DishId");

                    b.HasIndex("DishId");

                    b.ToTable("DinnerDishes");
                });

            modelBuilder.Entity("Papu.Entities.DinnerProduct", b =>
                {
                    b.Property<int>("DinnerId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("DinnerId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("DinnerProducts");
                });

            modelBuilder.Entity("Papu.Entities.Dish", b =>
                {
                    b.Property<int>("DishId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DishDescription")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("DishImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DishName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("MethodOfPeparation")
                        .IsRequired()
                        .HasMaxLength(1300)
                        .HasColumnType("nvarchar(1300)");

                    b.Property<int>("Portions")
                        .HasMaxLength(3)
                        .HasColumnType("int");

                    b.Property<int>("PreparationTime")
                        .HasMaxLength(3)
                        .HasColumnType("int");

                    b.Property<int>("Size")
                        .HasMaxLength(3)
                        .HasColumnType("int");

                    b.HasKey("DishId");

                    b.ToTable("Dishes");
                });

            modelBuilder.Entity("Papu.Entities.DishKindOf", b =>
                {
                    b.Property<int>("DishId")
                        .HasColumnType("int");

                    b.Property<int>("KindOfId")
                        .HasColumnType("int");

                    b.HasKey("DishId", "KindOfId");

                    b.HasIndex("KindOfId");

                    b.ToTable("DishKindsOf");
                });

            modelBuilder.Entity("Papu.Entities.DishType", b =>
                {
                    b.Property<int>("DishId")
                        .HasColumnType("int");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("DishId", "TypeId");

                    b.HasIndex("TypeId");

                    b.ToTable("DishTypes");
                });

            modelBuilder.Entity("Papu.Entities.Group", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GroupName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GroupId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("Papu.Entities.KindOf", b =>
                {
                    b.Property<int>("KindOfId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("KindOfName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KindOfId");

                    b.ToTable("KindsOf");
                });

            modelBuilder.Entity("Papu.Entities.Lunch", b =>
                {
                    b.Property<int>("LunchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("LunchId");

                    b.ToTable("Lunches");
                });

            modelBuilder.Entity("Papu.Entities.LunchDish", b =>
                {
                    b.Property<int>("LunchId")
                        .HasColumnType("int");

                    b.Property<int>("DishId")
                        .HasColumnType("int");

                    b.HasKey("LunchId", "DishId");

                    b.HasIndex("DishId");

                    b.ToTable("LunchDishes");
                });

            modelBuilder.Entity("Papu.Entities.LunchProduct", b =>
                {
                    b.Property<int>("LunchId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("LunchId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("LunchProducts");
                });

            modelBuilder.Entity("Papu.Entities.Menu", b =>
                {
                    b.Property<int?>("MenuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MenuDescription")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("MenuName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("MenuId");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("Papu.Entities.Monday", b =>
                {
                    b.Property<int>("MondayId")
                        .HasColumnType("int");

                    b.Property<int>("BreakfastMonday")
                        .HasColumnType("int");

                    b.Property<int>("DinnerMonday")
                        .HasColumnType("int");

                    b.Property<int>("LunchMonday")
                        .HasColumnType("int");

                    b.Property<int>("SecondBreakfastMonday")
                        .HasColumnType("int");

                    b.Property<int>("SnackMonday")
                        .HasColumnType("int");

                    b.HasKey("MondayId");

                    b.ToTable("Mondays");
                });

            modelBuilder.Entity("Papu.Entities.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("ProductImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("UnitId")
                        .HasColumnType("int");

                    b.Property<decimal>("Weight")
                        .HasMaxLength(8)
                        .HasColumnType("decimal(7,2)");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UnitId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Papu.Entities.ProductDish", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("DishId")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "DishId");

                    b.HasIndex("DishId");

                    b.ToTable("DishProducts");
                });

            modelBuilder.Entity("Papu.Entities.ProductGroup", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "GroupId");

                    b.HasIndex("GroupId");

                    b.ToTable("ProductGroups");
                });

            modelBuilder.Entity("Papu.Entities.SecondBreakfast", b =>
                {
                    b.Property<int>("SecondBreakfastId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("SecondBreakfastId");

                    b.ToTable("SecondBreakfasts");
                });

            modelBuilder.Entity("Papu.Entities.SecondBreakfastDish", b =>
                {
                    b.Property<int>("SecondBreakfastId")
                        .HasColumnType("int");

                    b.Property<int>("DishId")
                        .HasColumnType("int");

                    b.HasKey("SecondBreakfastId", "DishId");

                    b.HasIndex("DishId");

                    b.ToTable("DishSecondBreakfasts");
                });

            modelBuilder.Entity("Papu.Entities.SecondBreakfastProduct", b =>
                {
                    b.Property<int>("SecondBreakfastId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("SecondBreakfastId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductSecondBreakfasts");
                });

            modelBuilder.Entity("Papu.Entities.Snack", b =>
                {
                    b.Property<int>("SnackId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("SnackId");

                    b.ToTable("Snacks");
                });

            modelBuilder.Entity("Papu.Entities.SnackDish", b =>
                {
                    b.Property<int>("SnackId")
                        .HasColumnType("int");

                    b.Property<int>("DishId")
                        .HasColumnType("int");

                    b.HasKey("SnackId", "DishId");

                    b.HasIndex("DishId");

                    b.ToTable("SnackDishes");
                });

            modelBuilder.Entity("Papu.Entities.SnackProduct", b =>
                {
                    b.Property<int>("SnackId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("SnackId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("SnackProducts");
                });

            modelBuilder.Entity("Papu.Entities.Type", b =>
                {
                    b.Property<int>("TypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TypeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TypeId");

                    b.ToTable("Types");
                });

            modelBuilder.Entity("Papu.Entities.Unit", b =>
                {
                    b.Property<int>("UnitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UnitName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UnitId");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("Papu.Entities.BreakfastDish", b =>
                {
                    b.HasOne("Papu.Entities.Breakfast", "Breakfast")
                        .WithMany("Dishes")
                        .HasForeignKey("BreakfastId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Papu.Entities.Dish", "Dish")
                        .WithMany("BreakfastDishes")
                        .HasForeignKey("DishId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Breakfast");

                    b.Navigation("Dish");
                });

            modelBuilder.Entity("Papu.Entities.BreakfastProduct", b =>
                {
                    b.HasOne("Papu.Entities.Breakfast", "Breakfast")
                        .WithMany("Products")
                        .HasForeignKey("BreakfastId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Papu.Entities.Product", "Product")
                        .WithMany("BreakfastProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Breakfast");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Papu.Entities.DinnerDish", b =>
                {
                    b.HasOne("Papu.Entities.Dinner", "Dinner")
                        .WithMany("Dishes")
                        .HasForeignKey("DinnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Papu.Entities.Dish", "Dish")
                        .WithMany("DinnerDishes")
                        .HasForeignKey("DishId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dinner");

                    b.Navigation("Dish");
                });

            modelBuilder.Entity("Papu.Entities.DinnerProduct", b =>
                {
                    b.HasOne("Papu.Entities.Dinner", "Dinner")
                        .WithMany("Products")
                        .HasForeignKey("DinnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Papu.Entities.Product", "Product")
                        .WithMany("DinnerProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dinner");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Papu.Entities.DishKindOf", b =>
                {
                    b.HasOne("Papu.Entities.Dish", "Dish")
                        .WithMany("DishKindsOf")
                        .HasForeignKey("DishId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Papu.Entities.KindOf", "KindOf")
                        .WithMany("DishKindsOf")
                        .HasForeignKey("KindOfId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dish");

                    b.Navigation("KindOf");
                });

            modelBuilder.Entity("Papu.Entities.DishType", b =>
                {
                    b.HasOne("Papu.Entities.Dish", "Dish")
                        .WithMany("DishTypes")
                        .HasForeignKey("DishId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Papu.Entities.Type", "Type")
                        .WithMany("DishTypes")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dish");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("Papu.Entities.LunchDish", b =>
                {
                    b.HasOne("Papu.Entities.Dish", "Dish")
                        .WithMany("LunchDishes")
                        .HasForeignKey("DishId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Papu.Entities.Lunch", "Lunch")
                        .WithMany("Dishes")
                        .HasForeignKey("LunchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dish");

                    b.Navigation("Lunch");
                });

            modelBuilder.Entity("Papu.Entities.LunchProduct", b =>
                {
                    b.HasOne("Papu.Entities.Lunch", "Lunch")
                        .WithMany("Products")
                        .HasForeignKey("LunchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Papu.Entities.Product", "Product")
                        .WithMany("LunchProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lunch");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Papu.Entities.Monday", b =>
                {
                    b.HasOne("Papu.Entities.Breakfast", "Breakfast")
                        .WithOne("Monday")
                        .HasForeignKey("Papu.Entities.Monday", "MondayId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Papu.Entities.Dinner", "Dinner")
                        .WithOne("Monday")
                        .HasForeignKey("Papu.Entities.Monday", "MondayId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Papu.Entities.Lunch", "Lunch")
                        .WithOne("Monday")
                        .HasForeignKey("Papu.Entities.Monday", "MondayId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Papu.Entities.SecondBreakfast", "SecondBreakfast")
                        .WithOne("Monday")
                        .HasForeignKey("Papu.Entities.Monday", "MondayId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Papu.Entities.Snack", "Snack")
                        .WithOne("Monday")
                        .HasForeignKey("Papu.Entities.Monday", "MondayId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Breakfast");

                    b.Navigation("Dinner");

                    b.Navigation("Lunch");

                    b.Navigation("SecondBreakfast");

                    b.Navigation("Snack");
                });

            modelBuilder.Entity("Papu.Entities.Product", b =>
                {
                    b.HasOne("Papu.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Papu.Entities.Unit", "Unit")
                        .WithMany("Products")
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Category");

                    b.Navigation("Unit");
                });

            modelBuilder.Entity("Papu.Entities.ProductDish", b =>
                {
                    b.HasOne("Papu.Entities.Dish", "Dish")
                        .WithMany("DishProducts")
                        .HasForeignKey("DishId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Papu.Entities.Product", "Product")
                        .WithMany("DishProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dish");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Papu.Entities.ProductGroup", b =>
                {
                    b.HasOne("Papu.Entities.Group", "Group")
                        .WithMany("ProductGroups")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Papu.Entities.Product", "Product")
                        .WithMany("ProductGroups")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Papu.Entities.SecondBreakfastDish", b =>
                {
                    b.HasOne("Papu.Entities.Dish", "Dish")
                        .WithMany("SecondBreakfastDishes")
                        .HasForeignKey("DishId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Papu.Entities.SecondBreakfast", "SecondBreakfast")
                        .WithMany("Dishes")
                        .HasForeignKey("SecondBreakfastId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dish");

                    b.Navigation("SecondBreakfast");
                });

            modelBuilder.Entity("Papu.Entities.SecondBreakfastProduct", b =>
                {
                    b.HasOne("Papu.Entities.Product", "Product")
                        .WithMany("SecondBreakfastProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Papu.Entities.SecondBreakfast", "SecondBreakfast")
                        .WithMany("Products")
                        .HasForeignKey("SecondBreakfastId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("SecondBreakfast");
                });

            modelBuilder.Entity("Papu.Entities.SnackDish", b =>
                {
                    b.HasOne("Papu.Entities.Dish", "Dish")
                        .WithMany("SnackDishes")
                        .HasForeignKey("DishId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Papu.Entities.Snack", "Snack")
                        .WithMany("Dishes")
                        .HasForeignKey("SnackId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dish");

                    b.Navigation("Snack");
                });

            modelBuilder.Entity("Papu.Entities.SnackProduct", b =>
                {
                    b.HasOne("Papu.Entities.Product", "Product")
                        .WithMany("SnackProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Papu.Entities.Snack", "Snack")
                        .WithMany("Products")
                        .HasForeignKey("SnackId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Snack");
                });

            modelBuilder.Entity("Papu.Entities.Breakfast", b =>
                {
                    b.Navigation("Dishes");

                    b.Navigation("Monday");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("Papu.Entities.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Papu.Entities.Dinner", b =>
                {
                    b.Navigation("Dishes");

                    b.Navigation("Monday");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("Papu.Entities.Dish", b =>
                {
                    b.Navigation("BreakfastDishes");

                    b.Navigation("DinnerDishes");

                    b.Navigation("DishKindsOf");

                    b.Navigation("DishProducts");

                    b.Navigation("DishTypes");

                    b.Navigation("LunchDishes");

                    b.Navigation("SecondBreakfastDishes");

                    b.Navigation("SnackDishes");
                });

            modelBuilder.Entity("Papu.Entities.Group", b =>
                {
                    b.Navigation("ProductGroups");
                });

            modelBuilder.Entity("Papu.Entities.KindOf", b =>
                {
                    b.Navigation("DishKindsOf");
                });

            modelBuilder.Entity("Papu.Entities.Lunch", b =>
                {
                    b.Navigation("Dishes");

                    b.Navigation("Monday");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("Papu.Entities.Product", b =>
                {
                    b.Navigation("BreakfastProducts");

                    b.Navigation("DinnerProducts");

                    b.Navigation("DishProducts");

                    b.Navigation("LunchProducts");

                    b.Navigation("ProductGroups");

                    b.Navigation("SecondBreakfastProducts");

                    b.Navigation("SnackProducts");
                });

            modelBuilder.Entity("Papu.Entities.SecondBreakfast", b =>
                {
                    b.Navigation("Dishes");

                    b.Navigation("Monday");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("Papu.Entities.Snack", b =>
                {
                    b.Navigation("Dishes");

                    b.Navigation("Monday");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("Papu.Entities.Type", b =>
                {
                    b.Navigation("DishTypes");
                });

            modelBuilder.Entity("Papu.Entities.Unit", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
