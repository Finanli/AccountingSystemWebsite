using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MuhasebeSistemiDBWeb.Models;

namespace MuhasebeSistemiDBWeb.Controllers
{
    public class CostsController : Controller
    {
        MuhasebeSistemiEntities db = new MuhasebeSistemiEntities();
        // GET: Costs
        public ActionResult Index()
        {
            return View(db.Giderlers.ToList());
        }

        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(Giderler save)
        {
            try
            {
                using (MuhasebeSistemiEntities db = new MuhasebeSistemiEntities())
                {
                    db.Giderlers.Add(save);
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
            return View(db.Giderlers.Where(a => a.GiderNo == id).FirstOrDefault());

        }

        [HttpPost]
        public ActionResult Edit(int id, Giderler yenile)
        {
            db.Entry(yenile).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            return View(db.Giderlers.Where(a => a.GiderNo == id).FirstOrDefault());

        }

        [HttpPost]
        public ActionResult Delete(int id, Giderler sil)
        {
            sil = db.Giderlers.Where(a => a.GiderNo == id).FirstOrDefault();
            db.Giderlers.Remove(sil);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}