using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
 
using SeraOWebApi.Models;

namespace SeraOWebApi.Controllers
{
    public class KullaniciController : ApiController
    {

        SeraOBitirmeDbv1Entities _db=new SeraOBitirmeDbv1Entities();
        // GET: Kullanici

        [HttpPost]
        public bool KullaniciEkle(Kullanici data)
        {
            var Telno = data.TelNo;
            var Sifre = data.Sifre;
          
                if (Telno!=""&&Sifre!=""&&Telno!=null&&Sifre!=null)
                {
                    _db.Kullanicis.Add(data);
                    _db.SaveChanges();
                    return true;
                }
           

            return false;

        }
        [HttpGet]
        public bool KullaniciSil(int id)
        {

            var deg = _db.Kullanicis.FirstOrDefault(x => x.KullaniciId == id);
            if (deg!=null)
            {
                _db.Kullanicis.Remove(deg);
                _db.SaveChanges();
                return true;
            }
               
           
            return false;
        }

        [HttpGet]
        public List<Rol> RolListele()
        {

            List<Rol> data= _db.Rols.ToList();
            if (data!= null)
            {
                return data;

            }

            return data;



        }
        public bool RolEkle(Rol data)
        {


            Rol _data=new Rol();



            _data.Rol1 = data.Rol1;
            _data.RolIsim = data.RolIsim;

            if (_data.RolIsim!=null)
            {
                _db.Rols.Add(_data);
                _db.SaveChanges();
                return true;

            }

            return false;



        }


      [HttpGet]
        public List<Kullanici> KullaniciListe()
        {
            List<Kullanici> kdata=new List<Kullanici>(); 

            var deg = _db.Kullanicis.ToList();
            if (deg.Count >0)
            {
                return deg;
            }




            return kdata;
        }

        [HttpPost]
        public Kullanici Kullanici(Kullanici data)
        {
            var deg = _db.Kullanicis.FirstOrDefault(x => x.KullaniciId == data.KullaniciId);



            return deg;
        }
        [HttpPost]
        public bool KullaniciKontrol(Kullanici data)
        {

            var deg = _db.Kullanicis.FirstOrDefault(x => x.TelNo == data.TelNo);
            if (deg.TelNo!=null)
            {
                return true;
            }




            return false;
        }

        [HttpGet]
        public List<KullaniciRol> KullaniciRolId()
        {

           
            return _db.KullaniciRols.ToList();





        }
        [HttpGet]
        public List<Rol> Rol()
        {


            return _db.Rols.ToList();





        }



        [HttpPost]
        public bool KullaniciSeraEsle(Kullanici data)
        {

            var Kullanici = _db.Kullanicis.FirstOrDefault(x => x.KullaniciId == data.KullaniciId);

            var sera = _db.Seras.FirstOrDefault(x => x.SeraId == data.SeraId);


            Kullanici.SeraId = sera.SeraId;
            Kullanici.SeraKonum = sera.SeraKonum;

            _db.SaveChanges();





            return true;
        }

        [HttpPost]
        public bool KullaniciRolEsle(KullaniciRol data)
        {

            _db.KullaniciRols.Add(data);

            _db.SaveChanges();





            return true;
        }

    }
}