using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using Task.Models;
using System.Collections.Generic;

namespace Task
{
    public class Program
    {
        internal string authentication = "challenger29@rankactive.info:62X8Fj5EC";

        public static void Main(string[] args)
        {
            Program program = new Program();

            program.GetLocationGoogleTrendsAsync().GetAwaiter();

            program.GetLocationGoogleAdWordsAsync().GetAwaiter();

            program.GetLocationBingAdsAsync().GetAwaiter();

            CreateHostBuilder(args).Build().Run();
        }

        public async System.Threading.Tasks.Task GetLocationGoogleTrendsAsync(string path = "https://api.dataforseo.com/v3/keywords_data/google_trends/locations")
        {

            Console.WriteLine("Start GetLocation GoogleTrends");

            var httpClient = new HttpClient
            {
                BaseAddress = new Uri(path),

                DefaultRequestHeaders = { Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes(authentication))) }
            };

            var response = await httpClient.GetAsync("/v3/keywords_data/google_trends/locations");

            var response_to_string = await response.Content.ReadAsStringAsync();

            TasksLocationGoogle tasksLocationGoogle =
                JsonConvert.DeserializeObject <TasksLocationGoogle> (response_to_string); ;

            Console.WriteLine(tasksLocationGoogle);
        }
        public async System.Threading.Tasks.Task GetLocationGoogleAdWordsAsync(string path = "https://api.dataforseo.com/v3/keywords_data/google/locations")
        {

            Console.WriteLine("Start GetLocation GoogleAdWords");

            var httpClient = new HttpClient
            {
                BaseAddress = new Uri(path),

                DefaultRequestHeaders = { Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes(authentication))) }
            };

            var response = await httpClient.GetAsync("/v3/keywords_data/google_trends/locations");

            var response_to_string = await response.Content.ReadAsStringAsync();

            TasksLocationGoogle tasksLocationGoogle =
                JsonConvert.DeserializeObject<TasksLocationGoogle>(response_to_string); ;

            Console.WriteLine(tasksLocationGoogle);
        }

        public async System.Threading.Tasks.Task GetLocationBingAdsAsync(string path = "https://api.dataforseo.com/v3/keywords_data/bing/locations")
        {

            Console.WriteLine("Start GetLocation BingAds");

            var httpClient = new HttpClient
            {
                BaseAddress = new Uri(path),

                DefaultRequestHeaders = { Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes(authentication))) }
            };

            var response = await httpClient.GetAsync("/v3/keywords_data/google_trends/locations");

            var response_to_string = await response.Content.ReadAsStringAsync();

            TasksLocationGoogle tasksLocationGoogle =
                JsonConvert.DeserializeObject<TasksLocationGoogle>(response_to_string); ;

            Console.WriteLine(tasksLocationGoogle);
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
