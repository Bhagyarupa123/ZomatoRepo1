using CaseStudy.Service;
using CaseStudy.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace CaseStudy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize]
    public class RecipeController : ControllerBase
    {

        private readonly IRecipeService recipeService;

        public RecipeController (IRecipeService recipeService)
        {
            this.recipeService = recipeService;
        }

        [HttpPost, Route("AddRecipe")]

        public IActionResult AddRecipe(Recipe recipe)
        {
            try
            {
                recipeService.AddRecipe(recipe);
                return StatusCode(200, recipe);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut, Route("UpdateRecipe")]
        public IActionResult EditRecipe(Recipe recipe)
        {
            try
            {
                recipeService.UpdateRecipe(recipe);
                return StatusCode(200, recipe);
            }
            catch(Exception)
            {
                throw;
            }
        }

        [HttpDelete, Route("DeleteRecipe/{id}")]
        public IActionResult DeleteRecipe(int id)
        {
            try
            {
                recipeService.DeleteRecipe(id);
                return StatusCode(200, "sucessfully deleted");
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet, Route("GetRecipeByName/{name}")]
        public IActionResult GetRecipeByName(string name)
        {
            try {
             List<Recipe> recipes=   recipeService.SearchRecipeByName(name);
                return StatusCode(200, recipes);
               }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet, Route("GetAllRecipes")]

        public IActionResult GetAllRecipes()
        {
            try
            {
                List<Recipe> recipes = recipeService.GetAllRecipes();
                return StatusCode(200, recipes);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet, Route("GetSingleRecipe/{id}")]

        public IActionResult GetSingleRecipe(int id)
        {
            try
            {
                Recipe recipe = recipeService.GetSingleRecipe(id);
                if (recipe == null)
                {
                    return StatusCode(200, recipe);
                }
                else
                {
                    return StatusCode(400, "recipe not found");
                }
            }
            catch(Exception)
            {
                throw;
            }
        }

    }
}
