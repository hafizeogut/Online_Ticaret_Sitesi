using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_ticaret_sitesi.Models.Siniflar; 

namespace E_ticaret_sitesi.Controllers
{
    [Authorize]
    public class DepartmanController : Controller
    {

        Context c = new Context();
        // GET: Departman
        public ActionResult Index()
        {
            var degerler = c.Departmans.Where(x => x.Durum == true).ToList();
            return View(degerler);
        }
        [Authorize(Roles ="A")]
        [HttpGet]//Sayfa Aöıldığında
  
        public ActionResult DepartmanEkle()
        {
            return View();
        }

        [HttpPost]//Butona tıklandığında
        public ActionResult DepartmanEkle(Departman d)
        {
            c.Departmans.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanSil(int id)
        {
            var dep = c.Departmans.Find(id);
            dep.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanGetir(int id)
        {
            var dpt = c.Departmans.Find(id);
            return View("DepartmanGetir",dpt);
        }

        public ActionResult DepartmanGuncelle(Departman p)
        {
            var dept = c.Departmans.Find(p.Departmanid);
            dept.DepartmanAd = p.DepartmanAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }


    //    var dpt = c.Departmans
    //.Where(x => x.Departmanid == id)  // Departmans koleksiyonunu 'Departmanid' özelliği belirtilen 'id' değerine eşit olanlarla filtreleme
    //.Select(y => y.DepartmanAd)        // Filtrelenen koleksiyondaki her elemandan 'DepartmanAd' özelliğini seçme
    //.FirstOrDefault();                 // Seçilen koleksiyondan ilk (veya varsayılan) elemanı al

        public ActionResult DepartmanDetay(int id)
        {
            var degerler = c.Personels.Where(x => x.Departmanid == id).ToList();
            var dpt = c.Departmans.Where(x => x.Departmanid == id).Select(y => y.DepartmanAd).FirstOrDefault();
            ViewBag.d = dpt;//Controller tarafından View e veri taşıma işlemi yapıldı. D sanal bir değer.
            return View(degerler);
        }

        public ActionResult DepartmanPersonelSatis(int id)
        {
            var degerler = c.SatisHarekets.Where(x => x.Personelid == id).ToList();
            var per = c.Personels.Where(x => x.Personelid == id).Select(y => y.PersonelAd +" "+ y.PersonelSoyad).FirstOrDefault();
            ViewBag.dpers = per;
            return View(degerler);
        }



    }
}