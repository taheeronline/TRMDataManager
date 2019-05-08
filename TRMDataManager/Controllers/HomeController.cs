using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace TRMDataManager.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string[] myString = null;
            var client = new HttpClient();
            ViewBag.Title = "Home Page";
            client.BaseAddress = new Uri("http://localhost:58604/api/");
            //HTTP GET
            var responseTask = client.GetAsync("values");
            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<string[]>();
                readTask.Wait();

                myString = readTask.Result;
            }
            return View(myString);
        }
    }
}
