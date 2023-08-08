using CaseStudy.Entities;
using CaseStudy.Models;

namespace CaseStudy.Service
{
    public interface ICartService
    {
     public  void AddToCart(Cart cart);

       public void DeleteFromCart(int cartId);

      public  List   <UserCart> GetCartRecipes(int userId);

 


    }
}
