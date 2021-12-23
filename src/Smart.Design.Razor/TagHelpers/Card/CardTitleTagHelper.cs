using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Razor.TagHelpers.Extensions;

namespace Smart.Design.Razor.TagHelpers.Card;

[HtmlTargetElement(TagNames.CardTitle, TagStructure = TagStructure.NormalOrSelfClosing)]
public class CardTitleTagHelper : TagHelper
{
    private const string TextAttributeName = "text";

    private readonly ICardHtmlGenerator _cardHtmlGenerator;

    [HtmlAttributeName(TextAttributeName)]
    public string? Text { get; set; }

    public CardTitleTagHelper(ICardHtmlGenerator cardHtmlGenerator)
    {
        _cardHtmlGenerator = cardHtmlGenerator;
    }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        var cardTitle = _cardHtmlGenerator.GenerateCardTitle(Text);

        output.ClearAndMergeAttributes(cardTitle);

        output.TagName = cardTitle.TagName;
        output.TagMode = TagMode.StartTagAndEndTag;

        output.Content.SetHtmlContent(cardTitle.InnerHtml);
    }
}
