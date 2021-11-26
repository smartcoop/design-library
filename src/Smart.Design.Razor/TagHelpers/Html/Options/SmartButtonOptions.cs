using Smart.Design.Razor.Enums;

namespace Smart.Design.Razor.TagHelpers.Html.Options
{
    public class SmartButtonOptions : IHtmlOption
    {
        public bool Disabled { get; set; }

        public Icon LeadingIcon { get; set; }

        public Icon TrailingIcon { get; set; }

        public string Label { get; set; }

        public ButtonType Type { get; set; } = ButtonType.Button;

        public ButtonStyle Style { get; set; } = ButtonStyle.Primary;

        public bool IsBlock { get; set; }

        public bool IconOnly { get; set; }

        public bool IsLoading { get; set; }
    }
}