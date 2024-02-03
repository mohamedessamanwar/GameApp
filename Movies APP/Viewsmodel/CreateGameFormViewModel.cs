using Game_APP.Controllers;
using Game_APP.Setting;
using Microsoft.AspNetCore.Mvc;

namespace Game_APP.Viewsmodel
{
    public class CreateGameFormViewModel
    {

        public string Name { get; set; } //= string.Empty;


        public string Description { get; set; } = string.Empty;

        [Display(Name = "Category")]
        public int? CategoryId { get; set; } = 1;

        public IEnumerable<SelectListItem> Categories { get; set; } = Enumerable.Empty<SelectListItem>();
        [Display(Name = "Devieces")]
        [Required]
        public List<int> SelectedDevices { get; set; } = default!;


        public IEnumerable<SelectListItem> Devices { get; set; } = Enumerable.Empty<SelectListItem>();

        [AllowedExtensionsAttribute(Filestings.AllowedExtensions)]
        [MaxFileSize(Filestings.MaxFileSizeInBytes)]
       // [Remote(action: "Cheack", controller: "Game", ErrorMessage = $"Only {Filestings.AllowedExtensions} are allowed!")]
        public IFormFile Cover { get; set; } = default!;



    }
}
