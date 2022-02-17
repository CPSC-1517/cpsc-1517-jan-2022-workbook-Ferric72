using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.Samples
{
    public class BasicDataManagementModel : PageModel
    {
        //create bound properties that are directly tied to a control on the form
        //bound properties have the data automatically transferred from the control
        //      into the property
        [BindProperty]
        public int Num { get; set; } //this is tied to the control using the asp-for
        [BindProperty]
        public string FavouriteCourse { get; set; }
        [BindProperty]
        public string Comments { get; set; }

        [TempData]
        public string Feedback { get; set; }
        public void OnGet()
        {
            //executes for a Get request
            //the first time the page is requested an automatic Get request is sent
            //excellent "event" to use to do any initialization to your web page display
            //      as the page is shown for the first time
        }

        public void OnPost()
        {
            //processes the OnPost request of the form (method="post")
            //the returndatatype can be void or IActionResult
            //OnPost request is the request from a <button> that has NOT indicated a
            //      specific process Post using the asp-page-handler
            //logic that you wish to accomplish should be isolated to the actions
            //  desired for the button
            Feedback = $"Number {Num}, Course {FavouriteCourse}, Comments {Comments}";
        }
    }
}
