using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using PagedList;
using SeraOWeb.Models.DataAccess;

namespace SeraOWeb.Controllers
{
    public class HomeController : Controller
    {

        HttpClient _client=new HttpClient();
        public async Task<ActionResult> Index()
        {
            //Session a Login Kısmında ekleme yapılıyor Session ın var olup olmadığı ile kullanıcı girişi yapılıyor.
           var kontrol = Session["Kullanici"];
            if (ValidateRequest)
            {

                if (kontrol != null)
                {
                    var TelNo  = Session["Kullanici"].ToString();
                    var result = await _client.GetAsync("http://localhost:55502/api/Kullanici/KullaniciListe");

                    var resultString = await result.Content.ReadAsStringAsync();

                    var resultDeger = JsonConvert.DeserializeObject<List<Kullanici>>(resultString);

                    Kullanici deg = resultDeger.Find(x => x.TelNo == TelNo);

                    ViewBag.Kullanici = deg.Isim + " " + deg.SoyIsim;

                    return View();


                }
            }

            return RedirectToAction("Login", "Home");


        }



        public ActionResult ProfilSayfasi()
        {



            return View();
        }
        //Bu partial da hem hava hem sıcaklık değerleri ekrana gönderiliyor.
        public async Task<PartialViewResult> SonSeraSicakligi()
        {

            var result = await _client.GetAsync("http://localhost:55502/api/Data/SonDegerlerDht11");

            var resultString = await result.Content.ReadAsStringAsync();

            var resultDeger = JsonConvert.DeserializeObject<Dht11>(resultString);


            return PartialView("_SonSeraSicakligi",resultDeger);
        }

        public async  Task<PartialViewResult> SonHavaNemOrani()
        {

           


            return PartialView("_SonHavaNemOrani");
        }
        public async Task<PartialViewResult> SonToprakNem()
        {
            var result = await _client.GetAsync("http://localhost:55502/api/Data/SonTNemDegeri");

            var resultString = await result.Content.ReadAsStringAsync();

            var resultDeger = JsonConvert.DeserializeObject<TNem>(resultString);


            return PartialView("_SonToprakNem", resultDeger);
        }



        public ActionResult SeraYonetim()
        {



            return View();
        }

        public async Task<ActionResult> HavaKontrolu()
        {

            var result = await _client.GetAsync("http://localhost:55502/api/Data/SonDegerlerDht11");

            var resultString = await result.Content.ReadAsStringAsync();

            var resultDeger = JsonConvert.DeserializeObject<Dht11>(resultString);

            var result2 = await _client.GetAsync("http://localhost:55502/api/Data/KapakDurumu");

            var resultString2 = await result2.Content.ReadAsStringAsync();

            var resultDeger2 = JsonConvert.DeserializeObject<CatiKapak>(resultString2);

            ViewBag.KapakDurum = resultDeger2.Kdurum;


            return View(resultDeger);
        }

        public ActionResult SicaklikKontrolu()
        {



            return View();
        }


        public async Task<ActionResult> SulamaKontrolu()
        {

            var result = await _client.GetAsync("http://localhost:55502/api/Data/SonTNemDegeri");

            var resultString = await result.Content.ReadAsStringAsync();

            var resultDeger = JsonConvert.DeserializeObject<TNem>(resultString);

            var result2 = await _client.GetAsync("http://localhost:55502/api/Data/SpDurumu");
            var resultString2 = await result2.Content.ReadAsStringAsync();

            var resultDeger2 = JsonConvert.DeserializeObject<SuPompasi>(resultString2);


            ViewBag.SuPompasiDurum = resultDeger2.SPDurum;

            return View(resultDeger);
        }

        public async  Task<ActionResult> AydinlatmaKontrolu()
        {
            var result = await _client.GetAsync("http://localhost:55502/api/Data/LedDurumDon");

            var resultString = await result.Content.ReadAsStringAsync();

            var resultDeger = JsonConvert.DeserializeObject<LedDurum>(resultString);


            return View(resultDeger);
        }

