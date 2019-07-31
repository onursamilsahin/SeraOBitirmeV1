using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using SeraOWebApi.Models;


namespace SeraOWebApi.Controllers
{
    public class DataController : ApiController
    {

        SeraOBitirmeDbv1Entities _db=new SeraOBitirmeDbv1Entities();
        // GET: Data
        [HttpGet]
        public Dht11 SonDegerlerDht11()
        {





            return _db.Dht11.OrderByDescending(x=>x.ETarihi).FirstOrDefault();
        }
        [HttpGet]
        public TNem SonTNemDegeri()
        {

            return _db.TNems.OrderByDescending(x => x.ETarihi).FirstOrDefault();
        }

        //Listeler için Son Eklenen İlk Gelmeli
        [HttpGet]
        public List<Dht11> Dht11List()
        {

            return _db.Dht11.OrderByDescending(x => x.ETarihi).ToList();
        }
        //Grafik için Son Eklenen Sondan Gelmeli
        [HttpGet]
        public List<Dht11> Dht11ListTers()
        {

            return _db.Dht11.OrderBy(x => x.ETarihi).ToList();
        }

        [HttpGet]
        //BUrada Liste için verilerden son giren ilk çıkıyor.
        public List<TNem> TNemList()
        {


            return _db.TNems.OrderByDescending(x => x.ETarihi).ToList();
        }
        [HttpGet]
        //Burada grafik için son giren son çıkıyor.
        public List<TNem> TNemListTers()
        {


            return _db.TNems.OrderBy(x => x.ETarihi).ToList();
        }

        [HttpGet]
        public CatiKapak KapakDurumu()
        {


            return _db.CatiKapaks.FirstOrDefault(x => x.Id > 0);
        }

        [HttpPost]

        public string KapakDurumGuncelle(CatiKapak veriCatiKapak)
        {
            var _veri = _db.CatiKapaks.FirstOrDefault(x => x.Id > 0);


            if (veriCatiKapak!=null)
            {
                _veri.Kdurum = veriCatiKapak.Kdurum;

                _db.SaveChanges();
            }
            else
            {
                return "500";
            }

            

            return "200";




        }

        [HttpGet]
        public SuPompasi SpDurumu()
        {


            return _db.SuPompasis.FirstOrDefault(x=>x.Id>0);

        }

        [HttpPost]
        public string SuPompasiDurumGuncelle(SuPompasi veriSuPompasi)
        {

            var _veri = _db.SuPompasis.FirstOrDefault(x => x.Id > 0);
            if (veriSuPompasi!=null)
            {
                _veri.SPDurum = veriSuPompasi.SPDurum;
                _db.SaveChanges();
            }
            else
            {

                return "500";

            }

            return "200";





        }
        [HttpGet]
        public LedDurum LedDurumDon()
        {



            return _db.LedDurums.FirstOrDefault(x => x.Id > 0);

        }


        [HttpPost]

        public string LedDurumGuncelle(LedDurum veriLedDurum )
        {

         var _veri=_db.LedDurums.FirstOrDefault(x => x.Id > 0);

            if (veriLedDurum!=null)
            {

                _veri.LDurum = veriLedDurum.LDurum;
                _db.SaveChanges();

            }
            else
            {
                return "500";
            }

            return "200";


        }


    }
}