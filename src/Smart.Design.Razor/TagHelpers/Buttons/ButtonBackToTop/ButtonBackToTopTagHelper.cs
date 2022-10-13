using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Razor.TagHelpers.Constants;

namespace Smart.Design.Razor.TagHelpers.Buttons.ButtonBackToTop;

[HtmlTargetElement(TagNames.ButtonBackToTopTagName)]
public class ButtonBackToTopTagHelper : TagHelper
{
    private readonly IButtonBackToTopHtmlGenerator _buttonBackToTopHtmlGenerator;

    /// <summary>
    /// Label on the button.
    /// </summary>
    public string Label { get; set; }

    /// <summary>
    /// Creates a new <see cref="ButtonBackToTopHtmlGenerator"/>.
    /// </summary>
    /// <param name="buttonBackToTopHtmlGenerator">The service that generates Smart Design back to top button HTML.</param>
    public ButtonBackToTopTagHelper(IButtonBackToTopHtmlGenerator buttonBackToTopHtmlGenerator)
    {
        _buttonBackToTopHtmlGenerator = buttonBackToTopHtmlGenerator;
    }

    /// <inheritdoc />
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        var backToTop = new TagBuilder("div");
        backToTop.AddCssClass("back-to-top");

        backToTop.InnerHtml.SetHtmlContent(_buttonBackToTopHtmlGenerator.GenerateButtonBackToTop(Label));

        output.MergeAttributes(backToTop);
        output.TagName = backToTop.TagName;
        output.TagMode = TagMode.StartTagAndEndTag;
        output.Content.SetHtmlContent(backToTop.InnerHtml);
    }
}
