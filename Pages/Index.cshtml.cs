using Dsd601CarpetCalcAsp.Model;
using Dsd601CarpetCalcAsp.Operations;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Dsd601CarpetCalcAsp.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public Carpet? carpet { get; set; }


        public List<SelectListItem> carpetTypesList { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "1", Text = "Cheap" },
            new SelectListItem { Value = "2", Text = "Home" },
            new SelectListItem { Value = "3", Text = "Luxurious"  },
        };


        public CarpetOperations carpetOperations { get; set; }


        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }


        //https://localhost:7116/?carpet.RoomWidth=3&carpet.RoomLength=3&carpet.CarpetType=1&carpet.InstallationCost=false&carpet.UnderlayCost=false
        //public PageResult OnGet(string width, string length, string type, bool install, bool underlay)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        carpet.RoomWidth = Convert.ToSingle(width);
        //        carpet.RoomLength = Convert.ToSingle(length);
        //        carpet.RoomArea = Convert.ToSingle(width) * Convert.ToSingle(length);

        //    }
        //    return Page();
        //}
        public async Task<IActionResult> OnPostAsync()
        {

            if (ModelState.IsValid)
            {
                //carpet.RoomWidth = Convert.ToSingle(width);
                //carpet.RoomLength = Convert.ToSingle(length);
                carpet.RoomArea = Convert.ToSingle(carpet.RoomWidth) * Convert.ToSingle(carpet.RoomLength);

            }

            return Page();
        }

    }
}