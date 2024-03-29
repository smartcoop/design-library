using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Smart.Design.Library.TagHelpers.GridList;

/// <summary>
/// Generate a header &lt;theadt&gt;.
/// </summary>
public interface IGridListHeaderHtmlGenerator
{
    /// <summary>
    /// Generate the title of the column's table from a <see cref="titles"/> list
    /// </summary>
    /// <param name="titles">The list of column titles</param>
    /// <returns></returns>
    TagBuilder GenerateHeader(List<string> titles);
}
