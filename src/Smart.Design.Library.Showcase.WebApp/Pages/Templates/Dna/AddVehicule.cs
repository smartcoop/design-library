using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;

namespace Smart.Design.Library.Showcase.Pages.Templates.Dna;

using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic; // Include this for using List

using System.ComponentModel.DataAnnotations;

public class MustBeTrueAttribute : ValidationAttribute
{
    public override bool IsValid(object value)
    {
        return value is bool && value.Equals(true);
    }
}

public class VehiculeModel
{
    [Required(ErrorMessage = "The vehicle name is required.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "The license plate is required.")]
    public string PlateNumber { get; set; }

    [Required(ErrorMessage = "The date of the first license is required.")]
    public DateTime FirstRegistrationDate { get; set; }

    [Required(ErrorMessage = "The engine type is required.")]
    public string EngineType { get; set; }

    [Required(ErrorMessage = "The consumption is required.")]
    public string Consumption { get; set; }

    [Required(ErrorMessage = "The vehicule type is required.")]
    public string VehiculeType { get; set; }

    [MustBeTrue(ErrorMessage = "The GDPR agreement must be accepted.")]
    public bool Gdpr { get; set; }


}


public class InputGroupItemModel : IInputGroupItem
{
    public string Label { get; set; }
    public bool? Enabled { get; set; }
    public string CssClass { get; set; }
    public bool? Encoded { get; set; }
    public string Value { get; set; }
    public IDictionary<string, object> HtmlAttributes { get; set; }

}

public class AddVehiculePageModel : PageModel
{
    [BindProperty]
    public VehiculeModel Vehicule { get; set; } = new ();

    public void OnGet()
    {
        Vehicule.VehiculeType = "1";
    }

    public async Task<ActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            ModelState.AddModelError(string.Empty, "error");
        }

        return Page();
    }
}
