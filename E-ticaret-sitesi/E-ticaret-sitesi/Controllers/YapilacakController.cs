using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_ticaret_sitesi.Models.Siniflar;


namespace E_ticaret_sitesi.Controllers
{
    public class YapilacakController : Controller
    {
        // GET: Yapilacak
        Context c = new Context();
        public ActionResult Index()
        {
            var deger1 = c.Carilers.Count().ToString();//Carilerin sayısına ulaşıldı
            ViewBag.d1 = deger1;
            var deger2 = c.Uruns.Count().ToString();//Toplam Ürün sayısı
            ViewBag.d2 = deger2;
            var deger3 = c.Kategoris.Count().ToString();
            ViewBag.d3 = deger3;

            var deger4 = (from x in c.Carilers select x.CariSehir).Distinct().Count().ToString();
            ViewBag.d4 = deger4;

            var yapilacaklar =c.Yapilacaks.ToList();
            return View(yapilacaklar);
        }
    }
}