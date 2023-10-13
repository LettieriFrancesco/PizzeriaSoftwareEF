using PizzeriaSoftwareEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PizzeriaSoftwareEF.Controllers
{
    public class LoginController : Controller
    {
        private ModelDbContext db = new ModelDbContext();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User auth)
        {
            if (ModelState.IsValid)
            {
                User utente = db.User.Where(u => u.Username == auth.Username && u.PasswordUser == auth.PasswordUser).FirstOrDefault();
                FormsAuthentication.SetAuthCookie(utente.Username, false);
                if(utente != null)
                {
                    Session["UserId"] = utente.IdUser;
                    FormsAuthentication.SetAuthCookie(utente.Username, false);
                    return RedirectToAction("Index", "Prodotti");
                }
                return View();

            }

            else { return View(); }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Login");
        }
    }
}