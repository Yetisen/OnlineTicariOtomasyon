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
    public class ProductDetailController : Controller
    {
        ProductManager pm = new ProductManager(new EfProductDal());
        DetailManager dm = new DetailManager(new EfDetailDal());
        // GET: ProductDetail
        public ActionResult Index()
        {
            //var deger = pm.GetList().Where(x=>x.ProductID==2).ToList();
            Class1 deger = new Class1();
            deger.Deger1 = pm.GetList().Where(x => x.ProductID == 2);
            deger.Deger2 = dm.GetList();
            return View(deger);
        }
    }
}