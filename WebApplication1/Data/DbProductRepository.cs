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

        public Task<List<ProductDto>> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public Task<ProductDto> GetProduct(int productId)
        {
            throw new NotImplementedException();
        }
    }
}
