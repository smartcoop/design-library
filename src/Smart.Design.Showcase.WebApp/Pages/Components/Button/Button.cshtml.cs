using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Smart.Design.Razor.Showcase.Pages.Components.Button
{
    public class ButtonModel : PageModel
    {
        private readonly ILogger<ButtonModel> _logger;

        public ButtonModel(ILogger<ButtonModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}
