using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Newtonsoft.Json;
using Logistics.Domain.Model;
using Logistics.Application.Services;
using Logistics.Infrastructure.Repositories;

namespace Presentation.WebApp.Controllers
{
	public class OrderController : Controller
	{
		OrderService orderService = new OrderService();

		[HttpGet]
		public ActionResult Index ()
		{
			var orders = orderService.GetAllOrders();
			var json = JsonConvert.SerializeObject (orders);
			return new ContentResult { Content = json, ContentType = "application/json" };
		}
			
		public string AddOrder()
		{
			string cityValue = Request["city"];
			string streetValue = Request["street"];
			int housenumberValue = Int32.Parse(Request["housenumber"]);
			string paymentValue = Request["allOrdersPrice"];
			int priorityValue = Int32.Parse (Request ["priority"]);


			var address = new Address { City = cityValue, Street = streetValue, HouseNumber = housenumberValue };
			var payment = new Payment { Value = 200.0, Currency = Currency.PLN };
			var priority = priorityValue;
			orderService.CreateOrder (address, payment, priority);

			return "Dodano nowy produkt";
		}
	}
}

