using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Game_APP.Viewsmodel
{
    public class CreateGameFormViewModel
    {

        public string Name { get; set; } = string.Empty;


        public string Description { get; set; } = string.Empty;

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; } = Enumerable.Empty<SelectListItem>();
        [Display(Name = "Devieces")]
        [Required]
        public List<int> SelectedDevices { get; set; } = new List<int>();


        public IEnumerable<SelectListItem> Devices { get; set; } = Enumerable.Empty<SelectListItem>();


        public IFormFile Cover { get; set; } = default;


    }
}
