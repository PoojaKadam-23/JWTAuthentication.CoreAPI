using AutoMapper;
using DAL_CRUD.Models;
using DTOModels.DTO;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _catRepo;
        IMapper _mapper;

        public CategoryService(ICategoryRepository catRepo, IMapper mapper)
        {
            _catRepo = catRepo;
            _mapper = mapper;
        }

        
        public async Task<bool> CreateAsync(CategoryDTO categoryDto)
        {
            var cat = _mapper.Map<Category>(categoryDto);
            await _catRepo.CreateAsync(cat);
            return true;    
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var cat = _catRepo.GetByIdAsync(id);
            await _catRepo.DeleteAsync(id);
            return true;
        }

        public async Task<List<CategoryDTO>> GetAllAsync()
        {
            var categories = await _catRepo.GetAllAsync();
            return _mapper.Map<List<CategoryDTO>>(categories);
        }

        public async Task<CategoryDTO?> GetByIdAsync(int id)
        {
            var cat1 = await _catRepo.GetByIdAsync(id);
            return _mapper.Map<CategoryDTO?>(cat1);
        }

        public async Task<bool> UpdateAsync(CategoryDTO categorydt)
        {
            var catUp = _mapper.Map<Category>(categorydt);
            return await _catRepo.UpdateAsync(catUp);
        }
    }
}
