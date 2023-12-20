using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_ticaret_sitesi.Models.Siniflar
{
    public class Class3
    {
        // Kategori ve Urunler listesi kullanımlak için liste halinde oluşturukdu
        public IEnumerable<SelectListItem> Kategoriler { set; get; }
        public IEnumerable<SelectListItem> Urunler { set; get; } 
    }
}