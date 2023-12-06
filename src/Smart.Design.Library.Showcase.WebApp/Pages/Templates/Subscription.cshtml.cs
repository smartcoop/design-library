using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Smart.Design.Library.Extensions;
using Smart.Design.Library.TagHelpers.Elements.Input;


namespace Smart.Design.Library.Showcase.Pages.Templates;


public class Subscription
{
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string Gender { get; set; }
    public string Language { get; set; }
    public string Email { get; set; }
    [PhoneNumberValidation(PhoneType.Landline)]
    public string? LandLine { get; set; }
    [PhoneNumberValidation(PhoneType.Mobile)]
    public string Mobile { get; set; }
    public DateTime BirthDate{ get; set; }
    public string BirthTown{ get; set; }
    public string CivilStatus{ get; set; }
    public string Nationality{ get; set; }
    public Address? OfficialAddress{ get; set; }
    public Address? ShippingAddress{ get; set; }
    public double Withholding{ get; set; }
    public string RegisterIdNumber{ get; set; }
    public string IdCardNumber{ get; set; }
    public string Iban{ get; set; }
    public Boolean SubscriptionApproval{ get; set; }

}

public class Address
{
    public string? Street { get; set; }
    public string? Number { get; set; }
    public string? BoxStreet { get; set; }
    public string? ZipCode { get; set; }
    public string? City { get; set; }
    public string? Country { get; set; }
}


public class SubscriptionModel : PageModel
{
    [BindProperty]
    public Subscription Subscription { get; set; }

    [BindProperty]
    public bool SameAddress { get; set; }


    public void OnGet()
    {
        SameAddress = true;
    }

    public async Task<ActionResult> OnPostAsync()
    {
        SameAddress = Request.Form.ContainsKey("sameAddress") && bool.Parse(Request.Form["sameAddress"]);

        if (!ModelState.IsValid)
        {
            ModelState.AddModelError(string.Empty, "error");
        }

        return Page();
    }
}
