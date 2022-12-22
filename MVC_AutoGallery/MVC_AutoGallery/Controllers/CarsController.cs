using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_AutoGallery.Models.Entity;

namespace MVC_AutoGallery.Controllers
{
    public class CarsController : Controller
    {
        // GET: Cars
        Auto_GalleryEntities db = new Auto_GalleryEntities();
        public ActionResult CarsList()
        {
            var values = db.Tbl_Cars.ToList();
            return View(values);
        }
        // SİLME - DELETE
        public ActionResult Delete(int id)
        {
            var cardelete = db.Tbl_Cars.Find(id);
            db.Tbl_Cars.Remove(cardelete);
            db.SaveChanges();
            return RedirectToAction("CarsList");
        }

        // EKLEME - CREATE
        [HttpGet]
        public ActionResult AddCar()
        {
            List<SelectListItem> values = (from str in db.Tbl_Stores.ToList()
                                           select new SelectListItem
                                           {
                                               Text = str.Store_Name,
                                               Value = str.Store_Id.ToString()
                                           }
                                          ).ToList();
            ViewBag.Stores = values;

            List<SelectListItem> values2 = (from str in db.Tbl_Models.ToList()
                                           select new SelectListItem
                                           {
                                               Text = str.Model_Name,
                                               Value = str.Model_Id.ToString()
                                           }
                                         ).ToList();
            ViewBag.Models = values2;

            List<SelectListItem> values3 = (from str in db.Tbl_Brands.ToList()
                                           select new SelectListItem
                                           {
                                               Text = str.Brand_Name,
                                               Value = str.Brand_Id.ToString()
                                           }
                                         ).ToList();
            ViewBag.Brands = values3;
            return View();
        }

        [HttpPost]
        public ActionResult AddCar(Tbl_Cars p1)
        {
            var str = db.Tbl_Stores.Where(m => m.Store_Id == p1.Tbl_Stores.Store_Id).FirstOrDefault();
            p1.Tbl_Stores = str;
            var mdl = db.Tbl_Models.Where(m => m.Model_Id == p1.Tbl_Models.Model_Id).FirstOrDefault();
            p1.Tbl_Models = mdl;
            var brd = db.Tbl_Brands.Where(m => m.Brand_Id == p1.Tbl_Models.Tbl_Brands.Brand_Id).FirstOrDefault();
            p1.Tbl_Models.Tbl_Brands = brd;
            db.Tbl_Cars.Add(p1);
            db.SaveChanges();
            return RedirectToAction("CarsList");
        }
    }
}