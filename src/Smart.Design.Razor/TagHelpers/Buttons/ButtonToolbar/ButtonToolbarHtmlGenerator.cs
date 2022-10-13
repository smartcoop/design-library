using Microsoft.AspNetCore.Mvc.Rendering;

namespace Smart.Design.Razor.TagHelpers.Buttons.ButtonToolbar;

public class ButtonToolbarHtmlGenerator : IButtonToolbarHtmlGenerator
{

    /// <inheritdoc />
    public TagBuilder GenerateSmartButtonToolbar(ButtonToolbarLayout layout, bool isCompact)
    {
        var toolbar = new TagBuilder("div");
        toolbar.AddCssClass("c-button-toolbar");

        if (layout == ButtonToolbarLayout.Vertical)
        {
            toolbar.AddCssClass("c-button-toolbar--vertical");
        }

        if (isCompact)
        {
            toolbar.AddCssClass("c-button-toolbar--compact");
        }

        return toolbar;
    }
}
