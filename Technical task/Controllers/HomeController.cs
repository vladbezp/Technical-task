using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Technical_task.Data;
using Technical_task.Models;

namespace Technical_task.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            string userRole = User.IsInRole("frontend") ? "frontend" : "backend";
            IEnumerable<Test> tests = _context.Tests.ToList()
                .Where(t => t.Type == userRole);

            return View(tests);
        }

        public IActionResult Test(int id)
        {
            IEnumerable<Test> test = _context.Tests.ToList()
                .Where(i => i.Id == id);
            Console.WriteLine("asd");
            return View(test);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}