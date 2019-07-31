using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SeraOWeb.Controllers
{
    public class LimitController : Controller
    {
        // GET: Limit


        public ActionResult HavaLimitKontrol(string Limit)
        {



            return RedirectToAction("HavaKontrolu", "Home");
        }

        public ActionResult SicaklikLimitKontrol(string Limit)
        {



            return RedirectToAction("SicaklikKontrolu", "Home");
        }

        public ActionResult SulamaLimitKontrolu(string Limit)
        {


            return RedirectToAction("SulamaKontrolu", "Home");
        }


    }
}