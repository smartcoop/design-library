namespace Smart.Design.Razor.TagHelpers.Pagination;

public class PaginationSettings
{
    public string? QueryString { get; set; }

    public string? Path { get; set; }

    public string PageNumberParameterName { get; set; } = null!;

    public int PageNumber { get; set; }

    public int TotalPages { get; set; }

    public int NumberOfLinks { get; set; }
}
