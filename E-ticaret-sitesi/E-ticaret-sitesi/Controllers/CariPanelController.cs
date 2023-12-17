using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_ticaret_sitesi.Models.Siniflar;

namespace E_ticaret_sitesi.Controllers
{
    public class CariPanelController : Controller
    {
        // GET: CariPanel
        
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var mail = (string)Session["CariMail"];//Veri tabanındaki mail adresine ulaşıldı
            var degerler = c.Carilers.FirstOrDefault(x => x.CariMail == mail);
            ViewBag.m = mail;
            return View(degerler);
        }
        public ActionResult Siparislerim()
        {
            var mail = (string)Session["CariMail"];//Session a sisteme girilen mail adresi atandı
            var id = c.Carilers.Where(x => x.CariMail == mail.ToString()).Select(y
                      => y.Cariid).FirstOrDefault();//Sisteme giriş yapılan mail adresinin idsi alındı

            var degerler = c.SatisHarekets.Where(x => x.Cariid == id).ToList();
            return View(degerler);
        }

        public ActionResult GelenMesajlar()
        {
            return View();
        }
        //[HttpGet]
        //public ActionResult YeniMesaj()
        //{
        //    return View();
            
        //}
        //[HttpPost]
        //public ActionResult YeniMesaj()
        //{
        //    return View();

        //}
    }
}