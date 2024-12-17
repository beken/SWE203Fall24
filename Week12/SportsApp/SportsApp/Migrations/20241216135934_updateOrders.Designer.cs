﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SportsApp.Models;

#nullable disable

namespace SportsApp.Migrations
{
    [DbContext(typeof(StoreDbContext))]
    [Migration("20241216135934_updateOrders")]
    partial class updateOrders
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.11");

            modelBuilder.Entity("Order", b =>
                {
                    b.Property<long>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("TEXT");

                    b.HasKey("OrderID");

                    b.ToTable("Orders");

                    b.HasDiscriminator().HasValue("Order");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("OrderProduct", b =>
                {
                    b.Property<long>("OrdersOrderID")
                        .HasColumnType("INTEGER");

                    b.Property<long>("productsProductID")
                        .HasColumnType("INTEGER");

                    b.HasKey("OrdersOrderID", "productsProductID");

                    b.HasIndex("productsProductID");

                    b.ToTable("OrderProduct");
                });

            modelBuilder.Entity("SportsApp.Models.Product", b =>
                {
                    b.Property<long>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<long>("ProductCategoryID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ProductID");

                    b.HasIndex("ProductCategoryID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("SportsApp.Models.ProductCategory", b =>
                {
                    b.Property<long>("ProductCategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ProductCategoryID");

                    b.ToTable("ProductCategories");
                });

            modelBuilder.Entity("SportsApp.Models.ProductReview", b =>
                {
                    b.Property<long>("ProductReviewID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long>("ProductID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Rating")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ReviewerName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ProductReviewID");

                    b.HasIndex("ProductID");

                    b.ToTable("ProductReviews");
                });

            modelBuilder.Entity("ShippingOrder", b =>
                {
                    b.HasBaseType("Order");

                    b.Property<string>("ShippingAddress")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ShippingFirm")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasDiscriminator().HasValue("ShippingOrder");
                });

            modelBuilder.Entity("SubscriptionOrder", b =>
                {
                    b.HasBaseType("Order");

                    b.Property<string>("RenewalDate")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("RenewalPeriod")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasDiscriminator().HasValue("SubscriptionOrder");
                });

            modelBuilder.Entity("OrderProduct", b =>
                {
                    b.HasOne("Order", null)
                        .WithMany()
                        .HasForeignKey("OrdersOrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SportsApp.Models.Product", null)
                        .WithMany()
                        .HasForeignKey("productsProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SportsApp.Models.Product", b =>
                {
                    b.HasOne("SportsApp.Models.ProductCategory", "ProductCategory")
                        .WithMany()
                        .HasForeignKey("ProductCategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductCategory");
                });

            modelBuilder.Entity("SportsApp.Models.ProductReview", b =>
                {
                    b.HasOne("SportsApp.Models.Product", null)
                        .WithMany("Reviews")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SportsApp.Models.Product", b =>
                {
                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}