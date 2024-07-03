using GameZone.Models;
using GameZone.Models.ViewModels;

namespace GameZone.Services
{
    public interface IGamesServices
    {
        IEnumerable<Game> GetAll();

        Game? GetById(int id);

        Task Create(CreateGameFormViewModel game);

        Task<Game?> Update(EditGameFormViewModel game);

        bool Delete(int id);

    }
}