        public ActionResult About()
        {
            var kontrol = Session["Kullanici"];
            if (ValidateRequest)
            {
                if (kontrol!=null)
                {


                    ViewBag.Message = "Your application description page.";

                    return View();

                }
                


            }

            return RedirectToAction("Login", "Home");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult Login()
        {
            var kontrol = Session["Kullanici"];

            if (kontrol != null)
            {
                return RedirectToAction("Index", "Home");
            }


            return View();
        }
        [HttpPost]
     
        //Login olması için Telno ve sifrenin varlığı kontrol ediliyor eğer var ise  session ataması gerçekleşiyor.
        public async Task<ActionResult> Login(string TelNo,string Sifre)
        {
           
                var result = await _client.GetAsync("http://localhost:55502/api/Kullanici/KullaniciListe");

                var resultString = await result.Content.ReadAsStringAsync();

                var resultDeger = JsonConvert.DeserializeObject<List<Kullanici>>(resultString);

                Kullanici deg = resultDeger.Find(x => x.TelNo == TelNo && x.Sifre == Sifre);

                if (deg != null)
                {


                    Session["Kullanici"] = deg.TelNo;

                    return RedirectToAction("Index", "Home");
                }
         







            return RedirectToAction("Login", "Home");
        }

        [HttpGet]
        public ActionResult CikisYap()
        {

            var deg = Session["Kullanici"];
            if (deg!=null)
            {
                Session.Remove("Kullanici");
            }
            else
            {
             return   RedirectToAction("Login", "Home");
            }

         return  RedirectToAction("Login", "Home");





        }

    
        //Hava kontrolu sayfasında li veri listesi metot u
        public async Task<ActionResult> HavaNemList(int page = 1,int pageSize = 10)
        {
        
            var result = await _client.GetAsync("http://localhost:55502/api/Data/Dht11List");

            var resultString = await result.Content.ReadAsStringAsync();

            var resultDeger = JsonConvert.DeserializeObject<List<Dht11>>(resultString);


            PagedList<Dht11> DegerModel = new PagedList<Dht11>(resultDeger, page, pageSize);

            return View(DegerModel);
        }

        public async Task<ActionResult> SicaklikList(int page = 1, int pageSize = 10)
        {

            var result = await _client.GetAsync("http://localhost:55502/api/Data/Dht11List");

            var resultString = await result.Content.ReadAsStringAsync();

            var resultDeger = JsonConvert.DeserializeObject<List<Dht11>>(resultString);


            PagedList<Dht11> DegerModel = new PagedList<Dht11>(resultDeger, page, pageSize);

            return View(DegerModel);
        }
        public async Task<ActionResult> TNemList(int page = 1, int pageSize = 10)
        {

            var result = await _client.GetAsync("http://localhost:55502/api/Data/TNemList");

            var resultString = await result.Content.ReadAsStringAsync();

            var resultDeger = JsonConvert.DeserializeObject<List<TNem>>(resultString);


            PagedList<TNem> DegerModel = new PagedList<TNem>(resultDeger, page, pageSize);

            return View(DegerModel);
        }
        //partialllar


            [HttpGet]  //Hava Kontrolu Sayfasındaki Son Hava nem için Partialview.....
        public async Task<PartialViewResult> SonHavaNemHKS()
        {
            var result = await _client.GetAsync("http://localhost:55502/api/Data/SonDegerlerDht11");

            var resultString = await result.Content.ReadAsStringAsync();

            var resultDeger = JsonConvert.DeserializeObject<Dht11>(resultString);

            var result2 = await _client.GetAsync("http://localhost:55502/api/Data/KapakDurumu");

            var resultString2 = await result2.Content.ReadAsStringAsync();

            var resultDeger2 = JsonConvert.DeserializeObject<CatiKapak>(resultString2);

            ViewBag.KapakDurum = resultDeger2.Kdurum;

            return PartialView("_SonHavaNemHKS", resultDeger);

        }

        //Anasayfadaki saat ve hava durumu için gerekli partial
        public PartialViewResult SonSaatVeHava()
        {
          

            return PartialView("_SonSaatVeHava");

        }



        [HttpGet]  //Sulama Kontrolu Sayfasındaki Son Toprak nem için Partialview.....SKS sulama kontrol sayfası
        public async Task<PartialViewResult> sonTNemSKS()
        {
            var result = await _client.GetAsync("http://localhost:55502/api/Data/SonTNemDegeri");

            var resultString = await result.Content.ReadAsStringAsync();

            var resultDeger = JsonConvert.DeserializeObject<TNem>(resultString);

            var result2 = await _client.GetAsync("http://localhost:55502/api/Data/SpDurumu");
            var resultString2 = await result2.Content.ReadAsStringAsync();

            var resultDeger2 = JsonConvert.DeserializeObject<SuPompasi>(resultString2);


            ViewBag.SuPompasiDurum = resultDeger2.SPDurum;

            return PartialView("_sonTNemSKS", resultDeger);

        }



    }
}