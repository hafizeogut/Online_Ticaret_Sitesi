﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace E_ticaret_sitesi.Models.Siniflar
{
    public class Urun
    {
        [Key]
        public int Urunid { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string UrunAd { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Marka { get; set; }
        public short Stok { get; set; }
        public decimal AlisFiyat { get; set; }
        public decimal SatisFiyat { get; set; }
        public bool Durum { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string UrunGorsel { get; set; }
        public Kategori Kategori { get; set; } // her urunun sadece 1 tane kategorisi olduğundan bu tanımlama yapılmıştır.

        public ICollection<SatisHareket> SatisHarekets { get; set; }
    }
}