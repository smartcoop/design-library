using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Smart.Design.Library.Showcase.Pages.Templates.Dialog
{
    public class DialogTestModel : PageModel
    {
        public void OnGet()
        {
            
        }

        public void OnPost()
        {
            var message = "Add here the code to remove the car from vehicle assets";
        }
    }
}
