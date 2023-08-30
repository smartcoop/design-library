using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Library.TagHelpers.Base;
using Smart.Design.Library.TagHelpers.Constants;
using Smart.Design.Library.TagHelpers.Extensions;

namespace Smart.Design.Library.TagHelpers.Elements.Select;

/// <summary>
/// <see cref="ITagHelper"/> implementation of a Smart design select.
/// Documentation available <see href="https://design.smart.coop/development/docs/c-select.html">here</see>.
/// </summary>
[HtmlTargetElement(TagNames.SelectTagName)]
public class SelectTagHelper : BaseTagHelper
{
    private readonly ISelectHtmlGenerator _iSelectHtmlGenerator;

    /// <summary>
    /// Id HTML attribute name.
    /// </summary>
    private const string NameAttributeId = "id";

    /// <summary>
    /// Name HTML attribute name.
    /// </summary>
    private const string NameAttributeName = "name";

    private const string NameDefaultValueLabel = "defautValueLabel";

    private const string ItemsAttributeName = "items";

    private const string AspForNameAttribute   = "asp-for";

    /// <summary>
    /// Gets or Sets the Id of the underlying Tag Helper.
    /// </summary>
    [HtmlAttributeName(NameAttributeId)]
    public string? Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the underlying Tag Helper.
    /// </summary>
    [HtmlAttributeName(NameAttributeName)]
    public string? Name { get; set; }

    /// <summary>
    /// Gets or sets the default value label of the underlying Tag Helper.
    /// </summary>
    [HtmlAttributeName(NameDefaultValueLabel)]
    public string? DefaultValueLabel { get; set; }

    /// <summary>
    /// Get or sets the <see cref="Microsoft.AspNetCore.Mvc.Rendering.ViewContext"/> of the executing view.
    /// </summary>
    [HtmlAttributeNotBound]
    [ViewContext]
    public ViewContext? ViewContext { get; set; }

    /// <summary>
    /// <see cref="ModelExpression"/> for the tag helper.
    /// </summary>
    [HtmlAttributeName(AspForNameAttribute)]
    public ModelExpression? For { get; set; }

    /// <summary>
    /// HTML items of the select.
    /// </summary>
    [HtmlAttributeName(ItemsAttributeName)]
    public Dictionary<string, string>? Items { get; set; }

    /// <summary>
    /// Creates a new <see cref="SelectTagHelper"/>.
    /// </summary>
    /// <param name="selectHtmlGenerator">The <see cref="ISelectHtmlGenerator"/>.</param>
    public SelectTagHelper(ISelectHtmlGenerator iSelectHtmlGenerator)
    {
        _iSelectHtmlGenerator = iSelectHtmlGenerator;
    }

    /// <inheritdoc />
    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        base.Process(context, output);

        var select = _iSelectHtmlGenerator.GenerateSelect(ViewContext, Id, Name, DefaultValueLabel, Items, For);

        output.TagName = select.TagName;
        output.TagMode = TagMode.StartTagAndEndTag;

        output.ClearAllAttributes();
        output.MergeAttributes(select);

        output.Content.SetHtmlContent(select.InnerHtml);
    }
}
