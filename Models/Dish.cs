using System;
using System.ComponentModel.DataAnnotations;

namespace ChefsNDishes.Models
{
    public class Dish
    {
        [Key]
        public int DishId { get; set; }

        [Required]
        [Display(Name="Dish Name")]
        public string DishName { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Calories { get; set; }

        [Required]
        [Range(1, 5)]
        public int Tastiness { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Required]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        [Required]
        [Display(Name="Chef")]
        public int ChefId { get; set; }

        public Chef Creator { get; set; }
    }
}