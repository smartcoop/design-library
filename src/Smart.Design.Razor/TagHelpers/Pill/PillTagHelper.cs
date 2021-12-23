using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Razor.TagHelpers.Extensions;

namespace Smart.Design.Razor.TagHelpers.Pill;

[HtmlTargetElement(TagNames.PillTagName)]
public class PillTagHelper : TagHelper
{
    private const string LabelAttributeName = "label";
    private const string StatusAttributeName = "status";
    private const string WithCircleAttributeName = "with-circle";

    private readonly IPillHtmlGenerator _pillHtmlGenerator;

    [HtmlAttributeName(LabelAttributeName)]
    public string? Label { get; set; }

    [HtmlAttributeName(StatusAttributeName)]
    public PillStatus PillStatus { get; set; }

    [HtmlAttributeName(WithCircleAttributeName)]
    public bool WithCircleName { get; set; }

    public PillTagHelper(IPillHtmlGenerator pillHtmlGenerator)
    {
        _pillHtmlGenerator = pillHtmlGenerator;
    }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        var pill = _pillHtmlGenerator.GeneratePill(WithCircleName, Label, PillStatus);

        output.TagName = pill.TagName;
        output.TagMode = TagMode.StartTagAndEndTag;

        output.ClearAndMergeAttributes(pill);

        output.Content.SetHtmlContent(pill.InnerHtml);
    }
}
