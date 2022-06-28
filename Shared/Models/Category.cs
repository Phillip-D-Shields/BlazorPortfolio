using System.ComponentModel.DataAnnotations;

namespace Shared.Models
{
    class Category
    {
        [Key]
        public int CategoryId { get; set; } 
       
        [Required]
        [MaxLength(256)]
        public string ThumbnailImgPath { get; set; }
        
        [Required]
        [MaxLength(125)]
        public string Name { get; set; }
        
        [Required]
        [MaxLength(256)]
        public string Description { get; set; }

    }
}
