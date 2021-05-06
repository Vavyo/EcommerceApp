using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Models.Api;

namespace WebApplication1.Data.Interfaces
{
    public interface ICategoryRepository
    {
        Task CreateCategory(Category category);
        Task<List<Category>> GetCategories();
        Task<Category> GetCategory(int? id);
        Task DeleteCategory(int id);
        Task<bool> UpdateCategory(Category category);
    }
}
