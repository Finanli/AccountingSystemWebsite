using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MuhasebeSistemiDBWeb.Models;

namespace MuhasebeSistemiDBWeb.Controllers
{
    public class ProductsController : Controller
    {
        MuhasebeSistemiEntities db = new MuhasebeSistemiEntities();
        // GET: Products
        public ActionResult Index()
        {
            return View(db.Urunlers.ToList());
        }

        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(Urunler save)
        {
            try
            {
                using (MuhasebeSistemiEntities db = new MuhasebeSistemiEntities())
                {
                    db.Urunlers.Add(save);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch 
            {

                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            return View(db.Urunlers.Where(a=> a.UrunNo == id).FirstOrDefault());

        }

        [HttpPost]
        public ActionResult Edit(int id, Urunler yenile)
        {
            db.Entry(yenile).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");   
        }

        public ActionResult Delete(int id)
        {
            return View(db.Urunlers.Where(a=> a.UrunNo == id).FirstOrDefault());

        }

        [HttpPost]
        public ActionResult Delete(int id, Urunler sil)
        {
            sil = db.Urunlers.Where(a=> a.UrunNo == id).FirstOrDefault();
            db.Urunlers.Remove(sil);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}