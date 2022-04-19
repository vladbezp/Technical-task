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
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
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

            return View(test);
        }

        public IActionResult QA(int id)
        {
            IEnumerable<QA> qa = _context.QA.ToList()
                .Where(i => i.parentId == id);

            return View(qa);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}