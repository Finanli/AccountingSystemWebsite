using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MuhasebeSistemiDBWeb.Models;

namespace MuhasebeSistemiDBWeb.Controllers
{
   
    public class CustAdminController : Controller
    {
        MuhasebeSistemiEntities db = new MuhasebeSistemiEntities();
        // GET: CustAdmin
        public ActionResult Index()
        {
            return View(db.Musterilers.ToList());
        }
        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(Musteriler save)
        {
            try
            {
                using (MuhasebeSistemiEntities db = new MuhasebeSistemiEntities())
                {
                    db.Musterilers.Add(save);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch 
            {

               return View() ;
            }    
            
                
        }

        public ActionResult Edit(int id)
        {
            using (MuhasebeSistemiEntities db = new MuhasebeSistemiEntities())
            {
                return View(db.Musterilers.Where(a => a.MusteriNo == id).FirstOrDefault());
            }    
                
        }

        [HttpPost]
        public ActionResult Edit(int id, Musteriler yenile)
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
            using (MuhasebeSistemiEntities db = new MuhasebeSistemiEntities())
            {
                return View(db.Musterilers.Where(a => a.MusteriNo == id).FirstOrDefault());
            }
                
        }

        [HttpPost]
        public ActionResult Delete(int id, Musteriler sil)
        {
            using (MuhasebeSistemiEntities db = new MuhasebeSistemiEntities())
            {
                sil = db.Musterilers.Where(a => a.MusteriNo == id).FirstOrDefault();
                db.Musterilers.Remove(sil);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
                
        }

    }
}