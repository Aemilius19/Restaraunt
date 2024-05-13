using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _13MayWebApp.Models
{
    public class FoodItem
    {
        public int ID { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(255)]
        public string FoodName { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(255)]
        public string FoodDescription { get; set; }
       
        public string? FoodType { get; set;}
        public string? ImgUrl { get; set; }
        [NotMapped]
        public IFormFile? ImgFile { get; set; }


    }
}
