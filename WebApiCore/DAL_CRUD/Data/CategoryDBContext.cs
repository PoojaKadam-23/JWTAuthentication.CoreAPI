using DAL_CRUD.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_CRUD.Data
{
    public class CategoryDBContext:DbContext
    {
        public CategoryDBContext(DbContextOptions<CategoryDBContext> options):base(options)
        {
            
        }
        public DbSet<Category> Categories { get; set; }

    }
}
