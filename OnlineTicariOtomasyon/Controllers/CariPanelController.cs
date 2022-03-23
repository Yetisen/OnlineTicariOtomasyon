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
    public class CariPanelController : Controller
    {
        CariManager cm = new CariManager(new EfCariDal());
        SalesTransactionManager sm = new SalesTransactionManager(new EfSalesTransactionDal());
        // GET: CariPanel //yenibir layout kullanalım yeni bir View ekleyelim
        [Authorize]
        public ActionResult Index()
        {
            var mail = (string)Session["CariMail"];
            var deger = cm.GetByMail(mail);
            ViewBag.m = mail;
            return View(deger);
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
        public ActionResult MyOrders()
        {
            var mail = (string)Session["CariMail"];
            var id = cm.GetByMail(mail).CariID;
            ViewBag.m = mail;
            var degerler= sm.GetByCariID(id);
            return View(degerler);
        }
    }
}