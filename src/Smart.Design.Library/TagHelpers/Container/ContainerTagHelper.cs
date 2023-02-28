using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Library.TagHelpers.Constants;

namespace Smart.Design.Library.TagHelpers.Container;

/// <summary>
/// <see cref="ITagHelper"/> implementation of Smart design container with a <c>size</c> attribute.
/// The container object controls the maximum width on the horizontal axis, and the spacing on the vertical axis.
/// Documentation is available <see href="https://design.smart.coop/development/docs/o-container.html">here</see>.
/// </summary>
[HtmlTargetElement(TagNames.ContainerTagName, TagStructure = TagStructure.NormalOrSelfClosing)]
public class ContainerTagHelper : TagHelper
{
    private const string SizeAttributeName = "size";

    private readonly IContainerHtmlGenerator _containerHtmlGenerator;

    /// <summary>
    /// Size of the container.
    /// </summary>
    [HtmlAttributeName(SizeAttributeName)]
    public ContainerSize Size { get; set; } = ContainerSize.Medium;

    /// <summary>
    /// Creates a new <see cref="ContainerTagHelper"/>.
    /// </summary>
    /// <param name="containerHtmlGenerator">The services that serves the Smart Design Container HTML.</param>
    public ContainerTagHelper(IContainerHtmlGenerator containerHtmlGenerator)
    {
        _containerHtmlGenerator = containerHtmlGenerator;
    }

    /// <inheritdoc />
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        var container = _containerHtmlGenerator.GenerateSmartContainer(Size);

        output.Attributes.Clear();
        output.MergeAttributes(container);
        output.TagName = container.TagName;
        output.TagMode = TagMode.StartTagAndEndTag;
    }
}
