using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Smart.Design.Razor.TagHelpers.Pagination;

public interface ISmartPaginationHtmlGenerator
{
    /// <summary>
    /// Generates a Smart Pagination component.
    /// </summary>
    /// <param name="settings">Settings to render the Smart Design Pagination.</param>
    /// <returns>A instance that contains the HTML of the Smart Design Pagination.</returns>
    public Task<TagBuilder> GenerateSmartPaginationAsync(PaginationSettings settings);
}
