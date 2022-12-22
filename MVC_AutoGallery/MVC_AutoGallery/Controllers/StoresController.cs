using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_AutoGallery.Models.Entity;

namespace MVC_AutoGallery.Controllers
{
    public class StoresController : Controller
    {
        // GET: Stores
        Auto_GalleryEntities db = new Auto_GalleryEntities();
        public ActionResult StoreList()
        {
            var values = db.Tbl_Stores.ToList();
            return View(values);
        }
        // SİLME - DELETE
        public ActionResult Delete(int id)
        {
            var strdelete = db.Tbl_Stores.Find(id);
            db.Tbl_Stores.Remove(strdelete);
            db.SaveChanges();
            return RedirectToAction("StoreList");
        }

        // EKLEME - CREATE
        [HttpGet]
        public ActionResult AddStore()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddStore(Tbl_Stores p1)
        {
            db.Tbl_Stores.Add(p1);
            db.SaveChanges();
            return View();
        }
    }
}