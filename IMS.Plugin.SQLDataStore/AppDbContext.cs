using IMS.CoreBusiness.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Plugin.SQLDataStore
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.category)
                .HasForeignKey(p => p.CategoryId);

            //seeding data
            modelBuilder.Entity<Category>().HasData(
                new Category() { Id = 1, Name = "دوربین", Description = "توضیحاتی در مورد دوربین" },
                new Category() { Id = 2, Name = "میکریفون", Description = "توضیحاتی در مورد میکریفون" },
                new Category() { Id = 3, Name = "مبدل", Description = "توضیحاتی در مورد مبدل" },
                new Category() { Id = 4, Name = "سه پایه", Description = "توضیحاتی در مورد سه پایه" }
                );
            modelBuilder.Entity<Product>().HasData(
                new Product() { Id = 1, Name = "دوربین پرتابل", Description = "توضیحات محصول", Quntity = 2, CategoryId = 1 },
                new Product() { Id = 2, Name = "دوربین استدیو", Description = "توضیحات محصول", Quntity = 3, CategoryId = 1 },
                new Product() { Id = 3, Name = "میکریفون پرتابل", Description = "توضیحات محصول", Quntity = 20, CategoryId = 2 },
                new Product() { Id = 4, Name = "کانورتور به HDMI", Description = "توضیحات محصول", Quntity = 12, CategoryId = 3 },
                new Product() { Id = 5, Name = "سه پایه پرتابل", Description = "توضیحات محصول", Quntity = 15, CategoryId = 4 }
                );
        }
    }
}
