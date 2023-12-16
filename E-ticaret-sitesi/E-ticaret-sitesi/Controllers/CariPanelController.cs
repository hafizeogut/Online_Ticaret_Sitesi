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
    }
}