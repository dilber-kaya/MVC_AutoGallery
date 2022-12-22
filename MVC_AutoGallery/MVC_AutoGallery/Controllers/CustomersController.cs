using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_AutoGallery.Models.Entity;

namespace MVC_AutoGallery.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        Auto_GalleryEntities db = new Auto_GalleryEntities();
        public ActionResult CustomerList()
        {
            var values = db.Tbl_Customers.ToList();
            return View(values);
        }
        // SİLME - DELETE
        public ActionResult Delete(int id)
        {
            var custdelete = db.Tbl_Customers.Find(id);
            db.Tbl_Customers.Remove(custdelete);
            db.SaveChanges();
            return RedirectToAction("CustomerList");
        }

        // EKLEME - CREATE
        [HttpGet]
        public ActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCustomer(Tbl_Customers p1)
        {
            db.Tbl_Customers.Add(p1);
            db.SaveChanges();
            return View();
        }
    }
}