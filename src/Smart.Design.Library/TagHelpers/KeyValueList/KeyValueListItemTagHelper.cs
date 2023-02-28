using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Library.TagHelpers.Extensions;

namespace Smart.Design.Library.TagHelpers.KeyValueList;

/// <summary>
/// <see cref="ITagHelper" /> implementation of the Smart Design Key Value List Item.
/// Documentation can be seen <see href="https://design.smart.coop/development/docs/c-key-value.html">here</see>.
/// </summary>
[HtmlTargetElement(TagNames.KeyValueListItem)]
public class KeyValueListItemTagHelper : TagHelper
{
    private const string LabelAttributeName = "label";
    private const string ValueAttributeName = "value";

    private readonly IKeyValueListHtmlGenerator _keyValueListHtmlGenerator;

    [HtmlAttributeName(LabelAttributeName)]
    public string? Label { get; set; }

    [HtmlAttributeName(ValueAttributeName)]
    public string? Value { get; set; }

    public KeyValueListItemTagHelper(IKeyValueListHtmlGenerator keyValueListHtmlGenerator)
    {
        _keyValueListHtmlGenerator = keyValueListHtmlGenerator;
    }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        var keyValueListItem = _keyValueListHtmlGenerator.GenerateKeyValueItem(Label, Value);

        output.TagMode = TagMode.StartTagAndEndTag;
        output.TagName = keyValueListItem.TagName;
        output.ClearAndMergeAttributes(keyValueListItem);

        output.Content.SetHtmlContent(keyValueListItem.InnerHtml);
    }
}
