using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Library.TagHelpers.Extensions;

namespace Smart.Design.Library.TagHelpers.Layout.TagHelpers;

[HtmlTargetElement(TagNames.Body)]
public class BodyTagHelper : TagHelper
{
    private readonly IHtmlLayoutGenerator _htmlLayoutGenerator;

    public BodyTagHelper(IHtmlLayoutGenerator htmlLayoutGenerator)
    {
        _htmlLayoutGenerator = htmlLayoutGenerator;
    }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        var body = _htmlLayoutGenerator.GenerateBody();

        output.ClearAndMergeAttributes(body);
        output.TagMode = TagMode.StartTagAndEndTag;
        output.TagName = body.TagName;
    }
}
