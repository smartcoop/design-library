using Microsoft.AspNetCore.Mvc.Rendering;

namespace Smart.Design.Library.TagHelpers.KeyValueList;

public class KeyValueListHtmlGenerator : IKeyValueListHtmlGenerator
{
    /// <inheritdoc />
    public TagBuilder GenerateKeyValueList()
    {
        var keyValueList = new TagBuilder("dl");
        keyValueList.AddCssClass("c-key-value");

        return keyValueList;
    }

    /// <inheritdoc />
    public TagBuilder GenerateKeyValueItem(string? label, string? value)
    {
        // A key Value item is a div with one dt and one dd element.
        var keyValueContainer = new TagBuilder("div");
        keyValueContainer.AddCssClass("c-key-value-item");

        // Reminder: IHtmlContentBuilder.Append does nothing if the argument is null.

        var keyElement = new TagBuilder("dt");
        keyElement.AddCssClass("c-key-value-item__key");
        keyElement.InnerHtml.Append(label);

        var valueElement = new TagBuilder("dd");
        valueElement.AddCssClass("c-key-value-item__value");
        valueElement.InnerHtml.Append(value);

        // finally stack key and value elements inside the container.
        keyValueContainer.InnerHtml.AppendHtml(keyElement);
        keyValueContainer.InnerHtml.AppendHtml(valueElement);

        return keyValueContainer;
    }
}
