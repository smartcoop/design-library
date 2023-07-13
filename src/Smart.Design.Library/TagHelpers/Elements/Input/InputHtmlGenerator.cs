using System;
using System.Globalization;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Smart.Design.Library.TagHelpers.Base;
using Smart.Design.Library.TagHelpers.Extensions;

namespace Smart.Design.Library.TagHelpers.Elements.Input;

/// <inheritdoc cref="IInputHtmlGenerator"/>
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

    public TagBuilder GenerateInputNumber(string? id, string? name, int? value, ModelExpression? @for)
    {
        var tagBuilder = new TagBuilder("input");

        if (!string.IsNullOrWhiteSpace(id))
        {
            tagBuilder.Attributes.Add("id", id);
        }

        AddNameAttribute(tagBuilder, @for, name);
        tagBuilder.AddCssClass("c-input");
        tagBuilder.Attributes.Add("type", "number");
        tagBuilder.Attributes.Add("value", $"{value}");

        return tagBuilder;
    }

    /// <inheritdoc />
    public TagBuilder GenerateInputTel(
        ViewContext? viewContext,
        string? id,
        string? name,
        string? placeholder,
        object? value,
        PhoneType? phoneType,
        // int? maxLength,
        // int? minLength,
        // string? pattern,
        // string? readOnly,
        // int? size,
        ModelExpression? @for)
    {
        if (viewContext is null)
        {
            throw new ArgumentNullException(nameof(viewContext), "A ViewContext must be supplied");
        }

        var inputTelTagBuilder = new TagBuilder("input");

        var inputName = GetAttributeName(name, @for);

        inputTelTagBuilder.Attributes.Add("type", "tel");
        inputTelTagBuilder.AddCssClass("c-input");
        inputTelTagBuilder.TagRenderMode = TagRenderMode.SelfClosing;

        if (!string.IsNullOrWhiteSpace(id))
        {
            inputTelTagBuilder.Attributes["id"] = id;
        }

        if (!string.IsNullOrWhiteSpace(inputName))
        {
            inputTelTagBuilder.Attributes["name"] = inputName;
        }

        if (!string.IsNullOrWhiteSpace(placeholder))
        {
            if (!phoneType.HasValue)
            {
                inputTelTagBuilder.Attributes["placeholder"] = placeholder;
            }
            else
            {
                inputTelTagBuilder.Attributes["placeholder"] = phoneType == PhoneType.Landline ? "landline" : "mobile";
            }
        }

        // The value of the model has always precedence over the attribute value.
        if (@for?.Model is not null)
        {
            inputTelTagBuilder.Attributes["value"] = Convert.ToString(@for.Model, CultureInfo.InvariantCulture);
        }
        else if (value is not null)
        {
            inputTelTagBuilder.Attributes["value"] = Convert.ToString(value, CultureInfo.InvariantCulture);
        }

        if (phoneType.HasValue)
        {
            var pattern = phoneType == PhoneType.Landline ?
                "^(0|\\+)(\\d{1,4}|\\d{2,3}\\(\\d{1,3}\\)|\\d{2,3}\\s\\d{1,4}|\\d{2,3}\\.\\d{1,4}|\\d{2,3}-\\d{1,4})$" :
                "^(?:\\+|00)(?:(?:[1-9]\\d{0,3}(?:\\(\\d{1,4}\\))?)|\\d{1,4})(?:[-.]?\\d{1,4}){0,5}<\\d$";
            inputTelTagBuilder.Attributes["pattern"] = pattern;
        }

        // if (maxLength.HasValue)
        // {
        //     inputTelTagBuilder.Attributes["maxlength"] = maxLength.Value.ToString(CultureInfo.InvariantCulture);
        // }
        //
        // if (minLength.HasValue)
        // {
        //     inputTelTagBuilder.Attributes["minlength"] = minLength.Value.ToString(CultureInfo.InvariantCulture);
        // }
        //
        // if (!string.IsNullOrWhiteSpace(pattern))
        // {
        //     inputTelTagBuilder.Attributes["pattern"] = pattern;
        // }
        //
        // if (!string.IsNullOrWhiteSpace(readOnly))
        // {
        //     inputTelTagBuilder.Attributes["readonly"] = readOnly;
        // }
        //
        // if (size.HasValue)
        // {
        //     inputTelTagBuilder.Attributes["size"] = size.Value.ToString(CultureInfo.InvariantCulture);
        // }

        if (!string.IsNullOrWhiteSpace(inputName) && viewContext?.HasModelStateErrorsByKey(inputName) is true)
        {
            inputTelTagBuilder.AddCssClass("c-input--error");
        }

        return inputTelTagBuilder;
    }

    /// <inheritdoc />
    public TagBuilder GenerateInputEmail(ViewContext? viewContext, string? id, string? name, string? placeholder, object? value, ModelExpression? @for)
    {
        if (viewContext is null)
        {
            throw new ArgumentNullException(nameof(viewContext), "A ViewContext must be supplied");
        }

        var inputTextTagBuilder = new TagBuilder("input");

        var inputName = GetAttributeName(name, @for);

        inputTextTagBuilder.Attributes.Add("type", "email");
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
    public TagBuilder GenerateInputDate(ViewContext? viewContext, string? id, string? name, string? placeholder, DateTime? value, ModelExpression? @for)
    {
        if (viewContext is null)
        {
            throw new ArgumentNullException(nameof(viewContext), "A ViewContext must be supplied");
        }

        var inputDate = new TagBuilder("input");

        var inputName = GetAttributeName(name, @for);

        inputDate.Attributes.Add("type", "date");
        inputDate.Attributes["pattern"] = "\\d{2}/\\d{2}/\\d{4}";
        inputDate.AddCssClass("c-input");
        inputDate.TagRenderMode = TagRenderMode.SelfClosing;

        if (!string.IsNullOrWhiteSpace(id))
        {
            inputDate.Attributes["id"] = id;
        }

        if (!string.IsNullOrWhiteSpace(inputName))
        {
            inputDate.Attributes["name"] = inputName;
        }

        if (!string.IsNullOrWhiteSpace(placeholder))
        {
            inputDate.Attributes["placeholder"] = placeholder;
        }
        else
        {
            inputDate.Attributes["placeholder"] = "dd/MM/yyyy";
        }

        if (@for?.Model is DateTime modelValue)
        {
            inputDate.Attributes.Add("value", $"{modelValue:dd/MM/yyyy}");
        }
        else if (value.HasValue)
        {
            inputDate.Attributes.Add("value", $"{value.Value:dd/MM/yyy}");
        }

        // If there are any errors for a named field, we add the CSS attribute.
        if (!string.IsNullOrWhiteSpace(inputName) && viewContext?.HasModelStateErrorsByKey(inputName) is true)
        {
            inputDate.AddCssClass("c-input--error");
        }

        return inputDate;
    }
}
