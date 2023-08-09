using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Smart.Design.Library.TagHelpers.Elements.Input;

namespace Smart.Design.Library.Extensions;

public class PhoneNumberValidation : ValidationAttribute
{
    private readonly PhoneType _phoneType;
    private const string MobilePhoneRegex = @"^(?:(?:\+32|0)(?:\d ?){1,2}(?:[1-9][0-9]|4[89])) ?\d{2}(?: ?\d{2}){1,2}$";
    private const string LandlinePhoneRegex = @"^(?:(?:\+32|0)(?:\d ?){1,2}(?:[1-9][0-9]|4[89])) ?\d{2}(?: ?\d{2}){1,2}$";

    public PhoneNumberValidation(PhoneType phoneType)
    {
        _phoneType = phoneType;
    }

    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        if (_phoneType == PhoneType.Mobile)
        {
            if (value is string stringValue && !Regex.IsMatch(stringValue, MobilePhoneRegex))
            {
                return new ValidationResult("Mobile phone is not valid");
            }
        }
        else
        {
            if (value is string stringValue && !Regex.IsMatch(stringValue, LandlinePhoneRegex))
            {
                return new ValidationResult("Landline phone is not valid");
            }
            else if (value is not null && String.IsNullOrWhiteSpace(value.ToString()))
            {
                return ValidationResult.Success;
            }
        }
        return ValidationResult.Success;
    }
}
