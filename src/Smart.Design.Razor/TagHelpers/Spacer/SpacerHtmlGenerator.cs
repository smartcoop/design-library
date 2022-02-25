using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Smart.Design.Razor.TagHelpers.Spacer;

public class SpacerHtmlGenerator : ISpacerHtmlGenerator
{
    /// <inheritdoc />
    public TagBuilder GenerateSpacer(Size all, Size left, Size top, Size right, Size bottom)
    {
        const string uSpacer = "u-spacer";

        var spacer = new TagBuilder("div");

        if (all != Size.Unspecified)
        {
            spacer.AddCssClass(SizeToCssClass($"{uSpacer}", all));
        }

        if (left != Size.Unspecified)
        {
            spacer.AddCssClass(SizeToCssClass($"{uSpacer}-left", left));
        }

        if (top != Size.Unspecified)
        {
            spacer.AddCssClass(SizeToCssClass($"{uSpacer}-top", top));
        }

        if (right != Size.Unspecified)
        {

            spacer.AddCssClass(SizeToCssClass($"{uSpacer}-right", right));
        }

        if (bottom != Size.Unspecified)
        {
            spacer.AddCssClass(SizeToCssClass($"{uSpacer}-bottom", bottom));
        }

        return spacer;
    }

    private string SizeToCssClass(string baseCss, Size size)
    {
        // Let's make sure that there is a dash at the end.
        baseCss = baseCss.TrimEnd('-') + '-';
        return baseCss + size switch
        {
            Size.Default     => string.Empty,
            Size.ExtraSmall  => "xs",
            Size.Small       => "s",
            Size.Large       => "l",
            Size.ExtraLarge  => "xl",
            Size.Auto        => "auto",
            Size.Unspecified =>
                throw new InvalidOperationException($"{nameof(Size.Unspecified)} cannot have any css"),
            _                =>
                throw new ArgumentOutOfRangeException(nameof(size), size, "Provided size is not supported")
        };
    }
}
