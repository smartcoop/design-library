using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Razor.TagHelpers.Constants;

namespace Smart.Design.Razor.TagHelpers.Container;

/// <summary>
/// <see cref="ITagHelper"/> implementation of Smart design container with a <c>size</c> attribute.
/// Documentation is available <see href="https://design.smart.coop/development/docs/o-container.html">here</see>.
/// </summary>
[HtmlTargetElement(TagNames.ContainerTagName, TagStructure = TagStructure.NormalOrSelfClosing)]
public class ContainerTagHelper : TagHelper
{
    private readonly IContainerHtmlGenerator _containerHtmlGenerator;

    private const string SizeAttributeName = "size";

    [HtmlAttributeName(SizeAttributeName)]
    public ContainerSize Size { get; set; } = ContainerSize.Medium;

    public ContainerTagHelper(IContainerHtmlGenerator containerHtmlGenerator)
    {
        _containerHtmlGenerator = containerHtmlGenerator;
    }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        var container = _containerHtmlGenerator.GenerateSmartContainer(Size);

        output.Attributes.Clear();
        output.MergeAttributes(container);
        output.TagName = container.TagName;
        output.TagMode = TagMode.StartTagAndEndTag;
    }
}
