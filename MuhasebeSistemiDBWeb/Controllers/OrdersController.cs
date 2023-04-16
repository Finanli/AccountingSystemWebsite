using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MuhasebeSistemiDBWeb.Models;

namespace MuhasebeSistemiDBWeb.Controllers
{
    public class OrdersController : Controller
    {
        MuhasebeSistemiEntities db = new MuhasebeSistemiEntities();
        // GET: Orders
        public ActionResult Index()
        {
            return View(db.Siparislers.ToList());
        }

        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(Siparisler save)
        {
            try
            {
                using (MuhasebeSistemiEntities db = new MuhasebeSistemiEntities())
                {
                    db.Siparislers.Add(save);
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
            using (MuhasebeSistemiEntities db = new MuhasebeSistemiEntities())
            {
                return View(db.Siparislers.Where(a=> a.SiparisNo == id).FirstOrDefault());
            }
        }

        [HttpPost]
        public ActionResult Edit(int id, Siparisler yenile) 
        {
            using (MuhasebeSistemiEntities db = new MuhasebeSistemiEntities())
            {
                db.Entry(yenile).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(int id)
        {
            return View(db.Siparislers.Where(a=> a.SiparisNo == id).FirstOrDefault());

        }
        [HttpPost]
        public ActionResult Delete(int id,Siparisler sil)
        {
            using (MuhasebeSistemiEntities db = new MuhasebeSistemiEntities())
            {
                sil = db.Siparislers.Where(a => a.SiparisNo == id).FirstOrDefault();
                db.Siparislers.Remove(sil); 
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}