using System.ComponentModel.DataAnnotations;

namespace CaseStudy.Entities
{
    public class Orders
    {

        [Key]
        public int orderId { get; set; }
        public int recipeId { get; set; }

        public int userId { get; set; } 
    }
}
