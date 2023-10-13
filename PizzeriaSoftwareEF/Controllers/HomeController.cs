using PizzeriaSoftwareEF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PizzeriaSoftwareEF.Controllers
{
    
    public class HomeController : Controller
    {
        private ModelDbContext db = new ModelDbContext();
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View(db.Prodotti.ToList());
        }
        public ActionResult Details(int? id)
        {
            Session["IdDetails"] = id;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prodotti prodotti = db.Prodotti.Find(id);
            if (prodotti == null)
            {
                return HttpNotFound();
            }
            return View(prodotti);
        }
        [HttpPost]
        public JsonResult Carrello(string quantita) 
        {
            int? userId = Session["UserId"] as int?;
           
            User user = db.User.Find(userId);
            Ordini ord = new Ordini();
            var ordineCart = db.Ordini.FirstOrDefault(o => o.StatoOrdine == "Aggiunto al carrello" && o.IdCliente == userId);
            if (ordineCart == null) { 
            ord.IdCliente = userId.Value;
            ord.DataOrdine = DateTime.Now;
            ord.IndirizzoConsegna = "Via Roma";
            ord.StatoOrdine = "Aggiunto al carrello";
            db.Ordini.Add(ord);
            db.SaveChanges();
            var ordine = db.Ordini.FirstOrDefault(o => o.StatoOrdine == "Aggiunto al carrello" && o.IdCliente == userId);
            DettaglioOrdini dett = new DettaglioOrdini();
            dett.IdOrdine = ordine.IdOrdine;
            dett.IdProdotto = Convert.ToInt32(Session["IdDetails"]);
            dett.Quantita = Convert.ToInt32(quantita);
            db.DettaglioOrdini.Add(dett); 
            db.SaveChanges();
                return Json(dett);
            }
            else
            {
                var IdOrdine = db.DettaglioOrdini.Where(i => i.IdOrdine == ordineCart.IdOrdine);
                foreach(var item in IdOrdine)
                {
                    if (Convert.ToInt32(Session["IdDetails"]) == item.IdProdotto)
                    {
                        ModelDbContext db2 = new ModelDbContext();
                        item.Quantita += Convert.ToInt32(quantita);
                        db2.Entry(item).State = EntityState.Modified;
                        db2.SaveChanges();
                    }
                    else
                    {
                        DettaglioOrdini dett = new DettaglioOrdini();
                        dett.IdOrdine = item.IdOrdine;
                        dett.IdProdotto = Convert.ToInt32(Session["IdDetails"]);
                        dett.Quantita = Convert.ToInt32(quantita);
                        ModelDbContext db1 = new ModelDbContext();
                        db1.DettaglioOrdini.Add(dett);
                        db1.SaveChanges();
                    }
                }
                
                return Json(IdOrdine);
            }

            
            
        }
        [Authorize]
        public ActionResult ViewCarrello()
        {
            
            int? userId = Session["UserId"] as int?;
            var user = db.Ordini.Where(p => p.IdCliente == userId && p.StatoOrdine == "Aggiunto al carrello");
            List<DettaglioOrdini> list = new List<DettaglioOrdini>();

            foreach (var item in user)
            {
               List<DettaglioOrdini> dettaglioOrdini = db.DettaglioOrdini.Where(p=> p.IdOrdine == item.IdOrdine).ToList();
                foreach(var item1 in dettaglioOrdini)
                {
                    list.Add(item1);
                }
            }

           return View(list);
           
        }
        public ActionResult CheckOut(string parameter)
        {
           
            int idCheck = Convert.ToInt32(parameter);
            var price = db.DettaglioOrdini.Where(p => p.IdOrdine == idCheck);
            var check = db.Ordini.Find(idCheck);
            foreach(var item in price)
            {
                var cost = db.Prodotti.FirstOrDefault(c => c.IdProdotto == item.IdProdotto);
                check.Importo += cost.Costo * item.Quantita;
            }
            check.StatoOrdine = "Ordinato";
            db.Entry(check).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index","Home");
        }
        public ActionResult ListaOrdiniFatti()
        {
            int? userId = Session["UserId"] as int?;
            var listUser = db.Ordini.Where(o => o.IdCliente == userId);
            if (User.IsInRole("Admin"))
            {
                return View(db.Ordini.ToList());
            }
            else
            {
                return View(listUser.ToList());
            }
            
        }
    }
}
