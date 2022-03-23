using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{
    public class GaleryController : Controller
    {
        ProductManager pm = new ProductManager(new EfProductDal());
        // GET: Galery
        public ActionResult Index()
        {
            var deger = pm.GetList().ToList();
            return View(deger);
        }
    }
}