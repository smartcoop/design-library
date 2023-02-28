using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Library.TagHelpers.Extensions;

namespace Smart.Design.Library.TagHelpers.KeyValueList;

/// <summary>
/// <see cref="ITagHelper" /> implementation of the Smart Design Key Value List.
/// Documentation can be seen <see href="https://design.smart.coop/development/docs/c-key-value.html">here</see>.
/// </summary>
[HtmlTargetElement(TagNames.KeyValueList)]
public class KeyValueListTagHelper : TagHelper
{
    private readonly IKeyValueListHtmlGenerator _keyValueListHtmlGenerator;

    public KeyValueListTagHelper(IKeyValueListHtmlGenerator keyValueListHtmlGenerator)
    {
        _keyValueListHtmlGenerator = keyValueListHtmlGenerator;
    }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        var keyValueList = _keyValueListHtmlGenerator.GenerateKeyValueList();

        output.TagName = keyValueList.TagName;
        output.TagMode = TagMode.StartTagAndEndTag;
        output.ClearAndMergeAttributes(keyValueList);
    }
}
