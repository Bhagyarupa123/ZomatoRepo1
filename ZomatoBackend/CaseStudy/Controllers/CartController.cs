using CaseStudy.DTOs;
using CaseStudy.Entities;
using CaseStudy.Models;
using CaseStudy.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CaseStudy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

 
    public class CartController : ControllerBase
    {
        private readonly ICartService cartService;

        public CartController(ICartService cartService)
        {
            this.cartService = cartService;

        }

        [HttpPost, Route("AddToCart")]
        public IActionResult AddToCart(Cart cart)
        {

            try
            {
              
                cartService.AddToCart(cart);
                return StatusCode(200, cart);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet, Route("GetRecipe/{id}")]
        public IActionResult GetCartRecipes(int id)
        {
            try
            {
                List<UserCart> recipe = cartService.GetCartRecipes(id);
              
                return StatusCode(200, recipe);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete, Route("DeleteRecipe/{id}")]
        public IActionResult DeleteRecipe(int id)
        {
            try
            {
                cartService.DeleteFromCart(id);
                return StatusCode(200);
            }
            catch (Exception)
            {
                throw;
            }
        }



    }
}
