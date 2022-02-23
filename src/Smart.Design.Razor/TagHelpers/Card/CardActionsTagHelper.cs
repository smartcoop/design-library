using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Razor.TagHelpers.Extensions;

namespace Smart.Design.Razor.TagHelpers.Card;

/// <summary>
/// <see cref="ITagHelper" /> implementation of a Smart Design card actions.
/// A Smart Design card actions contains a set of action items, such as buttons.
/// This containers must be a direct child of a <see cref="CardBodyTagHelper" />
/// </summary>
[HtmlTargetElement(TagNames.CardAction, ParentTag = TagNames.Card)]
public class CardActionsTagHelper : TagHelper
{
    private readonly ICardHtmlGenerator _cardHtmlGenerator;

    public CardActionsTagHelper(ICardHtmlGenerator cardHtmlGenerator)
    {
        _cardHtmlGenerator = cardHtmlGenerator;
    }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        var action = _cardHtmlGenerator.GenerateCardActions();

        output.TagName = action.TagName;
        output.TagMode = TagMode.StartTagAndEndTag;

        output.ClearAndMergeAttributes(action);
    }
}
