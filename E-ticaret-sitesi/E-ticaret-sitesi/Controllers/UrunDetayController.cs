﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_ticaret_sitesi.Models.Siniflar;
namespace E_ticaret_sitesi.Controllers
{
    public class UrunDetayController : Controller
    {
        Context c = new Context();
        // GET: UrunDetay
        public ActionResult Index()
        {
            sinif cs = new sinif();
            //var degerler = c.Uruns.Where(x => x.Urunid == 1).ToList();
            cs.Deger1 = c.Uruns.Where(x => x.Urunid == 1).ToList();
            cs.Deger2 = c.Detays.Where(y => y.DetayID == 1).ToList();
            return View(cs);
        }
    }
}