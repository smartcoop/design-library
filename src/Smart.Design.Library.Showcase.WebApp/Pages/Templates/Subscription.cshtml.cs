using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Smart.Design.Library.Extensions;
using Smart.Design.Library.TagHelpers.Elements.Input;


namespace Smart.Design.Library.Showcase.Pages.Templates;


public class Subscription
{
    public string lastName { get; set; }
    public string firstName { get; set; }
    public string sexe { get; set; }
    public string language { get; set; }
    public string email { get; set; }
    [PhoneNumberValidation(PhoneType.Landline)]
    public string? landLine { get; set; }
    [PhoneNumberValidation(PhoneType.Mobile)]
    public string mobile { get; set; }
    public DateTime birthDate{ get; set; }
    public string birthTown{ get; set; }
    public string civilStatus{ get; set; }
    public string nationality{ get; set; }
    public Address? officialAddress{ get; set; }
    public Address? shippingAddress{ get; set; }
    public int withholding{ get; set; }
    public string registerIdNumber{ get; set; }
    public string idCardNumber{ get; set; }
    public string iban{ get; set; }
    public string subscriptionApproval{ get; set; }

}

public class Address
{
    public string? street { get; set; }
    public string? number { get; set; }
    public string? boxStreet { get; set; }
    public string? zipCode { get; set; }
    public string? city { get; set; }
    public string? country { get; set; }
}


public class SubscriptionModel : PageModel
{
    [BindProperty]
    public Subscription subscription { get; set; }

    public void OnGet()
    {
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
