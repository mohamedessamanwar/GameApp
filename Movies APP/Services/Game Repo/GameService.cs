

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

        public IEnumerable<Game> GetGames()
        {
            return _context.Games.Include(G=> G.Category).Include(G=> G.GameDevice).ThenInclude(D=>D.Device);
        }
    }
}
