using DAL_CRUD.Data;
using DAL_CRUD.Models;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.RepositoryImplementation
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CategoryDBContext _context;

        public CategoryRepository(CategoryDBContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateAsync(Category category)
        {
            try
            {
                await _context.Categories.AddAsync(category);
                
                return await _context.SaveChangesAsync() > 0;
            }
            catch 
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var category = await _context.Categories.FindAsync(id);
                if (category != null) 
                {
                    _context.Categories.Remove(category);
                    return await _context.SaveChangesAsync() > 0;

                }
                else
                {
                    return false;
                }


            }
            catch
            {
                return false;
            }
        }

        public async Task<List<Category>> GetAllAsync()
        {
           return await _context.Categories.ToListAsync();
            
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id); 
        }

        public async Task<bool> UpdateAsync(Category category)
        {
            try
            {
                _context.Categories.Attach(category);
                _context.Entry(category).State = EntityState.Modified;
                return await _context.SaveChangesAsync() > 0;

            }
            catch
            {
                return false;
            }
        }
    }
}
