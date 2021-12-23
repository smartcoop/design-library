using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Smart.Design.Razor.TagHelpers.Pill;

public class PillHtmlHtmlGenerator : IPillHtmlGenerator
{
    public TagBuilder GeneratePill(bool withCircle, string? label, PillStatus pillStatus)
    {
        var pill = new TagBuilder("span");
        pill.AddCssClass($"c-status-pill {CssLookAndFeelByStatus(pillStatus)}");

        if (withCircle)
        {
            var circle = new TagBuilder("span");
            circle.AddCssClass("c-status-pill__circle");
            pill.InnerHtml.AppendHtml(circle);
        }

        if (!string.IsNullOrWhiteSpace(label))
        {
            var labelDiv = new TagBuilder("label");
            labelDiv.AddCssClass("c-status-pill__label");
            labelDiv.InnerHtml.Append(label);
            pill.InnerHtml.AppendHtml(labelDiv);
        }

        return pill;
    }

    private string CssLookAndFeelByStatus(PillStatus pillStatus)
    {
        var baseCss = "c-status-pill--";

        return baseCss + pillStatus switch
        {
            PillStatus.Default => "default",
            PillStatus.Pending => "pending",
            PillStatus.Success => "success",
            PillStatus.Danger  => "danger",
            PillStatus.Warning => "warning",
            _                  => throw new InvalidOperationException($"CSS for status {pillStatus} unknown.")
        };
    }
}
