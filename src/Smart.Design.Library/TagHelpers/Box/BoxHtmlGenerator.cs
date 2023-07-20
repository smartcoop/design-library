using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Smart.Design.Library.TagHelpers.Box;

/// <summary>
/// Create box.
/// To use in conjunction with <see cref="BoxTagHelper"/>
/// </summary>
public class BoxHtmlGenerator : IBoxHtmlGenerator
{
    /// <inheritdoc/>
    public TagBuilder GenerateListOfItems(string titleLabel, string title, string? subtitle, Dictionary<string, string> labelsAndValues)
    {
        var div = new TagBuilder("div");
        div.AddCssClass("c-panel c-panel--border-r-sm");

        var divHeader = new TagBuilder("div");
        divHeader.AddCssClass("c-panel__header c-panel__header-box o-block u-padding-vertical-m");

        var h3 = new TagBuilder("h3");
        h3.AddCssClass("c-panel__title");
        var titleLabelSpan = new TagBuilder("span");
        titleLabelSpan.InnerHtml.Append(titleLabel);
        var titleSpan = new TagBuilder("span");
        titleSpan.InnerHtml.Append(title);

        h3.InnerHtml.AppendHtml(titleLabelSpan);
        h3.InnerHtml.AppendHtml(titleSpan);
        divHeader.InnerHtml.AppendHtml(h3);

        if (!string.IsNullOrEmpty(subtitle))
        {
            var p = new TagBuilder("p");
            p.InnerHtml.Append(subtitle);
            divHeader.InnerHtml.AppendHtml(p);
        }

        var divBody = new TagBuilder("div");
        divBody.AddCssClass("c-panel__body u-padding-vertical");

        foreach (var item in labelsAndValues)
        {
            var p = new TagBuilder("p");
            p.AddCssClass("u-spacer-bottom-xs");
            var labelSpan = new TagBuilder("span");
            labelSpan.InnerHtml.Append(item.Key);
            var valueSpan = new TagBuilder("span");
            valueSpan.InnerHtml.Append(item.Value);
            p.InnerHtml.AppendHtml(labelSpan);
            p.InnerHtml.AppendHtml(valueSpan);
            divBody.InnerHtml.AppendHtml(p);
        }

        div.InnerHtml.AppendHtml(divHeader);
        div.InnerHtml.AppendHtml(divBody);
        return div ;
    }
}
