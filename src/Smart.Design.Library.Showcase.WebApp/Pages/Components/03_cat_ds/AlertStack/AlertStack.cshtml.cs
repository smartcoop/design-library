using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Smart.Design.Library.Showcase.Pages.Components.AlertStack
{
    public class AlertStackModel : PageModel
    {
        private readonly ILogger<AlertStackModel> _logger;

        public AlertStackModel(ILogger<AlertStackModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}
