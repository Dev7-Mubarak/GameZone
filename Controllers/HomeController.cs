using GameZone.Data;
using GameZone.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace GameZone.Controllers
{
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
            return View();
        }

        public IActionResult Rests()
        {
            var rest = _context.Rests
                .ToList();

            return View(rest);
        }

        public async Task<IActionResult> Details(int? id)
        {
             if (id == null || _context.Rests == null)
            {
                return NotFound();
            }

            var rest = await _context.Rests.Include(x => x.Rooms)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (rest == null)
            {
                return NotFound();
            }

            return View(rest);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}