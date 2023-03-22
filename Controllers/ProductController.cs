using Microsoft.AspNetCore.Mvc;
using EKart.Models;

namespace EKart.Controllers
{
    public class ProductController : Controller
    {
        ElectronicsstoreContext db;
        public ProductController(ElectronicsstoreContext electronicsstoreContext)
        {
            db = electronicsstoreContext;
        }
        public IActionResult Index() 
        {
            List<Product> list = new List<Product>();
            list=db.Products.ToList();
            return View(list);
        }

        [HttpGet]
        public IActionResult AddProducts()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProducts(Product tbProduct)
        {
            db.Products.Add(tbProduct);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DeleteProduct(int Id)
        {
            Product tbProduct1 = new Product();
            tbProduct1 = db.Products.Find(Id);
            return View(tbProduct1);
        }
        [HttpPost]
        public IActionResult DeleteProduct(Product tbProduct)
        {
            db.Products.Remove(tbProduct);
            db.SaveChanges ();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditProduct(int Id)
        {
           
            Product tbProduct = new Product();
            tbProduct = db.Products.Find(Id);

            return View(tbProduct);
        }

        [HttpPost]
        public IActionResult EditProduct(Product tbProduct )
        {
            Product tbProduct1 = null;
            
            tbProduct1 = db.Products.Find(tbProduct.ProductId);
            tbProduct1.ProductName = tbProduct.ProductName;
            tbProduct1.Price=tbProduct.Price;
            tbProduct1.Description=tbProduct.Description;   
            tbProduct1.QuantityAvailable=tbProduct.QuantityAvailable;
            tbProduct1.Category=tbProduct.Category;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult ViewByName(int Id)
        {
           
            Product tbProduct =new Product();
            tbProduct = db.Products.Find(Id);
            return View(tbProduct);
        }
        











    }
}
