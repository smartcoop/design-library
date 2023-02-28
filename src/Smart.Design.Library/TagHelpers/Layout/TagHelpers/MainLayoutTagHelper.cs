using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Library.TagHelpers.Extensions;

namespace Smart.Design.Library.TagHelpers.Layout.TagHelpers;

[HtmlTargetElement(TagNames.MainLayout)]
public class MainLayoutTagHelper : TagHelper
{
    private readonly IHtmlLayoutGenerator _htmlLayoutGenerator;

    public MainLayoutTagHelper(IHtmlLayoutGenerator htmlLayoutGenerator)
    {
        _htmlLayoutGenerator = htmlLayoutGenerator;
    }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        IHtmlContent childContent = await output.GetChildContentAsync().ConfigureAwait(false);
        var mainElement = _htmlLayoutGenerator.GenerateMain(childContent);

        output.ClearAndMergeAttributes(mainElement);
        output.TagMode = TagMode.StartTagAndEndTag;
        output.TagName = mainElement.TagName;

        output.Content.SetHtmlContent(mainElement.InnerHtml);
    }
}
