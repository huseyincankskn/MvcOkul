using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOkul2.Models.Entitiy_Framework;

namespace MvcOkul2.Controllers
{
    public class KuluplerController : Controller
    {
        // GET: Kulupler
        DbMvcOkulEntities db = new DbMvcOkulEntities();
        public ActionResult Index()
        {
            var kulupler = db.Tbl_Kulupler.ToList();
            return View(kulupler);
        }
        [HttpGet]
        public ActionResult Yenikulup()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Yenikulup(Tbl_Kulupler p2)
        {
            db.Tbl_Kulupler.Add(p2);
            db.SaveChanges();
            return View();
        }
        public ActionResult Sil(int id)
        {
            var kulup = db.Tbl_Kulupler.Find(id);
            db.Tbl_Kulupler.Remove(kulup);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KulupGetir(int id)
        {
            var kulup = db.Tbl_Kulupler.Find(id);
            return View("KulupGetir",kulup);
        }
        public ActionResult Guncelle(Tbl_Kulupler p)
        {
            var klp = db.Tbl_Kulupler.Find(p.KULUPID);
            klp.KULUPAD = p.KULUPAD;
            db.SaveChanges();
            return RedirectToAction("Index", "Kulupler");
        }
    }
}