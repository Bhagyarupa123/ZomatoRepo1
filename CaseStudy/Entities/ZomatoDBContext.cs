using Microsoft.EntityFrameworkCore;
namespace CaseStudy.Entities
{
    public class ZomatoDBContext:DbContext
    {
        public ZomatoDBContext(DbContextOptions<ZomatoDBContext> options) : base(options) { }
        public DbSet<Recipe>Recipes { get; set; }
    }
}
