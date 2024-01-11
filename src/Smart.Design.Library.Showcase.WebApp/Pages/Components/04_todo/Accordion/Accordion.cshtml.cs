using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Smart.Design.Library.Showcase.Pages.Components.Accordion
{
    public class AccordionModel : PageModel
    {
        private readonly ILogger<AccordionModel> _logger;

        public AccordionModel(ILogger<AccordionModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}
