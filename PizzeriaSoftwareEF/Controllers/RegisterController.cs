using PizzeriaSoftwareEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PizzeriaSoftwareEF.Controllers
{
    public class RegisterController : Controller
    {
        ModelDbContext db = new ModelDbContext();
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register([Bind(Exclude = "Ruolo")]User user, Clienti cliente)
        {
            user.Ruolo = "User";

            if (ModelState.IsValid)
            {
                db.Clienti.Add(cliente);
                db.SaveChanges();
                db.User.Add(user);
                db.SaveChanges();
                return RedirectToAction("Login","Login");
            }
            return View();
        }
    }
}