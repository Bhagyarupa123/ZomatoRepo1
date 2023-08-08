namespace CaseStudy.Models
{
    public class OrderCart
    {
        public string recpieName { get; set; }
        public string recipeImage { get; set; }
        public double price { get; set; }
        public string description { get; set; }
        public int recipeId { get; set; }

        public int orderId { get; set; }
    
    }
}
