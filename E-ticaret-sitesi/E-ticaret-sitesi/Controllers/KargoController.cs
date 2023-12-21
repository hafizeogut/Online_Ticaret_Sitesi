using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_ticaret_sitesi.Models.Siniflar;
namespace E_ticaret_sitesi.Controllers
{
    public class KargoController : Controller
    {
        // GET: KargoDetay
        Context c = new Context();
        public ActionResult Index(string p)
        {
            var k = from x in c.KargoDetays select x;
            if (!string.IsNullOrEmpty(p))
            {
                k = k.Where(y => y.TakipKodu.Contains(p));
            }
            return View(k.ToList());
        }
        [HttpGet]//Sayfa Aöıldığında
        public ActionResult YeniKargo()
        {
            //Rastgele Kargo Kodu Oluşturuluyor
            Random rnd = new Random();
            string[] Karakterler = { "A", "B", "C", "D","F","G","H","K"};
            int k1, k2, k3;
            k1 = rnd.Next(0, Karakterler.Length);
            k2 = rnd.Next(0, Karakterler.Length);
            k3 = rnd.Next(0, Karakterler.Length);

            int s1, s2, s3;
            s1 = rnd.Next(100, 1000);
            s2 = rnd.Next(10, 99);
            s3 = rnd.Next(10, 99);

            string kod = s1.ToString() + Karakterler[k1] + s2 + Karakterler[k2] + s3 + Karakterler[k3];
            ViewBag.takipkod = kod;
            return View();
        }

        [HttpPost]//Butona tıklandığında
        public ActionResult YeniKargo(KargoDetay d)
        {
            c.KargoDetays.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KargoTakip(string id)
        { 
            var degerler = c.KargoTakips.Where(x => x.TakipKodu == id).ToList();  
            return View(degerler);
        }
    }
}