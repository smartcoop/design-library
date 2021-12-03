using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Razor.TagHelpers.Constants;

namespace Smart.Design.Razor.TagHelpers.Toolbar;

/// <summary>
/// <see cref="ITagHelper"/> implementation of the Smart design button toolbar.
/// Documentation is available <see href="https://design.smart.coop/development/docs/c-button-toolbar.html">here</see>
/// </summary>
[HtmlTargetElement(TagNames.ButtonToolbarTagName)]
public class ButtonToolbarTagHelper : TagHelper
{
    private readonly IButtonToolbarHtmlGenerator _toolbarHtmlGenerator;
    private const string LayoutAttributeName = "layout";

    [HtmlAttributeName(LayoutAttributeName)]
    public ButtonToolbarLayout Layout { get; set; }

    public bool IsCompact { get; set; }

    public ButtonToolbarTagHelper (IButtonToolbarHtmlGenerator toolbarHtmlGenerator)
    {
        _toolbarHtmlGenerator = toolbarHtmlGenerator;
    }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        var toolbar = _toolbarHtmlGenerator.GenerateSmartButtonToolbar(Layout, IsCompact);

        output.TagName = toolbar.TagName;
        output.TagMode = TagMode.StartTagAndEndTag;

        output.Attributes.Clear();
        output.MergeAttributes(toolbar);
    }
}
