using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Library.TagHelpers.Extensions;

namespace Smart.Design.Library.TagHelpers.Card;

/// <summary>
/// <see cref="ITagHelper"/> implementation of the Smart Design Card Title.
/// </summary>
[HtmlTargetElement(TagNames.CardTitle, TagStructure = TagStructure.NormalOrSelfClosing)]
public class CardTitleTagHelper : TagHelper
{
    private const string TextAttributeName = "text";

    private readonly ICardHtmlGenerator _cardHtmlGenerator;

    /// <summary>
    /// Text to display inside the Smart Card Title.
    /// </summary>
    [HtmlAttributeName(TextAttributeName)]
    public string? Text { get; set; }

    /// <summary>
    /// Creates a new <see cref="CardTitleTagHelper"/>.
    /// </summary>
    /// <param name="cardHtmlGenerator">The <see cref="ICardHtmlGenerator"/>.</param>
    public CardTitleTagHelper(ICardHtmlGenerator cardHtmlGenerator)
    {
        _cardHtmlGenerator = cardHtmlGenerator;
    }

    /// <inheritdoc />
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        var cardTitle = _cardHtmlGenerator.GenerateCardTitle(Text);

        output.ClearAndMergeAttributes(cardTitle);

        output.TagName = cardTitle.TagName;
        output.TagMode = TagMode.StartTagAndEndTag;

        output.Content.SetHtmlContent(cardTitle.InnerHtml);
    }
}
