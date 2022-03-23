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
    public class CargoController : Controller
    {
        CargoManager cm = new CargoManager(new EfCargoDal());
        CargoTrackingManager ctm = new CargoTrackingManager(new EfCargoTrackingDal());
        // GET: Cargo
        public ActionResult Index(string p)
        {
            var deger = cm.GetList().ToList();
            if (!string.IsNullOrEmpty(p))
            {
                deger = deger.Where(y => y.TrackingCode.ToLower().Contains(p.ToLower())).ToList();
            }
            return View(deger);
        }
        [HttpGet]
        public ActionResult CargoAdd()
        {
            //yeni kargo giriş sayfasına geldiğimizde bizim için rasgele bir kod oluştursun
            Random rnd = new Random();
            string[] karakterler = { "A", "B", "C", "D" };
            int k1, k2, k3;
            k1 = rnd.Next(0, karakterler.Length);
            k2 = rnd.Next(0, 4);
            k3 = rnd.Next(0, 4);
            int s1, s2, s3;
            s1 = rnd.Next(100, 1000);//10--->3 1 2 1 2 1
            s2 = rnd.Next(10, 99);
            s3 = rnd.Next(10, 99);
            string kod = s1.ToString() + karakterler[k1] + s2 + karakterler[k2] + s3 + karakterler[k3];
            ViewBag.takipkod=kod;            
            return View();
        }
        [HttpPost]
        public ActionResult CargoAdd(CargoDetail c)
        {
            
            cm.CargoAdd(c);
            return RedirectToAction("Index");
        }
        public ActionResult CargoTracking(string id)
        {
            var deger = ctm.GetList().Where(x => x.TrackingCode == id).ToList();
            return View(deger);
        }
    }
}