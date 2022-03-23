using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{
    public class StatisticController : Controller
    {
        CariManager cm = new CariManager(new EfCariDal());
        ProductManager pm = new ProductManager(new EfProductDal());
        EmployeeManager em = new EmployeeManager(new EfEmployeeDal());
        CategoryManager ccm = new CategoryManager(new EfCategoryDal());
        SalesTransactionManager sm = new SalesTransactionManager(new EfSalesTransactionDal());
        DepartmentManager dm = new DepartmentManager(new EfDepartmentDal());
        // GET: Istatistic
        public ActionResult Index()
        {
            var deger = cm.GetList().Count().ToString();//carileri say
            ViewBag.d1 = deger;
            var deger1 = pm.GetList().Count().ToString();//Ürünleri say
            ViewBag.d2 = deger1;
            var deger2 = em.GetList().Count().ToString();//personel say
            ViewBag.d3 = deger2;
            var deger3 = ccm.GetList().Count().ToString();//category say
            ViewBag.d4 = deger3;
            var deger4 = pm.GetList().Sum(x=>x.Stock).ToString();//toplam stok
            ViewBag.d5 = deger4;
            var deger5 = pm.GetList().Select(x => x.Brand).Distinct().Count().ToString();//toplam marka sayısı
            var degerx = (from x in pm.GetList() select x.Brand).Distinct().Count().ToString();//toplam marka sayısı
            ViewBag.d6 = deger5;
            var deger6 = pm.GetList().Count(x => x.Stock <=20).ToString();//risk 
            ViewBag.d7 = deger6;
            var deger7 = (from x in pm.GetList() orderby x.Price descending select x.ProductName).FirstOrDefault();
            ViewBag.d8 = deger7;
            var deger8 = (from x in pm.GetList() orderby x.Price ascending select x.ProductName).FirstOrDefault();
            ViewBag.d9 = deger8;
            var deger12 = pm.GetList().GroupBy(x => x.Brand).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault();//markaya göre grupla sayılarına göre sırala ismini seç
            ViewBag.d12 = deger12;
            var deger13 = pm.GetList().Where(u=>u.ProductID==(sm.GetList().GroupBy(x => x.ProductID).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault())).Select(k=>k.ProductName).FirstOrDefault();//ürüne göre grupla sayılarına göre sırala id seç ona eşit olanı getir
            ViewBag.d13 = deger13;
            var deger10 = pm.GetList().Count(x => x.ProductName == "Buzdolabi").ToString(); 
            ViewBag.d10 = deger10;
            var deger11 = pm.GetList().Count(x => x.ProductName == "Bilgisayar").ToString();
            ViewBag.d11 = deger11;
            var deger14 = sm.GetList().Sum(x => x.TotalPrice).ToString();
            ViewBag.d14 = deger14;
            DateTime bugun = DateTime.Parse(DateTime.Now.ToShortDateString());
            var deger15 = sm.GetList().Count(x => x.SalesDate==bugun).ToString();
            ViewBag.d15 = deger15;
            var deger16 = sm.GetList().Where(x=>x.SalesDate==bugun).Sum(x => x.TotalPrice).ToString();
            ViewBag.d16 = deger16;
            return View();
        }
        public ActionResult SemplaTables()
        {
            //gruplandırma
            var deger = cm.CityGroup().ToList();
            var a = 0;
            foreach (var x in deger)
            {
               
                 a = a+x.Total;

            }
            ViewBag.oran = a;
            return View(deger);
        }
        public PartialViewResult Partial()
        {
            var deger = em.DepartmentGroup().ToList();
         
            var a = 0;
            foreach (var x in deger)
            {

                a = a + x.Total;

            }
            ViewBag.oran = a;
            return PartialView(deger);
        }
        public PartialViewResult PartialCari()
        {
            var deger = cm.GetList().ToList();

            var a = 0;
            foreach (var x in deger)
            {

                //a = a + x.Total;
                

            }
            ViewBag.oran = a;
            return PartialView(deger);
        }
        public PartialViewResult PartialProduct()
        {
            var deger = pm.GetList().ToList();

        
            return PartialView(deger);
        }
        public PartialViewResult PartialBrand()
        {
            var deger = pm.BrandGroup().ToList();

            var a = 0;
            foreach (var x in deger)
            {

                a = a + x.Total;

            }
            ViewBag.oran = a;

            return PartialView(deger);
        }
    }
}