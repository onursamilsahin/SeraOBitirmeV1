using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
 
using SeraOWebApi.Models;

namespace SeraOWebApi.Controllers
{
    public class SeraController : ApiController
    {
        SeraOBitirmeDbv1Entities _db=new SeraOBitirmeDbv1Entities();
        // GET: Sera
       

        public bool SeraEkle(Sera Data)
        {

            if (Data!=null)
            {
                _db.Seras.Add(Data);
                _db.SaveChanges();
                return true;
            }

            return false;



        }
        [HttpGet]
        public List<Sera> SeraListele()
        {

            return _db.Seras.ToList();
           
 
        }
    }
}