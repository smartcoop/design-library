using Microsoft.AspNetCore.Mvc.Rendering;
using Smart.Design.Razor.Enums;

namespace Smart.Design.Razor.TagHelpers.IconList
{
    public interface ISmartIconListHtmlGenerator
    {
        /// <summary>
        /// Generates an smart design icon list.
        /// </summary>
        /// <returns>A instance of a smart design icon list.</returns>
        TagBuilder GenerateIconList();

        /// <summary>
        /// Generates a smart design icon list item.
        /// An icon list item is a item that is part of an icon list.
        /// </summary>
        /// <param name="icon">The leading <see cref="Icon"/> of the item</param>
        /// <param name="label">The item's label.</param>
        /// <returns>An instance of an smart design icon list item.</returns>
        TagBuilder GenerateIconListItem(Icon icon, string label);
    }
}
