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
    public class SalesController : Controller
    {
        SalesTransactionManager sm = new SalesTransactionManager(new EfSalesTransactionDal());
        ProductManager pm = new ProductManager(new EfProductDal());
        CariManager cm = new CariManager(new EfCariDal());
        EmployeeManager em = new EmployeeManager(new EfEmployeeDal());
        // GET: Sales
        public ActionResult Index()
        {
            var deger = sm.GetList().ToList();
            return View(deger);
        }
        [HttpGet]
        public ActionResult SalesAdd()
        {
            List<SelectListItem> value = (from x in pm.GetList()
                                          select new SelectListItem
                                          {
                                              Text = x.ProductName,
                                              Value = x.ProductID.ToString()
                                          }).ToList();
            List<SelectListItem> value2 = (from x in cm.GetList()
                                          select new SelectListItem
                                          {
                                              Text = x.CariName+" "+x.CariSurname,
                                              Value = x.CariID.ToString()
                                          }).ToList();
            List<SelectListItem> value3 = (from x in em.GetList()
                                           select new SelectListItem
                                           {
                                               Text = x.EmployeeName + " " + x.EmployeeSurname,
                                               Value = x.EmployeeID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = value;
            ViewBag.dgr2 = value2;
            ViewBag.dgr3 = value3;
            return View();
        }
        [HttpPost]
        public ActionResult SalesAdd(SalesTransaction c)
        {
            c.SalesDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.Status = true;
            sm.SalesTransactionAdd(c);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult SalesUpdate(int id)
        {
            List<SelectListItem> value = (from x in pm.GetList()
                                          select new SelectListItem
                                          {
                                              Text = x.ProductName,
                                              Value = x.ProductID.ToString()
                                          }).ToList();
            List<SelectListItem> value2 = (from x in cm.GetList()
                                           select new SelectListItem
                                           {
                                               Text = x.CariName + " " + x.CariSurname,
                                               Value = x.CariID.ToString()
                                           }).ToList();
            List<SelectListItem> value3 = (from x in em.GetList()
                                           select new SelectListItem
                                           {
                                               Text = x.EmployeeName + " " + x.EmployeeSurname,
                                               Value = x.EmployeeID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = value;
            ViewBag.dgr2 = value2;
            ViewBag.dgr3 = value3;
            var bul = sm.GetByID(id);
            return View("SalesUpdate", bul);
        }
        [HttpPost]
        public ActionResult SalesUpdate(SalesTransaction c)
        {
            if (!ModelState.IsValid)
            {
                return View("SalesUpdate");
            }
            c.SalesDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.Status = true;
            sm.SalesTransactionUpdate(c);
            return RedirectToAction("Index");
        }
        public ActionResult SalesDelete(int id)
        {
            var bul = sm.GetByID(id);
            sm.PassiveUpdate(bul);
            return RedirectToAction("Index");
        }
        public ActionResult SalesDetail(int id)
        {
            var bul = sm.GetByID(id);
            return View(bul);
        }
    }
}