using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Razor.TagHelpers.Constants;
using Smart.Design.Razor.TagHelpers.Extensions;
using Smart.Design.Razor.TagHelpers.Html;

namespace Smart.Design.Razor.TagHelpers.Widgets
{
    [HtmlTargetElement(TagNames.SmartLoader)]
    public class SmartLoaderTagHelper : TagHelper
    {
        private const string LoadingAttributeName = "loading";

        private readonly ISmartHtmlGenerator _smartHtmlGenerator;

        [HtmlAttributeName(LoadingAttributeName)]
        public bool Loading { get; set; } = true;

        public SmartLoaderTagHelper(ISmartHtmlGenerator smartHtmlGenerator)
        {
            _smartHtmlGenerator = smartHtmlGenerator;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var loader = _smartHtmlGenerator.GenerateLoader(Loading);

            output.TagMode = TagMode.StartTagAndEndTag;
            output.TagName = loader.TagName;

            output.ClearAllAttributes();
            output.MergeAttributes(loader);
        }
    }
}
