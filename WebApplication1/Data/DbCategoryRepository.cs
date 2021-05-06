using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data.Interfaces;
using WebApplication1.Models.Api;

namespace WebApplication1.Data
{
    public class DbCategoryRepository : ICategoryRepository
    {
        private readonly EcommerceDbContext context;

        public DbCategoryRepository(EcommerceDbContext context)
        {
            this.context = context;
        }
        public Task CreateCategory(string name)
        {
            throw new NotImplementedException();
        }

        public Task<List<CategoryDto>> GetCategories()
        {
            throw new NotImplementedException();
        }
    }
}
