using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Razor.Enums;
using Smart.Design.Razor.TagHelpers.Constants;
using Smart.Design.Razor.TagHelpers.Html;

namespace Smart.Design.Razor.TagHelpers.Containers
{
    /// <summary>
    ///     <see cref="ITagHelper" /> implementation of smart design container with a <c>size</c> attribute.
    ///     Documentation is available <see href="https://design.smart.coop/development/docs/o-container.html">here</see>.
    /// </summary>
    [HtmlTargetElement(TagNames.SmartContainerTagName, TagStructure = TagStructure.NormalOrSelfClosing)]
    public class SmartContainerTagHelper : TagHelper
    {
        private const string SizeAttributeName = "size";
        private readonly ISmartHtmlGenerator _smartHtmlGenerator;

        public SmartContainerTagHelper(ISmartHtmlGenerator smartHtmlGenerator)
        {
            _smartHtmlGenerator = smartHtmlGenerator;
        }

        [HtmlAttributeName(SizeAttributeName)] public ContainerSize Size { get; set; } = ContainerSize.Medium;

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var container = _smartHtmlGenerator.GenerateSmartContainer(Size);

            output.Attributes.Clear();
            output.MergeAttributes(container);
            output.TagName = container.TagName;
            output.TagMode = TagMode.StartTagAndEndTag;
        }
    }
}
