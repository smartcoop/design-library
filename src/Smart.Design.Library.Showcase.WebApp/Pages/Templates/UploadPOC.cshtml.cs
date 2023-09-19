using System.Net.Http.Headers;
using System.Net.Mail;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Smart.Design.Library.Showcase.Pages.Templates
{
    public class UploadPOCModel : PageModel
    {
        public void OnGet()
        {

        }

        public void OnPost()
        {
            var files  = Request.Form.Files;
            foreach (var file in files)
            {
                var fileName = file.FileName;
            }
        }
    }
}
