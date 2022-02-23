using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Razor.TagHelpers.Extensions;

namespace Smart.Design.Razor.TagHelpers.Card;

/// <summary>
/// <see cref="ITagHelper" /> implementation of the Smart Design card body.
/// Documentation is available <see href="https://design.smart.coop/development/docs/c-card.html">here</see>.
/// </summary>
[HtmlTargetElement(TagNames.CardBody, ParentTag = TagNames.Card)]
public class CardBodyTagHelper : TagHelper
{
    private readonly ICardHtmlGenerator _cardHtmlGenerator;

    public CardBodyTagHelper(ICardHtmlGenerator cardHtmlGenerator)
    {
        _cardHtmlGenerator = cardHtmlGenerator;
    }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        var body = _cardHtmlGenerator.GenerateCardBody();

        output.TagName = body.TagName;
        output.TagMode = TagMode.StartTagAndEndTag;

        output.ClearAndMergeAttributes(body);
    }
}
