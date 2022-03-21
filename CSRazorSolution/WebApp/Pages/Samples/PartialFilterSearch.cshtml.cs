using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

#region Additional Namespaces
using WestWindSystem.BLL;  //this is where the services were coded
using WestWindSystem.Entities; //this is where the entity definition is coded
#endregion

namespace WebApp.Pages.Samples
{
    public class PartialFilterSearchModel : PageModel
    {
        #region Private service fields & class constructor
        private readonly ILogger<IndexModel> _logger;
        private readonly TerritoryServices _territoryServices;
        private readonly RegionServices _regionServices;

        public PartialFilterSearchModel(ILogger<IndexModel> logger,
            TerritoryServices territoryservices,
            RegionServices regionservices)
        {
            _logger = logger;
            _territoryServices = territoryservices;
            _regionServices = regionservices;
        }
        #endregion

        [TempData]
        public string Feedback { get; set; }

        [BindProperty(SupportsGet = true)]
        public string searcharg { get; set; }

        public List<Territory> TerritoryInfo { get; set; }

        [BindProperty]
        public List<Region> RegionList { get; set; } = new();

        public void OnGet()
        {
            //obtain the data list for the Region dropdownlist (select tag)
            RegionList = _regionServices.Region_List();
            if (!string.IsNullOrWhiteSpace(searcharg))
            {
                TerritoryInfo = _territoryServices.GetByPartialDescription(searcharg);
            }
        }

        public IActionResult OnPostFetch()
        {
            if (string.IsNullOrWhiteSpace(searcharg))
            {
                Feedback = "Required: Search argument is empty.";
            }            
            return RedirectToPage(new { searcharg = searcharg });
        }

        public IActionResult OnPostClear()
        {
            Feedback = "";
            //searcharg = null;
            ModelState.Clear();
            return RedirectToPage(new { searcharg = (string?)null });
        }
    }
}
