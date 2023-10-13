using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PizzeriaSoftwareEF.Models;

namespace PizzeriaSoftwareEF.Controllers
{
    public class OrdiniController : Controller
    {
        private ModelDbContext db = new ModelDbContext();

        public ActionResult Index()
        {
            var ordini = db.Ordini.Include(o => o.Clienti);
            return View(ordini.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ordini ordini = db.Ordini.Find(id);
            if (ordini == null)
            {
                return HttpNotFound();
            }
            return View(ordini);
        }

        public ActionResult Create()
        {
            ViewBag.IdCliente = new SelectList(db.Clienti, "IdCliente", "Nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdOrdine,DataOrdine,Importo,IndirizzoConsegna,StatoOrdine,IdCliente")] Ordini ordini)
        {
            if (ModelState.IsValid)
            {
                db.Ordini.Add(ordini);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCliente = new SelectList(db.Clienti, "IdCliente", "Nome", ordini.IdCliente);
            return View(ordini);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ordini ordini = db.Ordini.Find(id);
            if (ordini == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCliente = new SelectList(db.Clienti, "IdCliente", "Nome", ordini.IdCliente);
            return View(ordini);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdOrdine,DataOrdine,Importo,IndirizzoConsegna,StatoOrdine,IdCliente")] Ordini ordini)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ordini).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCliente = new SelectList(db.Clienti, "IdCliente", "Nome", ordini.IdCliente);
            return View(ordini);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ordini ordini = db.Ordini.Find(id);
            if (ordini == null)
            {
                return HttpNotFound();
            }
            return View(ordini);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ordini ordini = db.Ordini.Find(id);
            db.Ordini.Remove(ordini);
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
