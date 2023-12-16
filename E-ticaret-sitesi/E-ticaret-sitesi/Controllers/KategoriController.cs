using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_ticaret_sitesi.Models.Siniflar;
using PagedList;
using PagedList.Mvc;

namespace E_ticaret_sitesi.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        //Contedxte tablolar tutuluyor.
        Context c = new Context();//Context sınıfından bir nesne oluşturuldu
        public ActionResult Index(int sayfa=1)
        {
            //var türü bütün değişkenleri alıyor
            var degerler = c.Kategoris.ToList().ToPagedList(sayfa,4);
            return View(degerler);
        }

        [HttpGet]//form yüklendipinde bu metodu çalıstır
        public ActionResult KategoriEkle()
        {
            return View();
        }

        [HttpPost]//Bir butona tıklandığı zaman bu metodu çalıstır
        public ActionResult KategoriEkle(Kategori k)
        {
            c.Kategoris.Add(k);// Context  Sınıdı nesnesi olan c ye katori sınıf nesnesi olan k yı ekle
            c.SaveChanges(); //Değişikleri kaydet
            return RedirectToAction("Index");// "Index" adlı başka bir action'a yönlendir
            //Action metodu, bir formdan alınan kategori bilgilerini veritabanına eklemek için kullanılır.

        }
        public ActionResult KategoriSil(int id)
        {
            var kate = c.Kategoris.Find(id);
            c.Kategoris.Remove(kate);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var kategori = c.Kategoris.Find(id);
            return View("KategoriGetir", kategori);
         
        }
        public ActionResult KategoriGuncelle(Kategori k)
        {
            var ktgr = c.Kategoris.Find(k.KategoriID);//kategoriId ye göre bulundu
            ktgr.KategoriAd = k.KategoriAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}