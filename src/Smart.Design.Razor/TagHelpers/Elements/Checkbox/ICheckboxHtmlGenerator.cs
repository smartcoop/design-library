using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Smart.Design.Razor.TagHelpers.Elements.Checkbox;

/// <summary>
/// Contract for checkboxes HTML generator.
/// </summary>
public interface ICheckboxHtmlGenerator
{
    /// <summary>
    /// Generates a Smart Design checkbox. See documentation <see href="https://design.smart.coop/development/docs/c-checkbox.html">here</see>.
    /// </summary>
    /// <param name="id">Id attribute of the checkbox.</param>
    /// <param name="name">Name attribute of the checkbox.</param>
    /// <param name="value">Value attribute of the checkbox.</param>
    /// <param name="label">Label associated to the checkbox.</param>
    /// <param name="disabled">State to indicate if the component should be disabled.</param>
    /// <param name="checked">Determines if the checkbox should be checked.</param>
    /// <param name="for">Expression that describe the model associated to the element.</param>
    /// <param name="attributeObjects">All other attributes</param>
    /// <returns>An instance of Smart Design checkbox.</returns>
    public TagBuilder GenerateCheckbox(
        string? id,
        string? name,
        string? value,
        string? label,
        bool disabled,
        bool @checked,
        ModelExpression? @for,
        List<TagHelperAttribute> attributeObjects);
}
