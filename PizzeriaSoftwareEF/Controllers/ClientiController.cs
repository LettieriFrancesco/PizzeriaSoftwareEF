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
    public class ClientiController : Controller
    {
        private ModelDbContext db = new ModelDbContext();

        // GET: Clienti
        public ActionResult Index()
        {
            return View(db.Clienti.ToList());
        }

        // GET: Clienti/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clienti clienti = db.Clienti.Find(id);
            if (clienti == null)
            {
                return HttpNotFound();
            }
            return View(clienti);
        }

        // GET: Clienti/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clienti/Create
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCliente,Nome,Cognome,IndirizzoCliente")] Clienti clienti)
        {
            if (ModelState.IsValid)
            {
                db.Clienti.Add(clienti);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clienti);
        }

        // GET: Clienti/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clienti clienti = db.Clienti.Find(id);
            if (clienti == null)
            {
                return HttpNotFound();
            }
            return View(clienti);
        }

        // POST: Clienti/Edit/5
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCliente,Nome,Cognome,IndirizzoCliente")] Clienti clienti)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clienti).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clienti);
        }

        // GET: Clienti/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clienti clienti = db.Clienti.Find(id);
            if (clienti == null)
            {
                return HttpNotFound();
            }
            return View(clienti);
        }

        // POST: Clienti/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Clienti clienti = db.Clienti.Find(id);
            db.Clienti.Remove(clienti);
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
