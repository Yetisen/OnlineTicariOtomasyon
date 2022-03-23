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
    public class DepartmentController : Controller
    {
        DepartmentManager dm = new DepartmentManager(new EfDepartmentDal());
        EmployeeManager em = new EmployeeManager(new EfEmployeeDal());
        SalesTransactionManager sm = new SalesTransactionManager(new EfSalesTransactionDal());
        // GET: Department
        public ActionResult Index()
        {
            var deger = dm.GetList().Where(x => x.Status == true).ToList();
            return View(deger);
        }
        [HttpGet]
        public ActionResult DepartmentAdd()
        {
            //List<SelectListItem> valuecategory = (from x in cm.GetList()
            //                                      select new SelectListItem
            //                                      {
            //                                          Text = x.CategoryName,
            //                                          Value = x.CategoryID.ToString()
            //                                      }
            //                                    ).ToList();
            //ViewBag.vlc = valuecategory;
            return View();
        }
        [HttpPost]
        public ActionResult DepartmentAdd(Department d)
        {
            dm.DepartmentAdd(d);
            return RedirectToAction("Index");
        }
        public ActionResult DepartmentDelete(int id)
        {
            var bul = dm.GetByID(id);
            dm.PassiveUpdate(bul);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult DepartmentUpdate(int id)
        {
            var bul = dm.GetByID(id);
            return View("DepartmentUpdate", bul);
        }
        [HttpPost]
        public ActionResult DepartmentUpdate(Department d)
        {
            dm.DepartmentUpdate(d);
            return RedirectToAction("Index");
        }
        public ActionResult DepartmentDetail(int id)
        {
            var bul = em.GetByDepartment(id);
            //var isim = bul.Select(x => x.Department.DepartmentName).FirstOrDefault();
            return View("DepartmentDetail", bul);
        }
        public ActionResult DepartmentEmployeeSales(int id)
        {
            var bul = sm.GetByEmployeeID(id);
            var isim = bul.Select(x => x.Employee.EmployeeName +" "+x.Employee.EmployeeSurname).FirstOrDefault();
            ViewBag.name = isim;
            return View(bul);
        }
    }
}