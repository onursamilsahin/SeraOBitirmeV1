using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using SeraOWeb.Models.DataAccess;

namespace SeraOWeb.Controllers
{   //BU sayfada Api ye gönderilecek kısımlar yazılacaktır. 
    public class DataPostController : Controller
    {
       HttpClient _client = new HttpClient();
        // GET: DataPost

            [HttpPost]
        public ActionResult HavalandirmaDurumuGonder(string Veri)
        {
            CatiKapak _data=new CatiKapak();
            if (Veri=="1")
            {

                _data.Kdurum = true;




            }
            else
            {
                _data.Kdurum = false;
            }


            _client.BaseAddress = new Uri("http://localhost:55502/api/Data/KapakDurumGuncelle");

            StringContent content = new StringContent(JsonConvert.SerializeObject(_data), System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = _client.PostAsync("http://localhost:55502/api/Data/KapakDurumGuncelle", content).Result;


            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("HavaKontrolu", "Home");
            }


            return RedirectToAction("HataSayfasi", "Hata");


        }

        [HttpPost]
        public ActionResult SuPompasiDurumGonder(string Veri)
        {
            SuPompasi _data = new SuPompasi();
            if (Veri == "1")
            {

                _data.SPDurum = true;




            }
            else
            {
                _data.SPDurum = false;
            }


            _client.BaseAddress = new Uri("http://localhost:55502/api/Data/SuPompasiDurumGuncelle");

            StringContent content = new StringContent(JsonConvert.SerializeObject(_data), System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = _client.PostAsync("http://localhost:55502/api/Data/SuPompasiDurumGuncelle", content).Result;


            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("SulamaKontrolu", "Home");
            }


            return RedirectToAction("HataSayfasi", "Hata");


        }

        [HttpPost]
        public ActionResult LedDurumGonder(string Veri)
        {
            LedDurum _data = new LedDurum();
            if (Veri == "1")
            {

                _data.LDurum = true;




            }
            else
            {
                _data.LDurum = false;
            }


            _client.BaseAddress = new Uri("http://localhost:55502/api/Data/LedDurumGuncelle");

            StringContent content = new StringContent(JsonConvert.SerializeObject(_data), System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = _client.PostAsync("http://localhost:55502/api/Data/LedDurumGuncelle", content).Result;


            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("AydinlatmaKontrolu", "Home");
            }


            return RedirectToAction("HataSayfasi", "Hata");


        }








    }
}