using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ChefsNDishes.Validators;

namespace ChefsNDishes.Models
{
    public class Chef
    {
        [Key]
        public int ChefId { get; set; }

        [Required]
        [Display(Name="First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name="Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name="Date of Birth")]
        [Birthday]
        public DateTime Birthday { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Required]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public List<Dish> SignatureDishes { get; set; }
    }
}