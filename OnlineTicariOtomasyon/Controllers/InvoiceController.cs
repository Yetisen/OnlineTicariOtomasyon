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
    public class InvoiceController : Controller
    {
        InvoiceManager im = new InvoiceManager(new EfInvoiceDal());
        InvoiceItemManager itemm = new InvoiceItemManager(new EfInvoiceItemDal());
        // GET: Invoice
        public ActionResult Index()
        {
            var deger = im.GetList().ToList();
            return View(deger);
        }
        [HttpGet]
        public ActionResult InvoiceAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult InvoiceAdd(Invoice d)
        {
            im.InvoiceAdd(d);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult InvoiceUpdate(int id)
        {
            var bul = im.GetByID(id);
            return View("InvoiceUpdate", bul);
        }
        [HttpPost]
        public ActionResult InvoiceUpdate(Invoice d)
        {
            im.InvoiceUpdate(d);
            return RedirectToAction("Index");
        }
        public ActionResult InvoiceDetail(int id)
        {
            var bul = itemm.GetByInvoice(id);
            if (bul==null)
            {
                return RedirectToAction("InvoiceItemAdd");
            }
            return View("InvoiceDetail", bul);
        }
        [HttpGet]
        public ActionResult InvoiceItemAdd()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult InvoiceItemAdd(InvoiceItem d)
        {
            itemm.InvoiceItemAdd(d);
            return RedirectToAction("Index");
        }
    }
}