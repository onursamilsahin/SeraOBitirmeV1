using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeraOWeb.Models.DataAccess
{
    public class Kullanici
    {

        public int KullaniciId { get; set; }

        public string KullaniciAdi { get; set; }

        public string Isim { get; set; }

        public string SoyIsim { get; set; }
        public int SeraId { get; set; }

        public string SeraKonum { get; set; }

        public string TelNo { get; set; }

        public string Sifre { get; set; }

        public DateTime KayitTarihi { get; set; }



    }
}