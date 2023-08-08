using CaseStudy.Entities;

namespace CaseStudy.Service
{
    public interface IRecipeService
    {
        void AddRecipe(Recipe recipe);

        void UpdateRecipe(Recipe recipe);

        Recipe GetRecipe(int id);

       void DeleteRecipe(int id);
        List<Recipe> GetAllRecipes();

        Recipe GetSingleRecipe(int id);
        List<Recipe> SearchRecipeByName(string name);
    }
}
