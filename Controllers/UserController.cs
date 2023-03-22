using Microsoft.AspNetCore.Mvc;
using EKart.Models;
namespace EKart.Controllers
{
    public class UserController : Controller
    {
        ElectronicsstoreContext db;

        public UserController(ElectronicsstoreContext electronicsstoreContext)
        {
            db = electronicsstoreContext;
        }

        public IActionResult Index()
        {
            List<UserRegistration> list = new List<UserRegistration>();
            list = db.UserRegistrations.ToList();
            return View(list);
        }

        [HttpGet]
        public IActionResult AddUsers()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddUsers(UserRegistration tbUser)
        {
            db.UserRegistrations.Add(tbUser);
            db.SaveChanges();
            return RedirectToAction("Login","Home");
        }

        [HttpGet]
        public IActionResult DeleteUser(int Id)
        {
            UserRegistration user = null;
            user = db.UserRegistrations.Find(Id);
            return View(user);
        }
        [HttpPost]
        public IActionResult DeleteUser(UserRegistration tbUser)
        {
            db.UserRegistrations.Remove(tbUser);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditUser(int Id)
        {
            UserRegistration tbUser = null;
            tbUser = db.UserRegistrations.Find(Id);
            return View(tbUser);
        }

        [HttpPost]
        public IActionResult EditUser(UserRegistration user)
        {
            UserRegistration tbuser = null;
            tbuser = db.UserRegistrations.Find(user.UserId);
            tbuser.Email=user.Email;
            tbuser.UserName=user.UserName;
            tbuser.Password = user.Password;
            tbuser.Contact = user.Contact;
            tbuser.Address = user.Address;
            tbuser.FullName=user.FullName;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult ViewByName(int Id)
        {
           UserRegistration tbUser = null;
            tbUser = db.UserRegistrations.Find(Id);

            return View(tbUser);
        }

    }
}
