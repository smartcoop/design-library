using Smart.Design.Razor.TagHelpers.Elements;
using Smart.Design.Razor.TagHelpers.Html.Options;

namespace Smart.Design.Razor.TagHelpers.Extensions
{
    public static class SmartButtonTagHelperExtensions
    {
        public static SmartButtonOptions ToOptions(this SmartButtonTagHelper tagHelper)
        {
            return new SmartButtonOptions()
            {
                Disabled     = tagHelper.Disabled,
                IconOnly     = tagHelper.IconOnly,
                IsBlock      = tagHelper.IsBlock,
                Label        = tagHelper.Label,
                LeadingIcon  = tagHelper.LeadingIcon,
                TrailingIcon = tagHelper.TrailingIcon,
                Style        = tagHelper.Style,
                Type         = tagHelper.Type,
                Loading      = tagHelper.Loading
            };
        }
    }
}
