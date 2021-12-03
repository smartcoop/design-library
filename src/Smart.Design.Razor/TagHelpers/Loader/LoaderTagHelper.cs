using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Razor.TagHelpers.Constants;
using Smart.Design.Razor.TagHelpers.Extensions;

namespace Smart.Design.Razor.TagHelpers.Loader;

[HtmlTargetElement(TagNames.LoaderTagName)]
public class LoaderTagHelper : TagHelper
{
    private const string LoadingAttributeName = "loading";

    private readonly ILoaderHtmlGenerator _loaderHtmlGenerator;

    [HtmlAttributeName(LoadingAttributeName)]
    public bool Loading { get; set; } = true;

    public LoaderTagHelper(ILoaderHtmlGenerator loaderHtmlGenerator)
    {
        _loaderHtmlGenerator = loaderHtmlGenerator;
    }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        var loader = _loaderHtmlGenerator.GenerateLoader(Loading);

        output.TagMode = TagMode.StartTagAndEndTag;
        output.TagName = loader.TagName;

        output.ClearAllAttributes();
        output.MergeAttributes(loader);
    }
}
