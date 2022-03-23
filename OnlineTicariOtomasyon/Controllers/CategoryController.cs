using BusinessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using PagedList;

namespace OnlineTicariOtomasyon.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryDal() );
        public ActionResult Index(int sayfa=1)
        {
            var deger = cm.GetList().ToList().ToPagedList(sayfa, 4);
            return View(deger);
        }
        [HttpGet]
        public ActionResult CategoryAdd()
        {   
            return View();
        }
        [HttpPost]
        public ActionResult CategoryAdd(Category c)
        {
            cm.CategoryAdd(c);
            return RedirectToAction("Index");
        }
        public ActionResult CategoryDelete(int id)
        {
            var bul = cm.GetByID(id);
            cm.CategoryDelete(bul);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult CategoryUpdate(int id)
        {
            var bul = cm.GetByID(id);
            return View("CategoryUpdate",bul);
        }
        [HttpPost]
        public ActionResult CategoryUpdate(Category c)
        {
            cm.CategoryUpdate(c);
            return RedirectToAction("Index");
        }

    }
}