using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Models.Api;

namespace WebApplication1.Data.Interfaces
{
    public interface IProductRepository
    {
        Task CreateProduct(ProductDto product);
        Task<ProductDto> GetProduct(int productId);
        Task<List<ProductDto>> GetAllProducts();
    }
}
