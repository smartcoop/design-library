using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Smart.Design.Library.Showcase.Pages.Templates.Dna;

public class ListVehiculeModel : PageModel
{
    // public IActionResult OnPost(string action)
    // {
    //     if (action == "addVehicule")
    //     {
    //         // Perform any necessary action before redirecting
    //         return RedirectToPage("/Templates/Dna/AddVehicule");
    //     }
    //
    //     // Return to the same page or handle other actions as needed
    //     return Page();
    // }

    public async Task<ActionResult> OnPostAsync()
    {
        return RedirectToPage("/Templates/Dna/AddVehicule");
    }
}
