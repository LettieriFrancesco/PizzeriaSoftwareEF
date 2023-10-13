using PizzeriaSoftwareEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PizzeriaSoftwareEF.Controllers
{
    public class EvasiGiornalieriController : Controller
    {
        ModelDbContext db = new ModelDbContext();
        // GET: EvasiGiornalieri
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Evasi() 
        {
            return View();
        }
        public JsonResult totaleGiornalieri()
        {
           var data = DateTime.Now.Date;
           var dataOrdine = db.Ordini.Where(o => o.DataOrdine == data).ToList();
            NumOrdini num = new NumOrdini();
            decimal totale = 0;
            foreach(var o in dataOrdine)
            {
                totale += o.Importo;
                num.NumeroEvasi++;
            }
            num.TotaleEvasiGiornalieri = totale.ToString("C2");
            return Json(num,JsonRequestBehavior.AllowGet);

        }
    }
}