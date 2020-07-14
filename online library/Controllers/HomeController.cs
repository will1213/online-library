using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using online_library.Models;

namespace online_library.Controllers
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
            return View();
        }

        public IActionResult List()
        {
            return View("List", Database.getAllBooks());
        }

        public IActionResult Book(int ID)
        {
            return View("book",Database.getBookByID(ID));
        }
        public IActionResult Category()
        {
            return View("Category", Database.getAllCategory());
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Like(int ID)
        {
            Database.LikeBook(ID);

            string s = "../Book/" + ID.ToString();
            return Redirect(s);

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Search(string title)
        {
            return View("book", Database.searchByTitle(title));
        }
        public IActionResult SearchCategory(string searchString)
        {
            Console.WriteLine("this is :"+searchString);
            return View("Search", Database.SearchByCategory(searchString));
        }
    }
}
