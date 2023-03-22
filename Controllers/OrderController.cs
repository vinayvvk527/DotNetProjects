using Microsoft.AspNetCore.Mvc;
using EKart.Models;

namespace EKart.Controllers
{
    public class OrderController : Controller
    {
        ElectronicsstoreContext db;

        public OrderController(ElectronicsstoreContext electronicsstoreContext)
        {
            db = electronicsstoreContext;
        }
        public IActionResult Index()
        {
            List<Order> orders = new List<Order>();

            orders=db.Orders.ToList();
            return View(orders);
        }

        [HttpGet]
        public IActionResult AddOrder()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddOrder(Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
            return RedirectToAction("Success");
        }

        public IActionResult Success()
        {
            return View();
        }
       // public IActionResult ViewOrders()
        /*{
            return View();
        }*/
    }
}
