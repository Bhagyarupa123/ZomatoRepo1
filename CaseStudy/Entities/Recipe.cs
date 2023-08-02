using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CaseStudy.Entities
{
    public class Recipe
    {
        [Key]
        
        public int RecipeId { get; set; }
        [Required]
        public string RecipeName { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
