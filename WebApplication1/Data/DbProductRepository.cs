using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data.Interfaces;
using WebApplication1.Models.Api;

namespace WebApplication1.Data
{
    public class DbProductRepository : IProductRepository
    {
        private EcommerceDbContext context;

        public DbProductRepository(EcommerceDbContext context)
        {
            this.context = context;
        }
        public Task CreateProduct(ProductDto product)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ProductDto>> GetAllProducts()
        {
            return await context.Products
                .Select(product => new ProductDto
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Categories = product.ProductCategories.Select(category => new CategoryDto
                    {
                        Id = category.Category.Id,
                        Name = category.Category.Name,
                    }).ToList()
                }).ToListAsync();
        }

        public Task<ProductDto> GetProduct(int productId)
        {
            throw new NotImplementedException();
        }
    }
}
