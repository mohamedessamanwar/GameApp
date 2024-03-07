

namespace Game_APP.Services.Game_Repo
{
    public class GameService : GenericRepo<Game>, IGameService
    {
        private readonly Game_APP.Models.Data.AppContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly String _imagePath;
        public GameService(Game_APP.Models.Data.AppContext context, IWebHostEnvironment webHostEnvironment) : base(context)
        {
            _context = context;
            this.webHostEnvironment = webHostEnvironment;
            _imagePath = $"{webHostEnvironment.WebRootPath}{Filestings.ImagesPath}";
        }
        public async Task CreateAsync(CreateGameFormViewModel model)
        {

            var coverName = $"{Guid.NewGuid()}{Path.GetExtension(model.Cover.FileName)}";
            var path = Path.Combine(_imagePath, coverName);

            using var stream = File.Create(path);
            await model.Cover.CopyToAsync(stream);
            Game game = new()
            {
                Name = model.Name,
                Description = model.Description,
                CategoryId = model.CategoryId,
                Cover = coverName,
                GameDevice = model.SelectedDevices.Select(d => new GameDevice { DeviceId = d }).ToList()
            };

            _context.Add(game);
            _context.SaveChanges();


        }

        public Game? GetByIdGame(int id)
        {
            return _context.Games.Include(G => G.Category).Include(G => G.GameDevice).ThenInclude(D => D.Device).AsNoTracking().FirstOrDefault(g => g.Id == id);
        }

        public IEnumerable<Game> GetGames()
        {
            return _context.Games.Include(G => G.Category).Include(G => G.GameDevice).ThenInclude(D => D.Device);
        }

        public async Task<Game>? Update_v1(int id, UpdateGameFormViewModel model)
        {
            //cheack if game exist .....
            var game = _context.Games.Include(g => g.GameDevice ).Where(g => g.Id==id).FirstOrDefault();
            if (game == null)
            {
                return game;
            }
            var oldimage = game.Cover;

            game.Name = model.Name;
            game.Description = model.Description;
            game.CategoryId = model.CategoryId;
            // map to table GameDevice ....
            game.GameDevice = model.SelectedDevices.Select(d => new GameDevice { DeviceId = d }).ToList();
            string newcover; 
            if (model.Cover != null)
            {
               newcover = await SaveCover(model.Cover);
               game.Cover = newcover;



            }
            _context.Games.Update(game);
            var effectedRows = _context.SaveChanges();
            if (effectedRows > 0)
            {
                var coverr = Path.Combine(_imagePath, oldimage);
                File.Delete(coverr);
                return game;
            }
            else
            {
                var cover = Path.Combine(_imagePath,game.Cover);
                File.Delete(cover);
                return null;
            }

        }
        public async Task<string> SaveCover (IFormFile cover)
        {
            var coverName = $"{Guid.NewGuid()}{Path.GetExtension(cover.FileName)}";
            var path = Path.Combine(_imagePath, coverName);

            using var stream = File.Create(path);
            await cover.CopyToAsync(stream);

            return coverName;

        }
        public bool Delete2(int id)
        {
            var isDeleted = false;

            var game = _context.Games.Find(id);

            if (game is null)
                return isDeleted;

            _context.Remove(game);
            var effectedRows = _context.SaveChanges();

            if (effectedRows > 0)
            {
                isDeleted = true;

                var cover = Path.Combine(_imagePath, game.Cover);
                File.Delete(cover);
            }

            return isDeleted;
        }







    }
}
