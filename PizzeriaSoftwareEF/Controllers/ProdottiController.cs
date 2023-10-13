using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PizzeriaSoftwareEF.Models;

namespace PizzeriaSoftwareEF.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProdottiController : Controller
    {
        
        private ModelDbContext db = new ModelDbContext();

        // GET: Prodotti
        public ActionResult Index()
        {
            return View(db.Prodotti.ToList());
        }
        public ActionResult Details(int? id)
        {
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

        
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(/*[Bind(Include = "IdProdotto,NomeProdotto,Costo,TempoConsegna,FotoProdotto,Ingredienti,DescrizioneAggiuntiva")]*/ Prodotti prodotti, HttpPostedFileBase fotoProdotto)
        {
            if (ModelState.IsValid)
            {
                if(fotoProdotto !=null && fotoProdotto.ContentLength > 0)
                {
                   prodotti.FotoProdotto = fotoProdotto.FileName;
                    //string pathToSave = Path.Combine(Server.MapPath("~/Content/FileUpload"), nomeFile);
                    string pathToSave = Server.MapPath("~/Content/FileUpload/") + fotoProdotto.FileName;
                    fotoProdotto.SaveAs(pathToSave);
                }
                db.Prodotti.Add(prodotti);
                db.SaveChanges();
                return RedirectToAction("Index");
               
            }

            return View(prodotti);
        }
        
        public ActionResult Edit(int? id)
        {
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
        [ValidateAntiForgeryToken]
        public ActionResult Edit(/*[Bind(Include = "IdProdotto,NomeProdotto,Costo,TempoConsegna,FotoProdotto,Ingredienti,DescrizioneAggiuntiva")]*/ Prodotti prodotti , HttpPostedFileBase fotoProdotto)
        {
            if (ModelState.IsValid)
            {
                if (fotoProdotto != null && fotoProdotto.ContentLength > 0)
                {
                    prodotti.FotoProdotto = fotoProdotto.FileName;
                    //string pathToSave = Path.Combine(Server.MapPath("~/Content/FileUpload"), nomeFile);
                    string pathToSave = Server.MapPath("~/Content/FileUpload/") + fotoProdotto.FileName;
                    fotoProdotto.SaveAs(pathToSave);
                }
                db.Entry(prodotti).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(prodotti);
        }
        
        public ActionResult Delete(int? id)
        {
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
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prodotti prodotti = db.Prodotti.Find(id);
            db.Prodotti.Remove(prodotti);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
