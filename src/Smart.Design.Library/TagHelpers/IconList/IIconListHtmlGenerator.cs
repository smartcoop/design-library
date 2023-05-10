using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Smart.Design.Library.TagHelpers.IconList;

public interface IIconListHtmlGenerator
{
    /// <summary>
    /// Generates an Smart design icon list.
    /// </summary>
    /// <returns>A instance of a Smart design icon list.</returns>
    TagBuilder GenerateIconList();

    /// <summary>
    /// Generates a Smart design icon list item.
    /// An icon list item is a item that is part of an icon list.
    /// </summary>
    /// <param name="icon">The leading <see cref="Icon"/> of the item</param>
    /// <param name="label">The item's label.</param>
    /// <returns>An instance of an Smart design icon list item.</returns>
    Task<TagBuilder> GenerateIconListItemAsync(Image.Image icon, string? label);
}
