using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Razor.TagHelpers.Extensions;

namespace Smart.Design.Razor.TagHelpers.Card;

/// <summary>
/// <see cref="ITagHelper" /> implementation of the Smart Design card content.
/// A Smart Design card content is a direct child of a Smart Design card body.
/// It contains the main elements of the card.
/// </summary>
[HtmlTargetElement(TagNames.CardContent, ParentTag = TagNames.CardBody)]
public class CardContentTagHelper : TagHelper
{
    private readonly ICardHtmlGenerator _cardHtmlGenerator;

    public CardContentTagHelper(ICardHtmlGenerator cardHtmlGenerator)
    {
        _cardHtmlGenerator = cardHtmlGenerator;
    }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        var content = _cardHtmlGenerator.GenerateCardBodyContent();

        output.TagName = content.TagName;
        output.TagMode = TagMode.StartTagAndEndTag;

        output.ClearAndMergeAttributes(content);
    }
}
