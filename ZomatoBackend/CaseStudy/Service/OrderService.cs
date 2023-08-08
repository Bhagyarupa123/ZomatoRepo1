using CaseStudy.Entities;
using CaseStudy.Models;
using Microsoft.EntityFrameworkCore;

namespace CaseStudy.Service
{
    public class OrderService: IOrderService
    {
        private readonly ZomatoDBContext dBContext;

        public OrderService(ZomatoDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public void AddOrder(Orders order)
        {
            dBContext.Orders.Add(order);
            dBContext.SaveChanges();
        }

        public List<OrderCart> GetAllOrders(int userId)
        {
            //will get user id
            // should have recipe id
            //get all the recipes based on user Id

            List<OrderCart> orders = (from o in dBContext.Orders
                           join r in dBContext.Recipes
                           on o.recipeId equals r.RecipeId
                           where userId == o.userId
                           select new OrderCart()
                           {
                               recpieName = r.RecipeName,
                               recipeImage = r.ImageUrl,
                               description = r.Description,
                               price = r.Price,


                           }).ToList();

          
            return orders;
        }

        public void CancelOrder(int id)
        {
            Orders order = dBContext.Orders.Find(id);
            if (order != null)
            {
                dBContext.Orders.Remove(order);
                dBContext.SaveChanges();
            }
        }
    }
}
