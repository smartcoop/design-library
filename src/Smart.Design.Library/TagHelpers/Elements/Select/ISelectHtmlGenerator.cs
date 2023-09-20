using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Smart.Design.Library.TagHelpers.Elements.Select;

public interface ISelectHtmlGenerator
{
    TagBuilder GenerateSelect(
        ViewContext? viewContext,
        string? id,
        string? name,
        string? defaultValueLabel,
        bool? required,
        Dictionary<string, string>? items,
        ModelExpression? @for);
}
