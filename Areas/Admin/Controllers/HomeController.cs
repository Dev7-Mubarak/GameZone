using GameZone.Models;
using GameZone.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameZone.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = Rols.rolAdmin + "," + Rols.rolOwner)]
    public class HomeController : Controller
    {
        private IGamesServices _gamesServices;

        public HomeController(IGamesServices gamesServices)
        {
            _gamesServices = gamesServices;
        }

        public IActionResult Index()
        {
            return View(_gamesServices.GetAll());
        }
    }
}
