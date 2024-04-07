using CarPark.User.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;
using MongoDB.Driver;
using MongoDB.Bson;

namespace CarPark.User.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            const string connectionUri = "mongodb+srv://tariktuzel11:BXfgtgOki1GHWzoF@carparkcluster.cw7rgyw.mongodb.net/?retryWrites=true&w=majority&appName=CarParkCluster";
            var settings = MongoClientSettings.FromConnectionString(connectionUri);
            
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            
            var client = new MongoClient(settings);

            var database = client.GetDatabase("CarParkDB");

            var collection = database.GetCollection<Test>("Test");


            var test = new Test()
            {
                _Id = ObjectId.GenerateNewId(),
                NameSurname = "Tarýk Tüzel",
                Age = 24,
                AddressList = new List<Address>()
                {
                    new Address()
                    {
                        Title="Ýþ Adresim",
                        Description="Ataþehir/Ýstanbul"
                    },
                    new Address()
                    {
                        Title="Ev Adresim",
                        Description="Avcýlar/Ýstanbul"
                    }
                }
            };
          collection.InsertOne(test);

            return View();
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
