namespace Smart.Design.Razor.TagHelpers.Pagination;

public class PaginationSettings
{
    /// <summary>
    /// Extra query string that should be add to the URI of page links.
    /// </summary>
    public string? QueryString { get; set; }

    /// <summary>
    /// Relative URL path of the resource.
    /// </summary>
    public string? Path { get; set; }

    /// <summary>
    /// The query string parameter name for current page number value.
    /// </summary>
    public string PageNumberParameterName { get; set; } = null!;

    /// <summary>
    /// The current page value.
    /// </summary>
    public int PageNumber { get; set; }

    /// <summary>
    /// The total pages count.
    /// </summary>
    public int TotalPages { get; set; }

    /// <summary>
    /// The number of page links to display.
    /// </summary>
    public int NumberOfLinks { get; set; }
}
