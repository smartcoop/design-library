using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Smart.Design.Library.TagHelpers.Base;

/// <summary>
/// Base <see cref="ITagHelper"/> class targeting html elements with an id and name attributes.
/// Exposes ViewContext.
/// This class is abstract.
/// </summary>
public abstract class BaseTagHelper : TagHelper
{
    /// <summary>
    /// Id HTML attribute name.
    /// </summary>
    protected const string IdAttributeName = "id";

    /// <summary>
    /// Name HTML attribute name.
    /// </summary>
    protected const string NameAttributeName = "name";

    /// <summary>
    /// Gets or Sets the Id of the underlying Tag Helper.
    /// </summary>
    [HtmlAttributeName(IdAttributeName)]
    public string? Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the underlying Tag Helper.
    /// </summary>
    [HtmlAttributeName(NameAttributeName)]
    public string? Name { get; set; }

    /// <summary>
    /// Get or sets the <see cref="Microsoft.AspNetCore.Mvc.Rendering.ViewContext"/> of the executing view.
    /// </summary>
    [HtmlAttributeNotBound]
    [ViewContext]
    public ViewContext? ViewContext { get; set; }
}
