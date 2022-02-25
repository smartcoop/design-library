using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Razor.TagHelpers.Extensions;

namespace Smart.Design.Razor.TagHelpers.Layout.TagHelpers;

[HtmlTargetElement(TagNames.ApplicationLayoutInnerContent)]
public class ApplicationLayoutInnerContentTagHelper : TagHelper
{
    private readonly IHtmlLayoutGenerator _htmlLayoutGenerator;

    public ApplicationLayoutInnerContentTagHelper(IHtmlLayoutGenerator htmlLayoutGenerator)
    {
        _htmlLayoutGenerator = htmlLayoutGenerator;
    }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        var childrenContent = await output.GetChildContentAsync().ConfigureAwait(false);
        var content         = _htmlLayoutGenerator.GenerateApplicationLayoutInnerContent(childrenContent);

        content.InnerHtml.SetHtmlContent(content);

        output.TagName = content.TagName;
        output.TagMode = TagMode.StartTagAndEndTag;
        output.ClearAndMergeAttributes(content);
        output.Content.SetHtmlContent(content.InnerHtml);
    }
}
