using System;
using System.Globalization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Smart.Design.Razor.TagHelpers.Base;
using Smart.Design.Razor.TagHelpers.Extensions;

namespace Smart.Design.Razor.TagHelpers.Elements.Input;

public class InputHtmlGenerator : BaseHtmlGenerator, IInputHtmlGenerator
{

    /// <inheritdoc />
    public TagBuilder GenerateInputText(ViewContext? viewContext, string? id, string? name, string? placeholder, object? value, ModelExpression? @for)
    {
        if (viewContext is null)
        {
            throw new ArgumentNullException(nameof(viewContext), "A ViewContext must be supplied");
        }

        var inputTextTagBuilder = new TagBuilder("input");

        var inputName = GetAttributeName(name, @for);

        inputTextTagBuilder.Attributes.Add("type", "text");
        inputTextTagBuilder.AddCssClass("c-input");
        inputTextTagBuilder.TagRenderMode = TagRenderMode.SelfClosing;

        if (!string.IsNullOrWhiteSpace(id))
        {
            inputTextTagBuilder.Attributes["id"] = id;
        }

        if (!string.IsNullOrWhiteSpace(inputName))
        {
            inputTextTagBuilder.Attributes["name"] = inputName;
        }

        if (!string.IsNullOrWhiteSpace(placeholder))
        {
            inputTextTagBuilder.Attributes["placeholder"] = placeholder;
        }

        // The value of the model has always precedence over the attribute value.
        if (@for?.Model is not null)
        {
            inputTextTagBuilder.Attributes["value"] = Convert.ToString(@for.Model, CultureInfo.InvariantCulture);
        }
        else if (value is not null)
        {
            inputTextTagBuilder.Attributes["value"] = Convert.ToString(value, CultureInfo.InvariantCulture);
        }

        // If there are any errors for a named field, we add the CSS attribute.
        if (!string.IsNullOrWhiteSpace(inputName) && viewContext?.HasModelStateErrorsByKey(inputName) is true)
        {
            inputTextTagBuilder.AddCssClass("c-input--error");
        }

        return inputTextTagBuilder;
    }

    /// <inheritdoc />
    public TagBuilder GenerateInputTime(string? id, string? name, DateTime? value, ModelExpression? @for)
    {
        var tagBuilder = new TagBuilder("input");

        if (!string.IsNullOrWhiteSpace(id))
        {
            tagBuilder.Attributes.Add("id", id);
        }

        AddNameAttribute(tagBuilder, @for, name);

        tagBuilder.AddCssClass("c-input");
        tagBuilder.Attributes.Add("type", "time");

        if (@for?.Model is DateTime modelValue)
        {
            tagBuilder.Attributes.Add("value", $"{modelValue:HH:mm}");
        }
        else if (value.HasValue)
        {
            tagBuilder.Attributes.Add("value", $"{value.Value:HH:mm}");
        }

        return tagBuilder;
    }
}
