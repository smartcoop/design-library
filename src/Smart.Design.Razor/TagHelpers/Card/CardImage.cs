using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Razor.TagHelpers.Extensions;

namespace Smart.Design.Razor.TagHelpers.Card;

/// <summary>
/// <see cref="ITagHelper"/> implementation of the image that can be contained inside a Smart Design card.
/// See <see cref="CardTagHelper" /> for more information.
/// </summary>
[HtmlTargetElement(TagNames.CardImage, ParentTag = TagNames.Card)]
public class CardImageTagHelper : TagHelper
{
    private const string SourceAttributeName = "surce";

    private readonly ICardHtmlGenerator _cardHtmlGenerator;

    /// <summary>
    /// URI to the location of the Image to display.
    /// </summary>
    [HtmlAttributeName(SourceAttributeName)]
    public string? Source { get ; set ; }

    public CardImageTagHelper(ICardHtmlGenerator cardHtmlGenerator)
    {
        _cardHtmlGenerator = cardHtmlGenerator;
    }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        var cardImage = _cardHtmlGenerator.GenerateCardImage(Source);

        output.TagName = cardImage.TagName;
        output.TagMode = TagMode.StartTagAndEndTag;

        output.ClearAndMergeAttributes(cardImage);

        output.Content.SetHtmlContent(cardImage.InnerHtml);
    }
}
