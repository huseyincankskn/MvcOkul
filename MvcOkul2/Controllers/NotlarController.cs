using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOkul2.Models.Entitiy_Framework;
using MvcOkul2.Models;

namespace MvcOkul2.Controllers
{
    public class NotlarController : Controller
    {
        // GET: Notlar
        DbMvcOkulEntities db = new DbMvcOkulEntities();
        public ActionResult Index()
        {
            var sinavnotlar = db.Tbl_Notlar.ToList();
            
            return View(sinavnotlar);
        }
        [HttpGet]
        public ActionResult YeniSinav()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniSinav(Tbl_Notlar tbn)
        {
            db.Tbl_Notlar.Add(tbn);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult NotGetir(int id)
        {
            var notlar = db.Tbl_Notlar.Find(id);
            return View("NotGetir", notlar);
        }
        [HttpPost]
        public ActionResult NotGetir(Class1 model,Tbl_Notlar p, int SINAV1=0, int SINAV2=0, int SINAV3=0, int PROJE=0)
        {
            if(model.islem=="HESAPLA")
            {
                //islem1
                int ORTALAMA = (SINAV1 + SINAV2 + SINAV3 + PROJE) / 4;
                ViewBag.ort = ORTALAMA;
                
            }
            if (model.islem == "NOTGUNCELLE")
            {
                //islem2
                var snv = db.Tbl_Notlar.Find(p.NOTID);
                snv.SINAV1 = p.SINAV1;
                snv.SINAV2 = p.SINAV2;
                snv.SINAV3 = p.SINAV3;
                snv.PROJE = p.PROJE;
                snv.ORTALAMA = p.ORTALAMA;
                db.SaveChanges();
                return RedirectToAction("Index", "Notlar");
            }
            return View();
        }
    }
}