using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data.Interfaces;
using WebApplication1.Models;
using WebApplication1.Models.Api;

namespace WebApplication1.Data
{
    public class DbProductRepository : IProductRepository
    {
        private readonly EcommerceDbContext context;

        public DbProductRepository(EcommerceDbContext context)
        {
            this.context = context;
        }
        public Task CreateProduct(ProductDto product)
        {
            throw new NotImplementedException();
        }

        public List<ProductDto> GetAllProducts()
        {
            return context.Products
                .Select(product => new ProductDto
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Categories = product.ProductCategories.Select(category => new Category
                    {
                        Id = category.Category.Id,
                        Name = category.Category.Name,
                    }).ToList()
                }).ToList();
        }

        public Task<ProductDto> GetProduct(int productId)
        {
            throw new NotImplementedException();
        }
    }
}
