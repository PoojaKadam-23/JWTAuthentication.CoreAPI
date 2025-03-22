using System.ComponentModel.DataAnnotations;

namespace DTOModels.DTO
{
    public class CategoryDTO
    {
        
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required(ErrorMessage ="Rating is Required")]
        [Range(1,5)]
        
        public int Rating { get; set; }
    }
}
