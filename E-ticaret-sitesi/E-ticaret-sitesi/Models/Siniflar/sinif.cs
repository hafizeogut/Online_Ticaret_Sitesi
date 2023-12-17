using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_ticaret_sitesi.Models.Siniflar
{
    public class sinif
    {
        public IEnumerable<Urun> Deger1 { set; get; }//URUN TABLOSUNDAN GELEN DEĞERLER BİR KOLEYKSİYON OLARAK TUTULDU
        public IEnumerable<Detay> Deger2 { set; get; }//Detay tablosundan gelen değerleri bir koleksiyon olarak tutuldu
    }
}