using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Telerik.SvgIcons;

namespace Smart.Design.Library.Showcase.Pages.Templates.Dialog
{
    public class DialogTestModel : PageModel
    {
        public void OnGet()
        {
            
        }

        public void OnPost()
        {
            var action = Request.Form["action"];
            string message;
            switch (action)
            {
                case "validate":
                     message = "Add here the code when the user click on ok button";
                    break;
                case "cancel":
                     message = "Add here the code when the user click on cancel button";
                    break;
            }
           
        }
    }
}
