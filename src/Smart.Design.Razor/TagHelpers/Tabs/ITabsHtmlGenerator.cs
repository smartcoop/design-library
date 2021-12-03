using Microsoft.AspNetCore.Mvc.Rendering;

namespace Smart.Design.Razor.TagHelpers.Tabs;

public interface ITabsHtmlGenerator
{
    /// <summary>
    /// Generate a empty &lt;nav&gt; element compliant with Smart design tab whose purpose is containing Smart design tab items.
    /// </summary>
    /// <param name="bordered">True if the tab items should be bordered.</param>
    /// <returns>An instance of a empty Smart design tab.</returns>
    TagBuilder GenerateTab(bool bordered);

    /// <summary>
    /// Generates a &lt;ul&gt; element whose purpose is containing Smart design tab items.
    /// </summary>
    /// <returns>An instance of a &lt;ul&gt; element</returns>
    TagBuilder GenerateTabItemsContainer();

    /// <summary>
    /// Generate a Smart design tab item.
    /// </summary>
    /// <param name="label">Label of the tab item.</param>
    /// <param name="ref">Html reference to its html content.</param>
    /// <returns>A instance of a Smart design tab item.</returns>
    TagBuilder GenerateTabItem(string? label, string? @ref);

    /// <summary>
    /// Generates a Smart design tab's section. A Smart design tab's section is the content that is related to a Smart design tab ite.
    /// </summary>
    /// <param name="id">Html id of the Smart design tab section. The id should be matching of the Smart design tab items.</param>
    /// <returns>A instance of a Smart design tab section.</returns>
    TagBuilder GenerateTabSection(string? id);
}
