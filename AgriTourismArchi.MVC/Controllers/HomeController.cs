using AgriTourismArchi.MVC.Models;
using AgriTourismArchi.Repository.Data;
using Microsoft.AspNetCore.Mvc;
using AgriTourismArchi.Aggregator.Models;
using System.Diagnostics;

namespace AgriTourismArchi.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;


        private readonly ApplicationDbContext _db;

        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            // Fetching data from the Categories table
            var categories = _db.Categories.ToList();

            return View(categories); // Passing data to the Index view
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
