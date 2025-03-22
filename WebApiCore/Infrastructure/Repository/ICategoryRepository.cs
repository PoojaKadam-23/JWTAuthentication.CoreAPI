using DAL_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public interface ICategoryRepository
    {
       Task<List<Category>> GetAllAsync();
       Task<Category?> GetByIdAsync(int id);
       Task<bool> CreateAsync(Category category);
       Task<bool> UpdateAsync(Category category);
       Task<bool> DeleteAsync(int id);


    }
}
