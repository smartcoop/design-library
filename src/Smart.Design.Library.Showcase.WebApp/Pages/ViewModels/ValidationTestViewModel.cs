using System.ComponentModel.DataAnnotations;

namespace Smart.Design.Library.Showcase.Pages.ViewModels;

public class ValidationTestViewModel
{
    [Required(ErrorMessage = "Do not forget the first name")]
    [StringLength(20, MinimumLength = 5, ErrorMessage ="First name should be between 5 and 20 characters.")]
    public string FirstName { get; set; }

    [Required]
    public string Search { get; set; }
}
