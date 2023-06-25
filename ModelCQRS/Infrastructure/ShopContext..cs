using System;
using Microsoft.EntityFrameworkCore;
using ModelCQRS.Models;

namespace ModelCQRS.Infrastructure
{
	public class ShopContext : DbContext 
	{
        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.HasOne(d => d.Category)
                .WithMany(p => p.Products)
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey(d => d.CategoryId);
                //.HasConstraintName("FK__Invoice__OrderId__44FF419A");
            });

            modelBuilder.Entity<Category>()
              .ToTable("Category");




        }
    }
}