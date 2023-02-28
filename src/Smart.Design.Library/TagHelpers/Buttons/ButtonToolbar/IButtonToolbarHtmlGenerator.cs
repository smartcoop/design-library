using Microsoft.AspNetCore.Mvc.Rendering;

namespace Smart.Design.Library.TagHelpers.Buttons.ButtonToolbar;

public interface IButtonToolbarHtmlGenerator
{

    /// <summary>
    /// Generate a div that represents the smart button toolbar.
    /// Documentation is available <see href="https://design.smart.coop/development/docs/c-button-toolbar.html">here</see>.
    /// </summary>
    /// <param name="layout">The orientation of the item inside the toolbar. Value are.</param>
    /// <param name="isCompact">Tells is there should be no space between items.</param>
    /// <returns>A instance of a smart button toolbar</returns>
    TagBuilder GenerateSmartButtonToolbar(ButtonToolbarLayout layout, bool isCompact);
}
