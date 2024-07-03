using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GameZone.Data;
using GameZone.Models;
using GameZone.Areas.Admin.Models;
using GameZone.Services;


namespace GameZone.Areas.Admin.Controllers
{
    // Combin Create and Edit in one View and one View Modele
    [Area("Admin")]
    public class RestsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IDevicesService _devicesService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string _imagesPath;


        public RestsController(ApplicationDbContext context, IDevicesService devicesService, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _devicesService = devicesService;
            _webHostEnvironment = webHostEnvironment;
            _imagesPath = $"{_webHostEnvironment.WebRootPath}{FileSetings.ImagesPath}";
        }

        // GET: Admin/Rests
        public IActionResult Index()
        {
            //var Rests = _context.Rests
            //    .AsNoTracking()
            //    .Select(x => new
            //    {
            //        RestName = x.Name,
            //        Image = x.Image,
            //        Devices  = x.Devices.Select()
            //    })

            var Rests = _context.Rests.AsNoTracking()
                          .Include(x => x.Owner)
                          .Include(x => x.Rooms)
                          .Include(x => x.Devices)
                          .ThenInclude(x => x.Device);

            return View(Rests);
        }

        public IActionResult AddGameToRest(int id)
        {
            var rest = _context.Rests.Find(id);


            return View();
        }


        // GET: Admin/Rests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Rests == null)
            {
                return NotFound();
            }

            var rest = await _context.Rests
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rest == null)
            {
                return NotFound();
            }

            return View(rest);
        }

        // GET: Admin/Rests/Create
        public IActionResult Create()
        {
            CreateRestFormViewModel model = new()
            {
                Devices = _devicesService.GetSelectList(),
            };

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateRestFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Devices = _devicesService.GetSelectList();
                return View(model);
            }

            var ImageName = await SaveCover(model.Image);

            Rest rest = new()
            {
                Name = model.Name,
                Dscraption = model.Descraption,
                Image = ImageName,
                Addrees = model.Address,
                Devices = model.SelectedDevices.Select(d => new RestDivce { DeviceId = d }).ToList()
            };

            _context.Rests.Add(rest);

            _context.SaveChanges();

            return RedirectToAction(nameof(Index));

        }

        // Make a starice class and put the methode on it
        private async Task<string> SaveCover(IFormFile cover) 
        {
            var coverName = $"{Guid.NewGuid()}{Path.GetExtension(cover.FileName)}";

            var path = Path.Combine(_imagesPath, coverName);

            using var Stream = System.IO.File.Create(path);

            await cover.CopyToAsync(Stream);

            return coverName;
        }
        // GET: Admin/Rests/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            Rest rest = await _context.Rests.FirstOrDefaultAsync(x => x.Id == id);

            EditRestFormViewModel model = new()
            {
                Id = id,
                Name = rest.Name,
                Address = rest.Addrees,
                Descraption = rest.Dscraption,
                SelectedDevices = rest.Devices.Select(d => d.DeviceId).ToList(),
                Devices = _devicesService.GetSelectList(),
                currentCover = rest.Image,
            };

            return View(model);
        }

        // POST: Admin/Rests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditRestFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Devices = _devicesService.GetSelectList();

                return View(model);
            }

            var rest = _context.Rests
                .Include(g => g.Devices)
                .FirstOrDefault(g => g.Id == model.Id);

            if (rest is null)
                return NotFound();

            var hasNewCover = model.Image is not null;

            rest.Name = model.Name;
            rest.Addrees = model.Address;
            rest.Dscraption = model.Descraption;
            rest.Devices = model.SelectedDevices.Select(x => new RestDivce { DeviceId = x }).ToList();

            var oldCover = rest.Image;

            if (hasNewCover)
            {
               rest.Image = await SaveCover(model.Image!);
               var cover = Path.Combine(_imagesPath, oldCover);
               System.IO.File.Delete(cover);
            }

            _context.Update(rest);
            _context.SaveChanges();
            
            return RedirectToAction(nameof(Index));

        }

        // GET: Admin/Rests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Rests == null)
            {
                return NotFound();
            }

            var rest = await _context.Rests
                .Include(x => x.Owner)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (rest == null)
            {
                return NotFound();
            }

            return View(rest);
        }

        // POST: Admin/Rests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Rests == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Rests'  is null.");
            }

            var rest = await _context.Rests
                .FirstOrDefaultAsync(x => x.Id == id);

            var cover = Path.Combine(_imagesPath, rest.Image);
            System.IO.File.Delete(cover);

            if (rest != null)
            {
                _context.Rests.Remove(rest);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RestExists(int id)
        {
           return (_context.Rests?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
