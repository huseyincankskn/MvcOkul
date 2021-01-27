using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOkul2.Controllers
{
    public class HesapTestController : Controller
    {
        // GET: HesapTest
        public ActionResult Index(int s1 = 0, int s2 = 0, int s3=0, int p=0)
        {
            decimal ort = (s1 + s2 + s3 + p)/4;
            ViewBag.snc = ort;
            return View();
        }
    }
}