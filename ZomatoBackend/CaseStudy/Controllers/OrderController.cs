using CaseStudy.Entities;
using CaseStudy.Models;
using CaseStudy.Service;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace CaseStudy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }


        [HttpPost, Route("ConfirmOrder")]
        public IActionResult ConfirmOrder(Orders order)
        {

            try
            {

                orderService.AddOrder(order);
                return StatusCode(200, order);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet, Route("GetAllOrders/{id}")]
        public IActionResult GetAllOrders(int id)
        {
            try
            {
                List<OrderCart> orders = orderService.GetAllOrders(id);
                
                return Ok(orders);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete, Route("CancelOrder/{id}")]
        public IActionResult CancelOrder(int id)
        {
            try
            {
                orderService.CancelOrder(id);
                return StatusCode(200);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
