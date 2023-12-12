﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_ticaret_sitesi.Models.Siniflar;

namespace E_ticaret_sitesi.Controllers
{
    public class istatistikController : Controller
    {
        // GET: istatistik
        Context c = new Context();

        public ActionResult Index()
        {
            var deger1 = c.Carilers.Count().ToString();
            ViewBag.d1 = deger1;

            var deger2 = c.Uruns.Count().ToString();
            ViewBag.d2 = deger2;

            var deger3 = c.Personels.Count().ToString();
            ViewBag.d3 = deger3;

            var deger4 = c.Carilers.Count().ToString();
            ViewBag.d4 = deger4;

            var deger5 = c.Uruns.Sum(x=>x.Stok).ToString();//Stoklara erişildi
            ViewBag.d5 = deger5;

            var deger6 = (from x in c.Uruns select x.Marka).Distinct().Count().ToString();
            ViewBag.d6 = deger6;


            var deger7 = c.Uruns.Count(x => x.Stok<=20).ToString(); //Stok 20 den az kalmış ürünler sayıldı.
            ViewBag.d7 = deger7;

            var deger8 = (from x in c.Uruns orderby x.SatisFiyat descending select x.UrunAd).FirstOrDefault();
            //elemanları SatisFiyat özelliğine göre azalan sırayla sıralıyor.
            //select x.UrunAd: Bu kısım, her elemanın UrunAd özelliğini seçiyor.
            ViewBag.d8 = deger8;

            var deger9 = (from x in c.Uruns orderby x.SatisFiyat ascending select x.UrunAd).FirstOrDefault();//Üürnler araında satis sayısını sırala Urun adına göre seç
            ViewBag.d9 = deger9;//En ucuz ürün d9 aatandı 
            //Elemanlar, SatisFiyat özelliğine göre artan sırayla sıralanır.

            var deger10 = c.Uruns.Count(x => x.UrunAd == "Buzdolabı").ToString();
            ViewBag.d10 = deger10;

            var deger11 = c.Uruns.Count(x => x.UrunAd == "Laptop").ToString();
            ViewBag.d11 = deger11;

            //Max Marka Ürün tablo içerisinde ismi en fazla geçen marka
            //c.Uruns.GroupBy(x => x.Marka)-> Ürünler markaya göre gruplandırıldı
            //OrderByDescending(z => z.Count()).Select(y => y.Key) Bu Markaları adedine (Kaç tane olduğuna göre) sırala sayısı en fazla olan en başta olacaktır
            //Select(y => y.Key).FirstOrDefault() Marka değerini seçip ve getirildi
            var deger12 = c.Uruns.GroupBy(x => x.Marka).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault();
            ViewBag.d12 = deger12;


            // c.SatisHarekets.GroupBy(x => x.Urunid  ---> SatisHareket tablosunu ürün id ye göre gruplandır
            //OrderByDescending(z =>z.Count()) en üstekki değer doğrultusunda sırala

            //c.SatisHarekets.GroupBy(x => x.Urunid).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault()) Satısı en fazla olan id ye ulaşıldı
            var deger13 = c.Uruns.Where(u => u.Urunid ==( c.SatisHarekets.GroupBy(x => x.Urunid).OrderByDescending(z => 
            z.Count()).Select(y => y.Key).FirstOrDefault())).Select(k =>k.UrunAd).FirstOrDefault();
            ViewBag.d13 = deger13;


            var deger14 = c.SatisHarekets.Sum(x => x.ToplamTutar).ToString();//Toplam Tuatra erişildi
            ViewBag.d14 = deger14;

            DateTime bugun = DateTime.Today;
            var deger15 = c.SatisHarekets.Count(x => x.Tarih==bugun).ToString();
            ViewBag.d15 = deger15;

            var deger16 = c.SatisHarekets.Where(x => x.Tarih == bugun).Sum(y => y.ToplamTutar).ToString();
            ViewBag.d16 = deger16;

            return View();
            
        }
    }
}