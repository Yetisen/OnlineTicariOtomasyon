using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OnlineTicariOtomasyon.Controllers
{
    public class LoginController : Controller
    {
        CariManager cm = new CariManager(new EfCariDal());
        AdminManager am = new AdminManager(new EfAdminDal());
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult PartialRegester()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult PartialRegester(Cari p)
        {
            p.State = true; //şimdilik
            if (cm.GetList().Find(x => x.CariMail == p.CariMail)==null)
            {
                cm.CariAdd(p);
               
                return PartialView("end");

            }
           
            return PartialView();
        }
        //public PartialViewResult Check() //iptal
        //{

        //    return PartialView();
        //}
        [HttpGet]
        public ActionResult PartialCari()
        {
            
            return View();
        }
       
        [HttpPost]
        public ActionResult PartialCari(Cari p)
        {
            p.State = true; //şimdilik
            var bul =cm.GetList().FirstOrDefault(x=>x.CariMail==p.CariMail && x.CariPassword==p.CariPassword);
            if (bul != null)
            {
                FormsAuthentication.SetAuthCookie(bul.CariMail, false); //oturum yönetici için //kalıcı cookie oluşturmadık
                Session["CariMail"] = bul.CariMail; //sisteme giriş yapan kişinin ismini Session yapıyorum
                return RedirectToAction("Index", "CariPanel");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
           
        }
        [HttpGet]
        public ActionResult AdminLogin()
        {

            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(Admin p)
        {
            var bul = am.GetList().FirstOrDefault(x => x.UserName == p.UserName && x.Password == p.Password);
            if (bul != null)
            {
                FormsAuthentication.SetAuthCookie(bul.UserName, false);
                Session["UserName"] = bul.UserName; //taşıyalım daha sonra yetkiendirmede kullanacağım
                return RedirectToAction("Index", "Category");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }

            return View();
        }
    }
}