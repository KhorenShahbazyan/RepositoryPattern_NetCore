using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Test.Core
{
    public class Option
    {
        public string ConnectionString { get; set; }
    }
   

    public partial class TestDbContext : DbContext
    {
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductOrder> ProductOrder { get; set; }


        public static DbContextOptions ContextOptions(Option option)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TestDbContext>();           
            optionsBuilder.UseSqlServer(option.ConnectionString);
            return optionsBuilder.Options;
        }

        
        public TestDbContext(IOptions<Option> option) : base(ContextOptions(option.Value))
        {          
        }

        //public IConfigurationRoot Configuration
        //{
        //    get
        //    {
        //           var builder = new ConfigurationBuilder()
        //                        .SetBasePath(System.IO.Directory.GetCurrentDirectory())
        //                        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        //        return builder.Build();
        //    }
        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(_option.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Order_Customer");

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.PaymentId)
                    .HasConstraintName("FK_Order_Payment");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.City).HasMaxLength(70);

                entity.Property(e => e.Country).HasMaxLength(50);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(80);

                entity.Property(e => e.PaymentDate).HasColumnType("datetime");

                entity.Property(e => e.Phone).HasColumnType("varchar(20)");

                entity.Property(e => e.PostalCode).HasMaxLength(20);

                entity.Property(e => e.State).HasMaxLength(100);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Price).HasColumnType("numeric");

                entity.Property(e => e.Url).HasMaxLength(500);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Product_Category");
            });

            modelBuilder.Entity<ProductOrder>(entity =>
            {
                entity.HasOne(d => d.Order)
                    .WithMany(p => p.ProductOrder)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ProductOrder_Order");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductOrder)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ProductOrder_Product");
            });
        }
    }
}