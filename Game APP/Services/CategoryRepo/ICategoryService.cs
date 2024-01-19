using Game_APP.Services.GenericRepo;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Movies_APP.Services.CategoryRepo
{
    public interface ICategoryService : IGenericRepo<Category>  
    {
        public IEnumerable<SelectListItem> GetCategoryItems();
    }
}
