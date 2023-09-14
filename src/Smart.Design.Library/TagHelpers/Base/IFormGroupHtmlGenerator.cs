using Microsoft.AspNetCore.Mvc.Rendering;

namespace Smart.Design.Library.TagHelpers.Base;

/// <summary>
/// Contract for Form Group Generators.
/// </summary>
public interface IFormGroupHtmlGenerator
{
    /// <summary>
    /// Generates a form group with its label and an empty controls container.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="name"></param>
    /// <param name="label">The label associated to the form group.</param>
    /// <param name="helperText"></param>
    /// <param name="required"></param>
    /// <param name="controls">The content of the controls container.</param>
    /// <returns>A instance of a form group.</returns>
    TagBuilder GenerateFormGroup(
        string? id,
        string? name,
        string? label,
        string? helperText,
        bool? required,
        TagBuilder controls);

    /// <summary>
    /// Generates a form group &lt;div&gt;.
    /// The combination of a form label and an element field are usually wrapped inside this element.
    /// The consistent markup pattern makes it easy to manipulate grouped form elements.
    /// </summary>
    /// <returns> An instance of the &lt;div&gt;</returns>
    TagBuilder GenerateFormGroup();

    /// <summary>
    /// Generate a &lt;label&gt; element.
    /// </summary>
    /// <param name="label">The value of the label.</param>
    /// <param name="labelFor"></param>
    /// <param name="required"></param>
    /// <returns>A instance of the &lt;label&gt;</returns>
    TagBuilder GenerateFormGroupLabel(string? label, string? labelFor, bool? required);

    /// <summary>
    /// Generate a &lt;div&gt; in which are grouped element of a form group.
    /// </summary>
    /// <returns> An instance of the &lt;div&gt;</returns>
    TagBuilder GenerateFormGroupControlsContainer();

    /// <summary>
    /// Generates a &lt;p&gt; that contains an helper text.
    /// </summary>
    /// <param name="helperText">The helper text.</param>
    /// <returns>A <see cref="TagBuilder"/> instance of a helper text.</returns>
    TagBuilder GenerateFormGroupHelperText(string helperText);
}
