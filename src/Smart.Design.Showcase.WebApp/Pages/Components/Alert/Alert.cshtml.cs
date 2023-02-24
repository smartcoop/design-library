using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Smart.Design.Razor.Showcase.Pages.Components.Alert
{
    public class AlertModel : PageModel
    {
        private readonly ILogger<AlertModel> _logger;

        public AlertModel(ILogger<AlertModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}
