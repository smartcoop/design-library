using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Smart.Design.Razor.TagHelpers.Base;

namespace Smart.Design.Razor.TagHelpers.Elements.Input;

public class InputHtmlGenerator : BaseHtmlGenerator, IInputHtmlGenerator
{

    /// <inheritdoc />
    public TagBuilder GenerateInputText(ViewContext? viewContext, string? id, string? name, string? placeholder, object? value, ModelExpression? @for)
    {
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

        if (@for?.Model is string val)
        {
            inputTextTagBuilder.Attributes["value"] = val;
        }
        else if (value is string inputValue && !string.IsNullOrWhiteSpace(inputValue))
        {
            inputTextTagBuilder.Attributes["value"] = inputValue;
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
