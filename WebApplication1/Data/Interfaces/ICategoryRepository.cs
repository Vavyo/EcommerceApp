using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models.Api;

namespace WebApplication1.Data.Interfaces
{
    public interface ICategoryRepository
    {
        Task CreateCategory(string name);
        Task<List<CategoryDto>> GetCategories(); 
    }
}
