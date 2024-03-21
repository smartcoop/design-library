using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Smart.Design.Library.Showcase.Pages.Templates;

public class DNA : PageModel
{
    [HttpPost]
    public IActionResult OnPost (string vehiculeName, string licencePlate, string motorType, string  DateTime, DateTime licencePlateDate, bool typeVehicule, bool approval1)
    {
        // Process field values here


        // Redirext to confirmation page
        return RedirectToPage("/Templates/Confirmation");        
    }
    
}