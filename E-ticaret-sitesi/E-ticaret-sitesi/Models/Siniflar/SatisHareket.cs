using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_ticaret_sitesi.Models.Siniflar
{
    public class SatisHareket
    {

        [Key]
        public int Satisid { get; set; }
        //ürün
        //cari
        //personel
        public DateTime Tarih { get; set; }
        public int Adet { get; set; }
        public decimal Fiyat { get; set; }
        public decimal ToplamTutar { get; set; }



        public int Urunid { set; get; }
        public int Cariid { set; get; }
        public int Personelid { set; get; }



        public virtual Urun Urun { get; set; }
        public virtual Cariler Cariler { get; set; }
        public virtual Personel Personel { get; set; }
    }
}