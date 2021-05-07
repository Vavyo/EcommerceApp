using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Models.Identity;

namespace WebApplication1.Data
{
    public class EcommerceDbContext : IdentityDbContext<ApplicationUser>
    {
        public EcommerceDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // base is used due to IDentityDbContext
            base.OnModelCreating(builder);


            builder.Entity<ProductCategory>().HasKey(productCategory => new
            {
                productCategory.ProductId,
                productCategory.CategoryId,
            });
        }
    }
}
