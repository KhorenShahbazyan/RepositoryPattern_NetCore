using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Test.Core;

namespace Test.Core
{
    [DbContext(typeof(TestDbContext))]
    partial class TestDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Test.Core.Data.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Test.Core.Data.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AccountId");

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("Test.Core.Data.Order", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CustomerId");

                    b.Property<DateTime?>("OrderDate")
                        .HasColumnType("datetime");

                    b.Property<long?>("PaymentId");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("PaymentId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("Test.Core.Data.Payment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<string>("City")
                        .HasMaxLength(70);

                    b.Property<string>("Country")
                        .HasMaxLength(50);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(80);

                    b.Property<DateTime?>("PaymentDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Phone")
                        .HasColumnType("varchar(20)");

                    b.Property<string>("PostalCode")
                        .HasMaxLength(20);

                    b.Property<string>("State")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("Test.Core.Data.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CategoryId");

                    b.Property<string>("Description")
                        .HasMaxLength(500);

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.Property<decimal?>("Price")
                        .HasColumnType("numeric");

                    b.Property<string>("Url")
                        .HasMaxLength(500);

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("Test.Core.Data.ProductOrder", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Count");

                    b.Property<long>("OrderId");

                    b.Property<long>("ProductId");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductOrder");
                });

            modelBuilder.Entity("Test.Core.Data.Order", b =>
                {
                    b.HasOne("Test.Core.Data.Customer", "Customer")
                        .WithMany("Order")
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("FK_Order_Customer");

                    b.HasOne("Test.Core.Data.Payment", "Payment")
                        .WithMany("Order")
                        .HasForeignKey("PaymentId")
                        .HasConstraintName("FK_Order_Payment");
                });

            modelBuilder.Entity("Test.Core.Data.Product", b =>
                {
                    b.HasOne("Test.Core.Data.Category", "Category")
                        .WithMany("Product")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK_Product_Category");
                });

            modelBuilder.Entity("Test.Core.Data.ProductOrder", b =>
                {
                    b.HasOne("Test.Core.Data.Order", "Order")
                        .WithMany("ProductOrder")
                        .HasForeignKey("OrderId")
                        .HasConstraintName("FK_ProductOrder_Order");

                    b.HasOne("Test.Core.Data.Product", "Product")
                        .WithMany("ProductOrder")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK_ProductOrder_Product");
                });
        }
    }
}
