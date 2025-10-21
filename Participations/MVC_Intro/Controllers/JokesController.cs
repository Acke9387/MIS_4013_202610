using Microsoft.AspNetCore.Mvc;
using MVC_Intro.Models;
using Newtonsoft.Json;

namespace MVC_Intro.Controllers
{
    public class JokesController : Controller
    {
        public IActionResult Index()
        {
            string url = "https://api.chucknorris.io/jokes/random";

            //get joke from api url using httpclient

            var client = new HttpClient();
            string json = client.GetStringAsync(url).Result;
            ChuckNorrisApi joke;
            //if (response.IsSuccessStatusCode)
            //{
            //    var json = response.Content.ReadAsStringAsync().Result;

            //    joke = JsonConvert.DeserializeObject<ChuckNorrisApi>(json);
            //}
            //else
            //{
            //    ViewBag.Joke = "Error retrieving joke.";
            //}
         
            joke = JsonConvert.DeserializeObject<ChuckNorrisApi>(json);

            return View(joke);
        }
    }
}
