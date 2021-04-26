using System;
using System.ComponentModel.DataAnnotations;

namespace CRUD_Practice.Models
{
    public class Dish
    {
        [Key]
        public int DishId {get; set;}

        [Required]
        [MinLength(2, ErrorMessage="No Chef name is that short...")]
        [MaxLength(20, ErrorMessage="No Chef name is that long...")]
        public string ChefName {get; set;}

        [Required]
        [MinLength(2, ErrorMessage="No Dish name is that short...")]
        [MaxLength(20, ErrorMessage="No Dish name is that long...")]
        public string DishName {get; set;}

        [Required]
        [Range(1, Int32.MaxValue)]
        public int Calories {get;set;}

        [Required]
        [Range(1, 5)]
        public int Tastiness {get;set;}

        [Required]
        [MinLength(2, ErrorMessage="Description too short...")]
        [MaxLength(50, ErrorMessage="Description too long...")]
        public string Description {get;set;}
    }
}