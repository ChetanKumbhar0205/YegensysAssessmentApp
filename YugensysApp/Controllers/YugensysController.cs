using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace YugensysApp.Controllers
{
    public class ResponseClass
    {
        public int status { get; set; }
        public object Data { get; set; }
    }
    public class YugensysController : Controller
    {
        // GET: Yugensys
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Yugesys()
        {
            return View();
        }
        [HttpPost]
        public async System.Threading.Tasks.Task<JsonResult> GetFruit(string color)
        {
            ResponseClass resData = new ResponseClass();
            using (var client = new HttpClient())
            {
                string MethodName = "GetFruit?";
                string Params = "color=" + color;
                client.BaseAddress = new Uri("http://localhost:55519/api/Yugesys/");
                
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpContent content = new FormUrlEncodedContent(new List<KeyValuePair<string, string>>());
                HttpResponseMessage Res = await client.PostAsync(MethodName + Params, content);
                if (Res.IsSuccessStatusCode)
                {
                    string jSonString = Res.Content.ReadAsStringAsync().Result;
                    var result = JObject.Parse(jSonString);
                    resData.status = (int)result["status"];
                    resData.Data = result["data"].ToString();
                }
            }
            return Json(resData);
        }
        [HttpPost]
        public async System.Threading.Tasks.Task<JsonResult> AddFruit(string color, string fruit)
        {
            ResponseClass resData = new ResponseClass();
            using (var client = new HttpClient())
            {
                string MethodName = "AddPair?";
                string Params = "color=" + color
                            + "&fruit=" + fruit;
                client.BaseAddress = new Uri("http://localhost:55519/api/Yugesys/");

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpContent content = new FormUrlEncodedContent(new List<KeyValuePair<string, string>>());
                HttpResponseMessage Res = await client.PostAsync(MethodName + Params, content);
                if (Res.IsSuccessStatusCode)
                {
                    string jSonString = Res.Content.ReadAsStringAsync().Result;
                    var result = JObject.Parse(jSonString);
                    resData.status = (int)result["status"];
                }
            }
            return Json(resData);
        }
    }
}