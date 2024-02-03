using Game_APP.Services.GenericRepo;
using Game_APP.Viewsmodel;

namespace Game_APP.Services.Game_Repo
{
    public interface IGameService : IGenericRepo<Game>
    {
       IEnumerable<Game> GetGames();
        public Task CreateAsync(CreateGameFormViewModel model);
    }
}
