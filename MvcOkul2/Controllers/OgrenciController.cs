using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOkul2.Models.Entitiy_Framework;

namespace MvcOkul2.Controllers
{
    public class OgrenciController : Controller
    {
        // GET: Ogrenci
        DbMvcOkulEntities db = new DbMvcOkulEntities();
        public ActionResult Index()
        {
            var ogrenciler = db.Tbl_Ogrenciler.ToList();
            return View(ogrenciler);
        }
        [HttpGet]
        public ActionResult YeniOgrenci()
        {
            List<SelectListItem> degerler = (from i in db.Tbl_Kulupler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KULUPAD,
                                                 Value = i.KULUPID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;

             return View();
        }
        [HttpPost]
        public ActionResult YeniOgrenci(Tbl_Ogrenciler p3)
        {
            var klp = db.Tbl_Kulupler.Where(m => m.KULUPID == p3.Tbl_Kulupler.KULUPID).FirstOrDefault();
            p3.Tbl_Kulupler = klp;
            db.Tbl_Ogrenciler.Add(p3);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult Sil(int id )
        {
            var ogrenci = db.Tbl_Ogrenciler.Find(id);
            db.Tbl_Ogrenciler.Remove(ogrenci);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult OgrenciGetir(int id)
        {
            var ogrenci = db.Tbl_Ogrenciler.Find(id);
            List<SelectListItem> degerler = (from i in db.Tbl_Kulupler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KULUPAD,
                                                 Value = i.KULUPID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View("OgrenciGetir", ogrenci);
        }
        public ActionResult Guncelle(Tbl_Ogrenciler p)
        {
            var ogr = db.Tbl_Ogrenciler.Find(p.OGRENCIID);
            ogr.OGRAD = p.OGRAD;
            ogr.OGRSOYAD = p.OGRSOYAD;
            ogr.OGRFOTOGRAF = p.OGRFOTOGRAF;
            ogr.OGRCICINSIYET = p.OGRCICINSIYET;
            ogr.OGRKULUP = p.OGRKULUP;
            db.SaveChanges();
            return RedirectToAction("Index", "Ogrenci");
        }
    }
}
//List<SelectListItem> items = new List<SelectListItem>();

//items.Add(new SelectListItem { Text = "Matematik", Value = "0" });

//items.Add(new SelectListItem { Text = "Fen Bilgisi", Value = "1" });

//items.Add(new SelectListItem { Text = "Atatürk İlke ve İnkilapları", Value = "2" });

//items.Add(new SelectListItem { Text = "Coğrafya", Value = "3" });

//items.Add(new SelectListItem { Text = "Edebiyat", Value = "4" });

//ViewBag.DersAd = items;