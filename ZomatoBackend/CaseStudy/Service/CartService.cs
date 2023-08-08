using CaseStudy.Entities;
using CaseStudy.Models;

namespace CaseStudy.Service
{
    public class CartService : ICartService
    {

        private readonly ZomatoDBContext _dbContext;

        private readonly RecipeService recipeService;

        public CartService(ZomatoDBContext dbContext)
        {
            
                _dbContext = dbContext;
            
        }

        public  void AddToCart(Cart cart)
            {
                _dbContext.Add(cart);
                _dbContext.SaveChanges();

            }

        private Recipe ConvertSourceToRecipe(UserCart usercart)
        {
            Recipe recipe = new Recipe();

            recipe.RecipeName = usercart.recpieName;
            recipe.ImageUrl = usercart.recipeImage;
            recipe.Price = usercart.price;
            recipe.Description = usercart.description;

            return recipe;
        }
        public  List<UserCart> GetCartRecipes(int userId)
            {
            Console.WriteLine("the user id is {0}", userId);

                var recipes = (from c in _dbContext.Cart
                               join r in _dbContext.Recipes
                               on c.recipeId equals r.RecipeId
                               where userId == c.userId
                               select new UserCart()
                               {
                                   recpieName = r.RecipeName,
                                   recipeImage = r.ImageUrl,
                                   description = r.Description,
                                   price = r.Price,
                                   recipeId=r.RecipeId,
                                   cartId= c.cartId,

                                  

                               }).ToList();
            Console.WriteLine("hello {0}", recipes.Count);
            foreach (var recipe in recipes) {
                Console.WriteLine("The recipes are {0}", recipe);
            }

           



            return recipes;
            }

          public  void DeleteFromCart(int id)
            {
               Cart cart = _dbContext.Cart.Find(id);
                _dbContext.Cart.Remove(cart);
                _dbContext.SaveChanges();
            }



        

    }
}
