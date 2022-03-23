using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{
    public class CariController : Controller
    {
        CariManager cm = new CariManager(new EfCariDal());
        SalesTransactionManager sm = new SalesTransactionManager(new EfSalesTransactionDal());
        // GET: Cari
        public ActionResult Index()
        {
            var deger = cm.GetList().ToList();
            return View(deger);
        }

        [HttpGet]
        public ActionResult CariAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CariAdd(Cari c)
        {
            c.State = true;
            cm.CariAdd(c);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult CariUpdate(int id)
        {
            var bul = cm.GetByID(id);
            return View("CariUpdate", bul);
        }
        [HttpPost]
        public ActionResult CariUpdate(Cari c)
        {
            if (!ModelState.IsValid)
            {
                return View("CariUpdate");
            }
            cm.CariUpdate(c);
            return RedirectToAction("Index");
        }

        public ActionResult CariDelete(int id)
        {
            var bul = cm.GetByID(id);
            cm.PassiveUpdate(bul);
            return RedirectToAction("Index");
        }
        public ActionResult CariSales(int id)
        {
            var bul = sm.GetByCariID(id);
            var isim = bul.Select(x => x.Cari.CariName + " " + x.Cari.CariSurname).FirstOrDefault();
            ViewBag.name = isim;
            return View(bul);
        }
    }
}