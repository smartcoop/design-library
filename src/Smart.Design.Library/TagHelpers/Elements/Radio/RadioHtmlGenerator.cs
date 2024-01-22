using System;
using System.Globalization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Smart.Design.Library.TagHelpers.Elements.Radio;

public class RadioHtmlGenerator : IRadioHtmlGenerator
{
    public TagBuilder GenerateSmartRadio(string? id, string? name, string? label, string? value, bool @checked, ModelExpression? @for)
    {
        var inputRadioContainer = new TagBuilder("div");

        inputRadioContainer.AddCssClass("c-radio");

        var radioName = !string.IsNullOrWhiteSpace(@for?.Name) ? @for.Name : name;

        var inputRadioTagBuilder = new TagBuilder("input");
        inputRadioTagBuilder.Attributes.Add("name", radioName);
        inputRadioTagBuilder.Attributes.Add("type", "radio");
        inputRadioTagBuilder.Attributes.Add("id", id);


        var modelValue = Convert.ToString(@for?.Model, CultureInfo.CurrentCulture);

        if (@for?.Model is not null)
        {
            inputRadioTagBuilder.Attributes["value"] = Convert.ToString(@for.Model, CultureInfo.InvariantCulture);
        }
        else if (value is not null)
        {
            inputRadioTagBuilder.Attributes["value"] = Convert.ToString(value, CultureInfo.InvariantCulture);
        }

        if (@checked)
        {
            inputRadioTagBuilder.Attributes["checked"] = "checked";
        }

        if (!string.IsNullOrWhiteSpace(id))
        {
            inputRadioTagBuilder.Attributes["id"] = id;
        }

        var labelTagBuilder = new TagBuilder("label");
        labelTagBuilder.InnerHtml.AppendHtml(inputRadioTagBuilder);
        labelTagBuilder.InnerHtml.AppendHtml($"<span>{label}</span>");

        inputRadioContainer.InnerHtml.AppendHtml(labelTagBuilder);

        return inputRadioContainer;
    }
}
