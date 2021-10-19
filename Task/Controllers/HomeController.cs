using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Task.Models;

namespace Task.Controllers
{
    public class HomeController : Controller
    {
        public List<object> postData = new List<object>();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult IndexAsync()
        {
            return View();
        }

        [HttpPost]
        public string Index(string[] keywords, string target, string[] search_engine_choice, string search_engine, string[] region, string region_choice, string[] location_name_choice, string location_name)
        {
            foreach (string choice in search_engine_choice)
            {
                search_engine += choice;
            }

            foreach (string choice in location_name_choice)
            {
                location_name += choice;
            }

            postData.Add(new
            {
                location_name,
                keywords,
                target
            });

            Console.WriteLine(postData);

            string data = "Location Name : = " + location_name + " " + "Keywords : = " + keywords[0] + " " + "Website : = " + target;

            Keywords_data_task_post().GetAwaiter();
            return data;
        }

        public async System.Threading.Tasks.Task<Location> Keywords_data_task_post(string path = "https://sandbox.dataforseo.com/v3/serp/google/organic/task_post", string authentication = "challenger29@rankactive.info:62X8Fj5EC")
        {
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri(path),

                DefaultRequestHeaders = { Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes(authentication))) }
            };

            var taskPostResponse = await httpClient.PostAsync("/v3/keywords_data/google/search_volume/task_post", new StringContent(JsonConvert.SerializeObject(postData)));
            var result = JsonConvert.DeserializeObject<dynamic>(await taskPostResponse.Content.ReadAsStringAsync());

            if (result.status_code == 20000)
            {
                Console.WriteLine(result);
            }
            else
                Console.WriteLine($"error. Code: {result.status_code} Message: {result.status_message}");
            return result;
        }
    public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
