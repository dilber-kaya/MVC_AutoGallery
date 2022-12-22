using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_AutoGallery.Models.Entity;

namespace MVC_AutoGallery.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        Auto_GalleryEntities db = new Auto_GalleryEntities();
        public ActionResult EmployeeList()
        {
            var values = db.Tbl_Employee.ToList();
            return View(values);
        }

        // SİLME - DELETE
        public ActionResult Delete(int id)
        {
            var empdelete = db.Tbl_Employee.Find(id);
            db.Tbl_Employee.Remove(empdelete);
            db.SaveChanges();
            return RedirectToAction("EmployeeList");
        }

        // EKLEME - CREATE
        [HttpGet]
        public ActionResult AddEmployee()
        {
            List<SelectListItem> values = (from str in db.Tbl_Stores.ToList()
                                           select new SelectListItem
                                           {
                                               Text = str.Store_Name,
                                               Value = str.Store_Id.ToString()
                                           }
                                           ).ToList();
            ViewBag.Values = values;
            return View();
        }

        [HttpPost]
        public ActionResult AddEmployee(Tbl_Employee p1)
        {
            var str = db.Tbl_Stores.Where(m => m.Store_Id == p1.Tbl_Stores.Store_Id).FirstOrDefault();
            p1.Tbl_Stores = str;
            db.Tbl_Employee.Add(p1);
            db.SaveChanges();
            return RedirectToAction("EmployeeList");
        }

        //GÜNCELLEME - UPDATE 
        public ActionResult GetEmployee(int id)
        {
            List<SelectListItem> values = (from str in db.Tbl_Stores.ToList()
                                           select new SelectListItem
                                           {
                                               Text = str.Store_Name,
                                               Value = str.Store_Id.ToString()
                                           }
                                          ).ToList();
            ViewBag.Values = values;
            return View("GetEmployee", db.Tbl_Stores.Find(id));
        }
    }
}