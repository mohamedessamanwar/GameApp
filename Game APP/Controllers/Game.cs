using Game_APP.Viewsmodel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Movies_APP.Services.CategoryRepo;


namespace Game_APP.Controllers
{
    public class Game: Controller
    {
       // private readonly Models.Data.AppContext _context;
       private readonly ICategoryService _categoryService;

        public Game(  ICategoryService categoryService) //Models.Data.AppContext context)
        {
            //_context = context;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {

            // var Categories = _context.Categories.ToList();

            CreateGameFormViewModel model = new()
            {
                Categories =  _categoryService.GetCategoryItems(),  //_context.Categories.Select(c => new SelectListItem {Value = c.Id.ToString() , Text = c.Name } ).ToList(),
               // Devices = //_context.Devices.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToList(),
            };
            return View("Create",model);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateGameFormViewModel model )
        {
            if (!ModelState.IsValid)
            {
                return View(model); 
            }





            return RedirectToAction(nameof(Index));


        }
    }
}
