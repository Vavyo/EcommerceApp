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
    public class DbCategoryRepository : ICategoryRepository
    {
        private readonly EcommerceDbContext context;

        public DbCategoryRepository(EcommerceDbContext context)
        {
            this.context = context;
        }
        public async Task CreateCategory(Category category)
        {
            context.Add(category);
            await context.SaveChangesAsync();
        }

        public async  Task DeleteCategory(int id)
        {
            var category = await GetCategory(id);
            context.Categories.Remove(category);
            await context.SaveChangesAsync();
        }

        public async Task<List<Category>> GetCategories()
        {
            return await context.Categories.ToListAsync();
        }

        public async Task<Category> GetCategory(int? id)
        {
            return await context.Categories.FindAsync(id);
        }

        public async Task<bool> UpdateCategory(Category category)
        {
            try
            {
                context.Update(category);
                await context.SaveChangesAsync();

                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(category.Id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }

        }
        private bool CategoryExists(int id)
        {
            return context.Categories.Any(e => e.Id == id);
        }

    }
}
