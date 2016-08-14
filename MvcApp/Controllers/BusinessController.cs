using MvcApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Mvc;

namespace MvcApp.Controllers
{
    public class BusinessController : Controller
    {
        public ActionResult Index()
        {
            using (var client = new HttpClient())
            {
                //client.BaseAddress = new Uri("http://localhost:36216/");
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["ServiceConnection"].ToString());
                //client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync("api/businessapi").Result;

                if (response.IsSuccessStatusCode)
                {
                    var res = response.Content.ReadAsAsync<IEnumerable<Business>>().Result;
                }

                return View();
            }
        }

        // GET api/<controller>
        public List<Business> Get()
        {
            List<Business> ret = new List<Business>();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:36216/");
                    //client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = client.GetAsync("api/business").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        ret = response.Content.ReadAsAsync<List<Business>>().Result;
                        
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ret;
        }

        // GET api/<controller>/5
        public Business Get(int id)
        {
            Business ret = new Business();

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:36216/");
                    //client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = client.GetAsync("api/business/" + id).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        ret = response.Content.ReadAsAsync<Business>().Result;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ret;
        }

        // POST api/<controller>
        public int Post([FromBody]Business obj)
        {
            int ret = 0;

            if (ModelState.IsValid)
            {
                string createdBy = "dmauk";

                try
                {
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("http://localhost:36216/");
                        //client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                        HttpResponseMessage response = client.GetAsync("api/business/").Result;

                        if (response.IsSuccessStatusCode)
                        {
                            ret = response.Content.ReadAsAsync<Int32>().Result;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return ret;
        }
    }
}
