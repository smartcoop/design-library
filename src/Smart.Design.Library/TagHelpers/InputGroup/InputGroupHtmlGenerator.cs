using System;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Smart.Design.Library.TagHelpers.Elements.Input;
using Smart.Design.Library.TagHelpers.Image;

namespace Smart.Design.Library.TagHelpers.InputGroup;

/// <inheritdoc cref="IInputGroupHtmlGenerator"/>
public class InputGroupHtmlGenerator : IInputGroupHtmlGenerator
{
    private readonly IImageHtmlGenerator _imageHtmlGenerator;
    private readonly IInputHtmlGenerator _inputHtmlGenerator;

    /// <summary>
    /// Creates a new <see cref="InputGroupHtmlGenerator"/>.
    /// </summary>
    /// <param name="imageHtmlGenerator">The service which serves images as svg html tag.</param>
    /// <param name="inputHtmlGenerator">The services which generates input HTML.</param>
    public InputGroupHtmlGenerator(IImageHtmlGenerator imageHtmlGenerator, IInputHtmlGenerator inputHtmlGenerator)
    {
        _imageHtmlGenerator = imageHtmlGenerator;
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
        Image.Image icon,
        string? text)
    {
        // Root element.
        var inputGroup = new TagBuilder("div");
        inputGroup.AddCssClass("c-input-group");

        if (!string.IsNullOrWhiteSpace(text) && icon != Image.Image.None)
        {
            throw new ArgumentException($"{nameof(text)} and {nameof(icon)} can not be specified at the same time");
        }

        // Content can be aligned at the beginning or at the end of the inputGroup.

        TagBuilder? group = null;

        // If text or icon is set we need to prepare the grouping.
        if (!string.IsNullOrWhiteSpace(text) || icon != Image.Image.None)
        {
            group = new TagBuilder("div");
            group.AddCssClass($"c-input-group__{(alignment == Alignment.Start ? "prepend" : "append")}");

            if (icon is not Image.Image.None)
            {
                var svgIcon = _imageHtmlGenerator.GenerateIcon(icon);
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
