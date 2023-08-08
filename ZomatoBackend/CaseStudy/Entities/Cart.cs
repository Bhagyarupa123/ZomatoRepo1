using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CaseStudy.Entities
{
    public class Cart
    {
        [Key]
        public int cartId { get; set; }      
        public int recipeId { get; set; }   

       
        public int userId { get; set; } 


    }
}
