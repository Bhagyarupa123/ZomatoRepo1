using CaseStudy.Entities;

namespace CaseStudy.Service
{
    public class RecipeService : IRecipeService
    {
        private readonly ZomatoDBContext dbContext;

        public RecipeService(ZomatoDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void AddRecipe(Recipe recipe)
        {
            dbContext.Recipes.Add(recipe);
            dbContext.SaveChanges();
        }

        public void DeleteRecipe(int id)
        {
            Recipe recipe = dbContext.Recipes.Find(id);
            if (recipe != null)
            {
                dbContext.Recipes.Remove(recipe);
                dbContext.SaveChanges();
            }
           

        }

        public Recipe GetSingleRecipe(int id)
        {
            Recipe recipe = dbContext.Recipes.Find(id);
            return recipe;
        }

      

        public List<Recipe> SearchRecipeByName(string name)
        {
         

            List<Recipe> recipes = dbContext.Recipes
                .Where(r=> r.RecipeName==name)
                .ToList();

            return recipes;
        }

        public void UpdateRecipe(Recipe recipe)
        {
            dbContext.Recipes.Update(recipe);
            dbContext.SaveChanges();
        }


        public List <Recipe> GetAllRecipes()
        {
           return dbContext.Recipes.ToList();
        }

        public Recipe GetRecipe(int id)
        {
           return dbContext.Recipes.Find(id);
        }

    }
}
