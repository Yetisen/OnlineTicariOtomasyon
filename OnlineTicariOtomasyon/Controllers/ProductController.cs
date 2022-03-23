using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{
    public class ProductController : Controller
    {
        ProductManager pm = new ProductManager(new EfProductDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        CariManager ccm = new CariManager(new EfCariDal());
        EmployeeManager em = new EmployeeManager(new EfEmployeeDal());
        SalesTransactionManager sm = new SalesTransactionManager(new EfSalesTransactionDal());
        // GET: Product
        public ActionResult Index(string p, int sayfa= 1)
        {
            var deger = pm.GetList().ToList();
            if (!string.IsNullOrEmpty(p))
            {
                deger = deger.Where(y => y.ProductName.ToLower().Contains(p.ToLower())).ToList();
            }

                
                
                
            return View(deger.ToPagedList(sayfa, 4));
        }
        [HttpGet]
        public ActionResult ProductAdd()
        {
            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }
                                                ).ToList();
            ViewBag.vlc = valuecategory;
            return View();
        }
        [HttpPost]
        public ActionResult ProductAdd(Product p)
        {
            pm.ProductAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult ProductDelete(int id)
        {
            var bul = pm.GetByID(id);
            pm.ProductDelete(bul);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult ProductUpdate(int id)
        {
            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }
                                                ).ToList();
            ViewBag.vlc = valuecategory;
            var bul = pm.GetByID(id);
            return View("ProductUpdate", bul);
        }
        [HttpPost]
        public ActionResult ProductUpdate(Product p)
        {
            pm.ProductUpdate(p);
            return RedirectToAction("Index");
        }
        
        public ActionResult ProductList()
        {
            var deger = pm.GetList().ToList();
            return View(deger);
        }
        [HttpGet]
        public ActionResult ProductSales(int id)
        {
            List<SelectListItem> value2 = (from x in ccm.GetList()
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
            ViewBag.dgr2 = value2;
            ViewBag.dgr3 = value3;
            var bul = pm.GetByID(id);
            ViewBag.dgr1 = bul.ProductName;
            ViewBag.dgr = bul.ProductID;
            ViewBag.fiyat = bul.Price;
            return View();
        }
        [HttpPost]
        public ActionResult ProductSales(SalesTransaction p) //satışhareket tanlama ekliycem
        {
            p.SalesDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.Status = true;
            sm.SalesTransactionAdd(p);
            return RedirectToAction("Index","Sales");
        }
    }
}