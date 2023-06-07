using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Library.TagHelpers.Constants;
using Smart.Design.Library.TagHelpers.Extensions;

namespace Smart.Design.Library.TagHelpers.Elements.Select;

/// <summary>
/// <see cref="ITagHelper"/> implementation of a Smart design select.
/// Documentation available <see href="https://design.smart.coop/development/docs/c-select.html">here</see>.
/// </summary>
[HtmlTargetElement(TagNames.SelectTagName)]
public class SelectTagHelper : Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper
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

    /// <summary>
    /// Creates a new <see cref="SelectTagHelper"/>.
    /// </summary>
    /// <param name="generator">The <see cref="IHtmlGenerator"/>.</param>
    public SelectTagHelper(IHtmlGenerator generator) : base(generator)
    {
    }

    /// <inheritdoc />
    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        await base.ProcessAsync(context, output);

        var select = new TagBuilder("select");
        select.MergeAttributes(output.Attributes);
        select.AddCssClass("c-select");

        if (Id is not null) {
            select.Attributes.Add("id", Id.ToString());
        }

        var name = output.Attributes["name"]?.Value?.ToString();

        if (!string.IsNullOrWhiteSpace(name) && ViewContext.HasModelStateErrorsByKey(name))
        {
            select.AddCssClass("c-select--error");
        }

        // Retrieving potential hardcoded <option> tags inside the <smart-select> tag.
        var extraOptions = await output.GetChildContentAsync();
        if (!extraOptions.IsEmptyOrWhiteSpace)
        {
            select.InnerHtml.AppendHtml(extraOptions);
        }

        // output.PostContent hold generated <option> tags from property Items.
        var options = new HtmlContentBuilder();
        output.PostContent.MoveTo(options);
        select.InnerHtml.AppendHtml(options);

        var holder = new TagBuilder("div");
        holder.AddCssClass("c-select-holder");
        holder.InnerHtml.AppendHtml(select);

        output.Reinitialize(holder.TagName, TagMode.StartTagAndEndTag);
        output.Content.Clear();
        output.PostContent.SetHtmlContent(select);
        output.ClearAllAttributes();
        output.MergeAttributes(holder);
    }
}
