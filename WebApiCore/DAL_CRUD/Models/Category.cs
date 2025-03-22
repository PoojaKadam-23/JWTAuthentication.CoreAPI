using System.ComponentModel.DataAnnotations.Schema;

namespace DAL_CRUD.Models
{
    [Table("Category")]
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Rating { get; set; }
    }
}
