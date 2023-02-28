using Microsoft.AspNetCore.Mvc.Rendering;

namespace Smart.Design.Library.TagHelpers.KeyValueList;

public interface IKeyValueListHtmlGenerator
{
    /// <summary>
    /// Generates a Smart Design Key Value List.
    /// </summary>
    /// <returns>A <see cref="TagBuilder"/> instance representing the Smart Design Key Value List.</returns>
    public TagBuilder GenerateKeyValueList();

    /// <summary>
    /// Generates a Smart Design Key value list item.
    /// </summary>
    /// <returns>A <see cref="TagBuilder"/> instance representing the Smart Design Key Value List item.</returns>
    public TagBuilder GenerateKeyValueItem(string? label, string? value);
}
