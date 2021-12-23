using Microsoft.AspNetCore.Mvc.Rendering;

namespace Smart.Design.Razor.TagHelpers.Card;

/// <summary>
/// Generates HTML
/// </summary>
public class CardHtmlGenerator : ICardHtmlGenerator
{
    /// <inheritdoc />
    public TagBuilder GenerateCard()
    {
        var card = new TagBuilder("div");
        card.AddCssClass("c-card");

        return card;
    }

    /// <inheritdoc />
    public TagBuilder GenerateCardBody(bool containsActions)
    {
        var cardBody = new TagBuilder("div");
        cardBody.AddCssClass("c-card__body");
        if (containsActions)
        {
            cardBody.AddCssClass("c-card__body--with-actions");
        }

        return cardBody;
    }

    /// <inheritdoc />
    public TagBuilder GenerateCardTitle(string? text)
    {
        var cardTitle = new TagBuilder("h4");
        cardTitle.AddCssClass("c-card__title");
        if (!string.IsNullOrWhiteSpace(text))
        {
            cardTitle.InnerHtml.Append(text);
        }

        return cardTitle;
    }

    /// <inheritdoc />
    public TagBuilder GenerateCarBodyAction()
    {
        var content = new TagBuilder("div");
        content.AddCssClass("c-card__actions");

        return content;
    }

    public TagBuilder GenerateCardBodyContent()
    {
        var content = new TagBuilder("div");
        content.AddCssClass("c-card__content");

        return content;
    }
}
