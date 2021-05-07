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

        public async Task<List<CategoryDto>> GetCategoryDtos()
        {
            return await context.Categories.Select(c => new CategoryDto
            {
                Id = c.Id,
                Name = c.Name,
                Products = c.ProductCategories.Select(pc => new Product
                {
                    Id = pc.Product.Id,
                    Name = pc.Product.Name,
                    Description = pc.Product.Description,
                }).ToList()
            }).ToListAsync();
        }

        public async Task<Category> GetCategory(int? id)
        {
            return await context.Categories
                .FirstOrDefaultAsync(m => m.Id == id);
        }
        public async Task<CategoryDto> GetCategoryDto(int? id)
        {
            return await context.Categories.Select(c => new CategoryDto
            {
                Id = c.Id,
                Name = c.Name,
                Products = c.ProductCategories.Select(pc => new Product
                {
                    Id = pc.Product.Id,
                    Name = pc.Product.Name,
                    Description = pc.Product.Description,
                }).ToList()
            }).FirstOrDefaultAsync(m => m.Id == id);
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
