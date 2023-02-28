using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Smart.Design.Library.TagHelpers.Elements.Radio;

public interface IRadioHtmlGenerator
{
    /// <summary>
    /// Generates a Smart design radio button.
    /// Documentation is available <see href="https://design.smart.coop/development/docs/c-radio-button.html">here</see>.
    /// </summary>
    /// <param name="id">The id of the generated &lt;input&gt; element.</param>
    /// <param name="name">The attribute name of the generated &lt;input&gt; element.</param>
    /// <param name="label">The label associated to the radio button.</param>
    /// <param name="value">Value of the generated &lt;input&gt; element.</param>
    /// <param name="checked">If the radio button is checked or not.</param>
    /// <param name="for">The <see cref="ModelExpression"/> passed to the tag helper.</param>
    /// <returns>A instance of a Smart design radio button.</returns>
    TagBuilder GenerateSmartRadio(string? id, string? name, string? label, string? value, bool @checked, ModelExpression? @for);

}
