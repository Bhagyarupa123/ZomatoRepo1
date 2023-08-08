using CaseStudy.Entities;
using CaseStudy.Models;

namespace CaseStudy.Service
{
    public interface IOrderService
    {
        public void AddOrder(Orders order);

        List<OrderCart> GetAllOrders(int id);

        public void CancelOrder(int id);
    }
}
