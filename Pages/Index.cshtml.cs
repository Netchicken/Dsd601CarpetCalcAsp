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

        public List<string> CarpetResults { get; set; }



        public List<SelectListItem> carpetTypesList { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "100", Text = "Cheap" },
            new SelectListItem { Value = "200", Text = "Home" },
            new SelectListItem { Value = "300", Text = "Luxurious"  },
        };


        public CarpetOperations carpetOperations = new CarpetOperations();


        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;

            CarpetResults = new List<string>();
        }


        public void OnGet()
        {
            // carpet.Results.Add("Results");

            CarpetResults.Add("Results here");

        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                carpet.InstallationCost = 20;
                carpet.UnderlayCost = 20;
                carpet.RoomArea = Convert.ToSingle(carpet.RoomWidth) * Convert.ToSingle(carpet.RoomLength);
                carpet.FinalCost = carpetOperations.TotalInstallCost(carpet);
                CarpetResults.Add("Room area " + carpet.RoomArea + "sqm $" + carpet.FinalCost);
            }
            return Page();
        }

    }
}