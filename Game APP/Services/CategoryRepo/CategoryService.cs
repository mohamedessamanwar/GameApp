using Game_APP.Services.GenericRepo;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Movies_APP.Services.CategoryRepo
{
    public class CategoryService : GenericRepo<Category>, ICategoryService
    {
        private readonly Game_APP.Models.Data.AppContext _context;
        public CategoryService(Game_APP.Models.Data.AppContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<SelectListItem> GetCategoryItems()
        {
            return _context.Categories.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToList();
        }
    }
}
