using DAL_CRUD.Models;
using DTOModels.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface ICategoryService
    {
        Task<List<CategoryDTO>> GetAllAsync();
        Task<CategoryDTO?> GetByIdAsync(int id);
        Task<bool> CreateAsync(CategoryDTO category);
        Task<bool> UpdateAsync(CategoryDTO category);
        Task<bool> DeleteAsync(int id);
    }
}
