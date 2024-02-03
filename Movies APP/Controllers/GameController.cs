using Game_APP.Services.Game_Repo;
using Game_APP.Viewsmodel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Game_APP.Fillters;
using Movies_APP.Services.CategoryRepo;


namespace Game_APP.Controllers
{
    public class GameController : Controller
    {
        private readonly Models.Data.AppContext _context;
        private readonly ICategoryService _categoryService;
        private readonly IGameService     _gameService;




        public GameController(ICategoryService categoryService, IGameService gameService,Models.Data.AppContext context)
        {
            _context = context;
            _categoryService = categoryService;
            _gameService = gameService;
        }

      

        [HttpGet]
        //[ServiceFilter(typeof(Filter1))]
        public IActionResult Create()
        {

            // var Categories = _context.Categories.ToList();

            CreateGameFormViewModel model = new()
            {
                Categories = _categoryService.GetCategoryItems(),  //_context.Categories.Select(c => new SelectListItem {Value = c.Id.ToString() , Text = c.Name } ).ToList(),
                Devices = _context.Devices.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToList(),
            };
            return View("Create", model);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm]CreateGameFormViewModel model )//,[FromRoute] string name)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }


           
            await _gameService.CreateAsync(model);


            return RedirectToAction(nameof(Index));


        }

       
        public JsonResult Cheack (IFormFile Cover)
        {

            var extension = Path.GetExtension(Cover.FileName);
            var isAllowed = Filestings.AllowedExtensions.Split(',').Contains(extension, StringComparer.OrdinalIgnoreCase);

            if (!isAllowed)
            {
                return Json(false); 
            }
            return Json(true); 

        }


        public ActionResult index()
        {
           var games = _gameService.GetGames();

            return View(games);
        }
            

        






    }
}