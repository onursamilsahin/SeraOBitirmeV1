using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using SeraOWeb.Models.DataAccess;

namespace SeraOWeb.Controllers
{
    public class AdminController : Controller
    {

        HttpClient _client=new HttpClient();
        // GET: Admin   http://localhost:55502
        public async Task<ActionResult> Index()
        {

            var result = await _client.GetAsync("http://localhost:55502/api/Kullanici/KullaniciListe");

            var resultString = await result.Content.ReadAsStringAsync();

            var resultDeger = JsonConvert.DeserializeObject<List<Kullanici>>(resultString);

            return View(resultDeger);
        }

        public ActionResult KullaniciKayit()
        {




            return View();
        }
        [HttpPost]
        public async Task<ActionResult> KullaniciKayit(Kullanici data)
        {
            _client.BaseAddress = new Uri("http://localhost:55502/api/Kullanici/KullaniciEkle");

            StringContent content = new StringContent(JsonConvert.SerializeObject(data), System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = _client.PostAsync("http://localhost:55502/api/Kullanici/KullaniciEkle", content).Result;
         

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index","Admin");
            }


            return RedirectToAction("KullaniciKayit", "Admin");



        
        }
        [HttpGet]
        public async Task<ActionResult> SeraListe()
        {

            var result = await _client.GetAsync("http://localhost:55502/api/Sera/SeraListele");

            var resultString = await result.Content.ReadAsStringAsync();

            var resultDeger = JsonConvert.DeserializeObject<List<Sera>>(resultString);


            return View(resultDeger);
        }

        

        public ActionResult SeraEkle()
        {




            return View();
        }
        [HttpPost]
        public async Task<ActionResult> SeraEkle(Sera data)
        {



            _client.BaseAddress = new Uri("http://localhost:55502/api/Sera/SeraEkle");

            StringContent content = new StringContent(JsonConvert.SerializeObject(data), System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = _client.PostAsync("http://localhost:55502/api/Sera/SeraEkle", content).Result;


            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("SeraListe", "Admin");
            }


            return RedirectToAction("SeraEkle", "Admin");






        }

        //Kullanıcıyı Sera ile eşleme işlemek için veriler çekiliyor.
        public async Task<ActionResult> SeraVer(int id)
        {

            var result = await _client.GetAsync("http://localhost:55502/api/Kullanici/KullaniciListe");

            var resultString = await result.Content.ReadAsStringAsync();

            var resultDeger = JsonConvert.DeserializeObject<List<Kullanici>>(resultString);

            var data=resultDeger.FirstOrDefault(x => x.KullaniciId == id);

            ViewBag.kullaniciIsim = data.Isim;

            ViewBag.KullaniciSoyIsim = data.SoyIsim;

            ViewBag.KullaniciId = data.KullaniciId;

            var resultSera = await _client.GetAsync("http://localhost:55502/api/Sera/SeraListele");

            var resultStringSera = await resultSera.Content.ReadAsStringAsync();

            var resultDegerSera = JsonConvert.DeserializeObject<List<Sera>>(resultStringSera);

            ViewBag.Sera = resultDegerSera.ToList();



            return View();
        }

        //Kullanıcı Tablosundaki SeraId ve Sera Konum U güncellemek için 
        [HttpPost]
        public async Task<ActionResult> SeraKullaniciEsle(int KullaniciId, int Seraid)
        {

            Kullanici data=new Kullanici()
            {

                KullaniciId = KullaniciId,
                SeraId = Seraid,


            };

            _client.BaseAddress = new Uri("http://localhost:55502/api/Kullanici/KullaniciSeraEsle");

            StringContent content = new StringContent(JsonConvert.SerializeObject(data), System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = _client.PostAsync("http://localhost:55502/api/Kullanici/KullaniciSeraEsle", content).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Admin");

            }
            return RedirectToAction("Index", "Admin");
        }



        public ActionResult RolEkle()
        {




            return View();
        }

        [HttpPost]
        public async Task<ActionResult> RolEkle(Roller data)
        {



            _client.BaseAddress = new Uri("http://localhost:55502/api/Kullanici/RolEkle");

            StringContent content = new StringContent(JsonConvert.SerializeObject(data), System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = _client.PostAsync("http://localhost:55502/api/Kullanici/RolEkle", content).Result;


            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("RolEkle", "Admin");
            }


            return RedirectToAction("Index", "Admin");






        }
        public async Task<ActionResult> RolVer(int id)
        {

            var result = await _client.GetAsync("http://localhost:55502/api/Kullanici/KullaniciListe");

            var resultString = await result.Content.ReadAsStringAsync();

            var resultDeger = JsonConvert.DeserializeObject<List<Kullanici>>(resultString);

            var data = resultDeger.FirstOrDefault(x => x.KullaniciId == id);

            ViewBag.kullaniciIsim = data.Isim;

            ViewBag.KullaniciSoyIsim = data.SoyIsim;

            ViewBag.KullaniciId = data.KullaniciId;

            var resultSera = await _client.GetAsync("http://localhost:55502/api/Kullanici/RolListele");

            var resultStringSera = await resultSera.Content.ReadAsStringAsync();

            var resultDegerSera = JsonConvert.DeserializeObject<List<Roller>>(resultStringSera);

            ViewBag.Sera = resultDegerSera.ToList();



            return View();
        }

        [HttpPost]
        public async Task<ActionResult> RolKullaniciEsle(int KullaniciId, int Rol1)
        {

            KullaniciRol data = new KullaniciRol()
            {

                KullaniciId = KullaniciId,
                RolId = Rol1,


            };

            _client.BaseAddress = new Uri("http://localhost:55502/api/Kullanici/KullaniciRolEsle");

            StringContent content = new StringContent(JsonConvert.SerializeObject(data), System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = _client.PostAsync("http://localhost:55502/api/Kullanici/KullaniciRolEsle", content).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Admin");

            }
            return RedirectToAction("Index", "Admin");
        }






    }
}