using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeManager em = new EmployeeManager(new EfEmployeeDal());
        DepartmentManager dm = new DepartmentManager(new EfDepartmentDal());
        // GET: Employee
        public ActionResult Index()
        {
            var deger = em.GetList().ToList();
            return View(deger);
        }
        [HttpGet]
        public ActionResult EmployeeAdd()
        {
            List<SelectListItem> value = (from x in dm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.DepartmentName,
                                                      Value = x.DepartmentID.ToString()
                                                  }
                                               ).ToList();
            ViewBag.dgr1 = value;
            return View();
        }
        [HttpPost]
        public ActionResult EmployeeAdd(Employee c)
        {
            if (Request.Files.Count > 0)//yaptığım işlemler bir dosya tutuyorsa  isteklerin arasında bir dosya mevcutsa
            {
                string fileName = Path.GetFileName(Request.Files[0].FileName); //hafızadaki değerin filename i
                string fileExtension = Path.GetExtension(Request.Files[0].FileName); //hafızadaki değerin uzantısını
                string yol = "~/Image/" + fileName + fileExtension;
                Request.Files[0].SaveAs(Server.MapPath(yol));//hafızaya aldığın dosyayı farklı kaydet maplenen yoldan gelen isimle kaydet
                c.EmployeeImage= "/Image/" + fileName + fileExtension;
            }
            //c.State = true;
            em.EmployeeAdd(c);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EmployeeUpdate(int id)
        {
            List<SelectListItem> value = (from x in dm.GetList()
                                          select new SelectListItem
                                          {
                                              Text = x.DepartmentName,
                                              Value = x.DepartmentID.ToString()
                                          }
                                               ).ToList();
            ViewBag.dgr1 = value;
            var bul = em.GetByID(id);
            return View("EmployeeUpdate", bul);
        }
        [HttpPost]
        public ActionResult EmployeeUpdate(Employee c)
        {
            if (Request.Files.Count > 0)//yaptığım işlemler bir dosya tutuyorsa  isteklerin arasında bir dosya mevcutsa
            {
                string fileName = Path.GetFileName(Request.Files[0].FileName); //hafızadaki değerin filename i
                string fileExtension = Path.GetExtension(Request.Files[0].FileName); //hafızadaki değerin uzantısını
                string yol = "~/Image/" + fileName + fileExtension;
                Request.Files[0].SaveAs(Server.MapPath(yol));//hafızaya aldığın dosyayı farklı kaydet maplenen yoldan gelen isimle kaydet
                c.EmployeeImage = "/Image/" + fileName + fileExtension;
            }
            if (!ModelState.IsValid)
            {
                return View("EmployeeUpdate");
            }
            em.EmployeeUpdate(c);
            return RedirectToAction("Index");
        }

        //public ActionResult EmployeeDelete(int id)
        //{
        //    var bul = em.GetByID(id);
        //    em.PassiveUpdate(bul);
        //    return RedirectToAction("Index");
        //}
        //public ActionResult EmployeeSales(int id)
        //{
        //    var bul = em.GetByCariID(id);
        //    var isim = bul.Select(x => x.Cari.CariName + " " + x.Cari.CariSurname).FirstOrDefault();
        //    ViewBag.name = isim;
        //    return View(bul);
        //}
        public ActionResult EmployeeList()
        {
            var deger = em.GetList().ToList();
            return View(deger);
        }
    }
}