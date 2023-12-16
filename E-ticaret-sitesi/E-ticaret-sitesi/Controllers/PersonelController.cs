using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_ticaret_sitesi.Models.Siniflar;


namespace E_ticaret_sitesi.Controllers
{
    public class PersonelController : Controller
    {
        Context c = new Context();
        // GET: Personel
        public ActionResult Index()
        {
            var degerler = c.Personels.ToList();
            return View(degerler);
        }
        [HttpGet]//form yüklendipinde bu metodu çalıstır
        public ActionResult PersonelEkle()
        {
            List<SelectListItem> deger1 = (from x in c.Departmans.ToList() select new SelectListItem { Text = x.DepartmanAd, Value = x.Departmanid.ToString() }).ToList();
            ViewBag.dgr1 = deger1; 
            return View();
        }

        [HttpPost]//Bir butona tıklandığı zaman bu metodu çalıstır
        public ActionResult PersonelEkle(Personel p)
        {
            if (Request.Files.Count>0)
            {
                string dasyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + dasyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.PersonelGorsel="/Image/"+ dasyaadi + uzanti;
            }
            c.Personels.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult PersonelGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Departmans.ToList() select new SelectListItem { Text = x.DepartmanAd, Value = x.Departmanid.ToString() }).ToList();
            ViewBag.dgr1 = deger1;
            var prs = c.Personels.Find(id);
            return View("PersonelGetir",prs);
        }
        public ActionResult PersonelGuncelle(Personel p)
        {
            if (Request.Files.Count > 0)
            {
                string dasyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + dasyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.PersonelGorsel = "/Image/" + dasyaadi + uzanti;
            }
            var prsn = c.Personels.Find(p.Personelid);
            prsn.PersonelAd = p.PersonelAd;
            prsn.PersonelSoyad = p.PersonelSoyad;
            prsn.PersonelGorsel = p.PersonelGorsel;
            prsn.Departmanid = p.Departmanid;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonleListe()
        {
            var sorgu = c.Personels.ToList();
            return View(sorgu);
        }
        
         
    }



}