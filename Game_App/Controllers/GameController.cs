using Game_APP.Services.Game_Repo;
using Game_APP.Viewsmodel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Game_APP.Fillters;
using Game_APP.Services.CategoryRepo;



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
        [HttpGet]
        public JsonResult Cheack([FromQuery]IFormFile Cover)
        {

            var extension = Path.GetExtension(Cover.FileName);
            var isAllowed = Filestings.AllowedExtensions.Split(',').Contains(extension, StringComparer.OrdinalIgnoreCase);

            if (!isAllowed)
            {
                return Json(false);
            }
            return Json(true);

        }
        //[HttpGet]
        //public IActionResult Cheack(IFormFile cover)
        //{
        //    if (cover == null)
        //    {
        //        return Json("Please select a file.");
        //    }

        //    // Get the file extension
        //    string fileExtension = Path.GetExtension(cover.FileName).ToLower();

        //    // Define the allowed file extensions
        //    string[] allowedExtensions = { ".jpg", ".jpeg", ".png", ".gif" };

        //    // Check if the file extension is allowed
        //    if (!allowedExtensions.Contains(fileExtension))
        //    {
        //        return Json("Invalid file extension. Only JPG, JPEG, PNG, and GIF files are allowed.");
        //    }

        //    // File is valid, return success message
        //    return Json("File is valid!");
        //}

        [HttpGet]
        public ActionResult index()
        {
           var games = _gameService.GetGames();

            return View(games);
        }

        [HttpGet]
        public ActionResult Edit()
        {
            var games = _gameService.GetGames();

            return View(games);
        }


        [HttpGet]
        public ActionResult Details (int id)
        {

            Game? game = _gameService.GetByIdGame(id);
            if (game==null)
            {
                return NotFound();
                
            }
            return View("Details", game);



        }


        [HttpGet]
        public ActionResult Update(int id)
        {
            Game? game = _gameService.GetByIdGame(id);
            if (game == null)
            {
                return NotFound();

            }
            UpdateGameFormViewModel viewModel = new()
            {
                Id = id,
                Name = game.Name,
                Description = game.Description,
                CategoryId = game.CategoryId,
                SelectedDevices = game.GameDevice.Select(d => d.DeviceId).ToList(),
                Categories = _categoryService.GetCategoryItems(),  //_context.Categories.Select(c => new SelectListItem {Value = c.Id.ToString() , Text = c.Name } ).ToList(),
                Devices = _context.Devices.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToList(),
                CurrentCover = game.Cover
            };
            return View(viewModel);

        }
        [HttpPost]
        public async Task<ActionResult> UpdateAsync(int id , UpdateGameFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var game = await _gameService.Update_v1(id,model);

            if (game is null)
                return BadRequest();


            return RedirectToAction(nameof(Index));

        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var isDeleted = _gameService.Delete2(id);

            if (isDeleted)
            {
                // Optionally, you can return a JSON response instead of a redirect
                return Json(new { success = true, message = "Game deleted successfully." });
                // Or, you can redirect to another action
                // return RedirectToAction(nameof(Index));
                //return RedirectToAction(nameof(Index));
            }
            else
            {
                // Optionally, you can return a JSON response instead of BadRequest
                return BadRequest(new { error = "Failed to delete the game." });
            }
        }







    }
}