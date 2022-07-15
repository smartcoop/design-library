using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Razor.TagHelpers.Extensions;

namespace Smart.Design.Razor.TagHelpers.Card;

/// <summary>
/// <see cref="ITagHelper"/> implementation of the Smart Design card.
/// Documentation is available <see href="https://design.smart.coop/development/docs/c-card.html">here</see>.
/// </summary>
[HtmlTargetElement(TagNames.Card)]
public class CardTagHelper : TagHelper
{
    private readonly ICardHtmlGenerator _cardHtmlGenerator;

    /// <summary>
    /// Creates a new <see cref="CardTagHelper"/>.
    /// </summary>
    /// <param name="cardHtmlGenerator">The <see cref="ICardHtmlGenerator"/>.</param>
    public CardTagHelper(ICardHtmlGenerator cardHtmlGenerator)
    {
        _cardHtmlGenerator = cardHtmlGenerator;
    }

    /// <inheritdoc />
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        var card = _cardHtmlGenerator.GenerateCard();

        output.TagName = card.TagName;
        output.TagMode = TagMode.StartTagAndEndTag;

        output.ClearAndMergeAttributes(card);
    }
}
