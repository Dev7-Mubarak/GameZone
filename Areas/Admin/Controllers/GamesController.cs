using GameZone.Data;
using GameZone.Models.ViewModels;
using GameZone.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameZone.Controllers
{
    // Combin Create and Edit in one View and one View Modele
    [Area("Admin")]
    public class GamesController : Controller
    {
        private readonly ICategoriesService _categoriesService;
        private readonly IDevicesService _devicesService;
        private readonly IGamesServices _gameService;

        public GamesController(ICategoriesService categoriesService, IDevicesService devicesService, IGamesServices gameService)
        {
            _categoriesService = categoriesService;
            _devicesService = devicesService;
            _gameService = gameService;
        }

        public IActionResult Index()
        {
            return View(_gameService.GetAll());
        }

        public IActionResult Details(int id)
        {
            var game = _gameService.GetById(id);

            if (game is null)
                return NotFound();

            return View(game);
        }

        public IActionResult Create()
        {
            CreateGameFormViewModel ViewModel = new()
            {
                Catigories = _categoriesService.GetSelectList(),
                Devices = _devicesService.GetSelectList()
            };
            return View(ViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateGameFormViewModel model)
        {
            if(!ModelState.IsValid)
            {
                model.Catigories = _categoriesService.GetSelectList();
                model.Devices = _devicesService.GetSelectList();

                return View(model);
            }

            await _gameService.Create(model);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var game = _gameService.GetById(id);

            if (game is null)
                return NotFound();

            EditGameFormViewModel viewModel = new()
            {
                Id = id,
                Name = game.Name,
                Descraption = game.Descraption,
                CategoryId = game.CategoryId,
                SelectedDevices = game.GameDevices.Select(d => d.DeviceId).ToList(),
                Catigories = _categoriesService.GetSelectList(),
                Devices = _devicesService.GetSelectList(),
                currentCover = game.Cover,
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditGameFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Catigories = _categoriesService.GetSelectList();
                model.Devices = _devicesService.GetSelectList();

                return View(model);
            }

            var game = await _gameService.Update(model);

            if (game is null)
                return BadRequest();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var isDeleted = _gameService.Delete(id);

            return isDeleted? RedirectToAction(nameof(Index)) : BadRequest();
            //return isDeleted? Ok() : BadRequest();
        }
    }
}
