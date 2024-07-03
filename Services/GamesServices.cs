using GameZone.Data;
using GameZone.Models;
using GameZone.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace GameZone.Services
{
    // Combin Create and Edit in one View and one View Modele
    public class GamesServices : IGamesServices
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string _imagesPath;

        public GamesServices(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _imagesPath = $"{_webHostEnvironment.WebRootPath}{FileSetings.ImagesPath}";
        }

        public IEnumerable<Game> GetAll()
        {
            return _context.Games
                .AsNoTracking()
                .Include(x => x.Category)
                .Include(x => x.GameDevices)
                .ThenInclude(d => d.Device);
        }

        public Game? GetById(int id)
        {
            return _context.Games.FirstOrDefault(g => g.Id == id);
        }

        public async Task Create(CreateGameFormViewModel model)
        {
            var coverName = await SaveCover(model.Cover);

            Game game = new()
            {
                Name = model.Name,
                Descraption = model.Descraption,
                CategoryId = model.CategoryId,
                Cover = coverName,
                GameDevices = model.SelectedDevices.Select(d => new GameDevice { DeviceId = d }).ToList()
            };

            _context.Games.Add(game);

            _context.SaveChanges();
        }

        public async Task<Game?> Update(EditGameFormViewModel model)
        {
            var game = _context.Games.FirstOrDefault(g => g.Id == model.Id);

            if (game is null)
                return null;

            var hasNewCover = model.Cover is not null;

            game.Name = model.Name;
            game.Descraption = model.Descraption;
            game.CategoryId = model.CategoryId;
            game.GameDevices = model.SelectedDevices.Select(x => new GameDevice { DeviceId = x }).ToList();

            var oldCover = game.Cover;

            if (hasNewCover)
            {
                game.Cover = await SaveCover(model.Cover!);
            }

            var effectedRow  = _context.SaveChanges();

            if(effectedRow > 0)
            {
                if (hasNewCover)
                {
                    var cover = Path.Combine(_imagesPath, oldCover);
                    File.Delete(cover);
                }
                return game;

            }
            else
            {
                var cover = Path.Combine(_imagesPath, game.Cover);
                File.Delete(cover);
                return null;
            }

        }

        // Make a starice class and put the methode on it

        private async Task<string> SaveCover(IFormFile cover)
        {
            var coverName = $"{Guid.NewGuid()}{Path.GetExtension(cover.FileName)}";

            var path = Path.Combine(_imagesPath, coverName);

            using var Stream = File.Create(path);

            await cover.CopyToAsync(Stream);

            return coverName;
        }

        public bool Delete(int id)
        {
            var isDeleted = false;

            var game = _context.Games.Find(id);

            if(game is null)
            {
                return isDeleted;
            }

            _context.Games.Remove(game);

            var effectedRows = _context.SaveChanges();

            if(effectedRows > 0)
            {
                isDeleted = true;

                var cover = Path.Combine(_imagesPath, game.Cover);
                File.Delete(cover);
            }

            return isDeleted;
        }
    }
}
