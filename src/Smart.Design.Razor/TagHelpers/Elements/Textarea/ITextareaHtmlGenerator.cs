using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Smart.Design.Razor.TagHelpers.Elements.Textarea;

public interface ITextareaHtmlGenerator
{
    /// <summary>
    /// Generate a &lt;textarea&gt; that is compliant with Smart design.
    /// </summary>
    /// <param name="id">The id of the &lt;textarea&gt;</param>
    /// <param name="name">The name of the &lt;textarea&gt;</param>
    /// <param name="rows">The number of rows of the &lt;textarea&gt;. This parameter is optional.</param>
    /// <param name="textareaSize"></param>
    /// <param name="for"></param>
    /// <returns>An instance of the &lt;textarea&gt;</returns>
    TagBuilder GenerateSmartTextArea(string? id, string? name, int? rows, TextAreaSize textareaSize, ModelExpression? @for);
}
