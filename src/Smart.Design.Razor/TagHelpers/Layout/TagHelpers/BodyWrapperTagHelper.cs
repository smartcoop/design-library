using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Razor.TagHelpers.Extensions;

namespace Smart.Design.Razor.TagHelpers.Layout.TagHelpers;

[HtmlTargetElement(TagNames.BodyWrapper)]
public class BodyWrapperTagHelper : TagHelper
{
    private readonly IHtmlLayoutGenerator _htmlLayoutGenerator;

    public BodyWrapperTagHelper(IHtmlLayoutGenerator htmlLayoutGenerator)
    {
        _htmlLayoutGenerator = htmlLayoutGenerator;
    }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        var childContent = await output.GetChildContentAsync().ConfigureAwait(false);
        var bodyWrapper = _htmlLayoutGenerator.GenerateBodyWrapper(childContent);

        output.ClearAndMergeAttributes(bodyWrapper);

        output.TagMode = TagMode.StartTagAndEndTag;
        output.TagName = bodyWrapper.TagName;
        output.Content.SetHtmlContent(bodyWrapper.InnerHtml);
    }
}
