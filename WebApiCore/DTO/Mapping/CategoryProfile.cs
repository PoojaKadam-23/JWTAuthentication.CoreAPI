using AutoMapper;
using DAL_CRUD.Models;
using DTOModels.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOModels.Mapping
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile() 
        {
            CreateMap<Category,CategoryDTO>().ReverseMap();
        }
    }
}
