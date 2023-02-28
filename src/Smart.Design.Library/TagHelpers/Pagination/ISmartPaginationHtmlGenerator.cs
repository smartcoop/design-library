using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Smart.Design.Library.TagHelpers.Pagination;

/// <summary>
/// Represents a service that generates the HTML of a Smart Pagination component.
/// </summary>
public interface ISmartPaginationHtmlGenerator
{
    /// <summary>
    /// Generates the HTML of a Smart Pagination component.
    /// </summary>
    /// <param name="settings">Settings to render the Smart Design Pagination.</param>
    /// <returns>An instance that contains the HTML of the Smart Design Pagination.</returns>
    public Task<TagBuilder> GenerateSmartPaginationAsync(PaginationSettings settings);
}
