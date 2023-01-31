using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Smart.Design.Razor.TagHelpers.Elements.Checkbox;

/// <summary>
/// Generates HTML to render checkboxes.
/// </summary>
public class CheckboxHtmlGenerator : ICheckboxHtmlGenerator
{
    /// <inheritdoc />
    public TagBuilder GenerateCheckbox(string? id, string? name, string? value, string? label, bool disabled, bool @checked, ModelExpression? @for, List<TagHelperAttribute> attributeObjects)
    {
        // Root HTML element of the component is a div containing a label and an input.
        var rootDiv = new TagBuilder("div");
        rootDiv.AddCssClass("c-checkbox");

        // HTML label contains the checkbox.
        var labelDiv = new TagBuilder("label");
        var checkbox = new TagBuilder("input")
        {
            TagRenderMode = TagRenderMode.SelfClosing,
            Attributes =
            {
                { "type" , "checkbox" },
                { "value", "true" }
            }
        };

        // Sets the id if defined.
        if (!string.IsNullOrWhiteSpace(id))
        {
            checkbox.Attributes["id"] = id;
        }

        // Determines the name attribute. @for has precedence over the name parameter.
        if (!string.IsNullOrWhiteSpace(@for?.Name))
        {
            checkbox.Attributes["name"] = @for.Name;

            // If the associated model is a collection, the checkbox value should have been hardcoded in the HTML.
            if (!string.IsNullOrWhiteSpace(value) &&
                typeof(IEnumerable).IsAssignableFrom(@for.ModelExplorer.ModelType))
            {
                checkbox.Attributes["value"] = value;
            }
        }
        else if (!string.IsNullOrWhiteSpace(name))
        {
            checkbox.Attributes["name"] = name;
        }

        if (disabled)
        {
            checkbox.Attributes["disabled"] = "disabled";
        }

        // Checks the checkbox if the associated expression value is true.
        // Fallback to checked variable if the model is null.
        if (@for?.Model is true || @checked)
        {
            checkbox.Attributes["checked"] = "checked";
        }

        if(attributeObjects.Count > 0)
        {
            foreach (var attributeObject in attributeObjects) {
                checkbox.Attributes[attributeObject.Name] = attributeObject.Value.ToString();
            }
        }

        // The <label> element has two children: the checkbox followed by the label.
        labelDiv.InnerHtml.SetHtmlContent(checkbox);
        if (!string.IsNullOrWhiteSpace(label))
        {
            labelDiv.InnerHtml.Append(label);
        }

        rootDiv.InnerHtml.SetHtmlContent(labelDiv);

        return rootDiv;
    }
}
