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
            inputTextTagBuilder.Attributes[id] = id;
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
}
