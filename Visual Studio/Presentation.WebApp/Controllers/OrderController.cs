using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Logistics.Application.Services;
using Logistics.Domain.Model.Entities.Order;
using Presentation.WebApp.Models;

namespace Presentation.WebApp.Controllers
{
    public class OrderController : ApiController
    {
        // GET api/<controller>
        public IList<Order> Get()
        {
            OrderService orderService = new OrderService();
            var orders = orderService.GetAllOrders();
            return orders;
        }

        // GET api/<controller>/5
        public Order Get(int id)
        {
            OrderService orderService = new OrderService();
            var order = orderService.GetOrder(id);
            return order;
        }

        // POST api/<controller>
        public void Post([FromBody] OrderData orderData)
        {

            var a = new Address
            {
                City = orderData.cityValue,
                Street = orderData.streetValue,
                HouseNumber = orderData.housenumber
            };
            var p = new Payment {Value = orderData.paymentValue, Currency = Currency.PLN};
            var s = (int)Status.INFORMATION_RECEIVED;

            OrderService orderService = new OrderService();
            orderService.CreateOrder(a, p, s);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
          
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            OrderService orderService = new OrderService();
            var order = orderService.GetOrder(id);
            orderService.DeleteOrder(order);
        }
    }
}