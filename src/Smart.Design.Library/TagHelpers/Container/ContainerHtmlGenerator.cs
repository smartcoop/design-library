using Microsoft.AspNetCore.Mvc.Rendering;

namespace Smart.Design.Library.TagHelpers.Container;

public class ContainerHtmlGenerator : IContainerHtmlGenerator
{
    /// <inheritdoc />
    public TagBuilder GenerateSmartContainer(ContainerSize size)
    {
        var container = new TagBuilder("div");
        var cssClass = ContainerSizeCssClass(size);
        container.AddCssClass("o-container");
        container.AddCssClass(cssClass);

        return container;
    }

    private static string ContainerSizeCssClass(ContainerSize size)
    {
        return size switch
        {
            ContainerSize.Small  => "o-container--small",
            ContainerSize.Medium => "o-container--medium",
            ContainerSize.Large  => "o-container--large",
            _                    => "o-container--medium"
        };
    }
}
