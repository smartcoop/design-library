using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Razor.TagHelpers.Constants;
using Smart.Design.Razor.TagHelpers.Extensions;

namespace Smart.Design.Razor.TagHelpers.Elements.Select;

/// <summary>
/// <see cref="ITagHelper"/> implementation of a Smart design select.
/// Documentation available <see href="https://design.smart.coop/development/docs/c-select.html">here</see>.
/// </summary>
[HtmlTargetElement(TagNames.SelectTagName)]
public class SelectTagHelper : Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper
{
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
