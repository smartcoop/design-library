using System;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Smart.Design.Library.TagHelpers.Elements.Input;
using Smart.Design.Library.TagHelpers.Icon;

namespace Smart.Design.Library.TagHelpers.InputGroup;

/// <inheritdoc cref="IInputGroupHtmlGenerator"/>
public class InputGroupHtmlGenerator : IInputGroupHtmlGenerator
{
    private readonly IIconHtmlGenerator _iconHtmlGenerator;
    private readonly IInputHtmlGenerator _inputHtmlGenerator;

    /// <summary>
    /// Creates a new <see cref="InputGroupHtmlGenerator"/>.
    /// </summary>
    /// <param name="iconHtmlGenerator">THe service that generates Smart Icons HTML.</param>
    /// <param name="inputHtmlGenerator">The services that generates input HTML.</param>
    public InputGroupHtmlGenerator(IIconHtmlGenerator iconHtmlGenerator, IInputHtmlGenerator inputHtmlGenerator)
    {
        _iconHtmlGenerator = iconHtmlGenerator;
        _inputHtmlGenerator = inputHtmlGenerator;
    }

    /// <inheritdoc />
    public TagBuilder GenerateInputGroup(
        ViewContext? viewContext,
        string? id,
        string? name,
        string? placeholder,
        string? value,
        ModelExpression? @for,
        Alignment alignment,
        Image icon,
        string? text)
    {
        // Root element.
        var inputGroup = new TagBuilder("div");
        inputGroup.AddCssClass("c-input-group");

        if (!string.IsNullOrWhiteSpace(text) && icon != Image.None)
        {
            throw new ArgumentException($"{nameof(text)} and {nameof(icon)} can not be specified at the same time");
        }

        // Content can be aligned at the beginning or at the end of the inputGroup.

        TagBuilder? group = null;

        // If text or icon is set we need to prepare the grouping.
        if (!string.IsNullOrWhiteSpace(text) || icon != Image.None)
        {
            group = new TagBuilder("div");
            group.AddCssClass($"c-input-group__{(alignment == Alignment.Start ? "prepend" : "append")}");

            if (icon is not Image.None)
            {
                var svgIcon = _iconHtmlGenerator.GenerateIcon(icon);
                group.InnerHtml.SetHtmlContent(svgIcon);
            }
            else if (text is not null)
            {
                group.InnerHtml.SetHtmlContent(text);
            }
        }

        if (group is not null && alignment == Alignment.Start)
        {
            inputGroup.InnerHtml.AppendHtml(group);
        }

        var inputDiv = new TagBuilder("div");
        inputDiv.AddCssClass("c-input-group__input");
        inputDiv.InnerHtml.AppendHtml(_inputHtmlGenerator.GenerateInputText(viewContext, id, name, placeholder, value, @for));

        inputGroup.InnerHtml.AppendHtml(inputDiv);

        if (alignment == Alignment.End && group is not null && group.HasInnerHtml)
        {
            inputGroup.InnerHtml.AppendHtml(group);
        }

        return inputGroup;
    }
}
