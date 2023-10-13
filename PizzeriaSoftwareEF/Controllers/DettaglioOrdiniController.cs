using PizzeriaSoftwareEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PizzeriaSoftwareEF.Controllers
{
    public class DettaglioOrdiniController : Controller
    {
        ModelDbContext db = new ModelDbContext();
        // GET: DettaglioOrdini
        public ActionResult Index()
        {
            return View();
        }
        //public ActionResult AddToCart(int IdProdotto, int quantita, Prodotti p)
        //{
        //    if (Request.IsAuthenticated)
        //    {
        //        int? userId = Session["UserId"] as int?;
        //        Ordini ord = new Ordini
        //        {
        //            DataOrdine = DateTime.Now,
        //            IdCliente = userId.Value,

        //        };

        //    }

        //}
    }
}