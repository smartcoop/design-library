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
    public TagBuilder GenerateCardBody()
    {
        var cardBody = new TagBuilder("div");
        cardBody.AddCssClass("c-card__body");

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
    public TagBuilder GenerateCardActions()
    {
        var actionsContainer = new TagBuilder("div");
        actionsContainer.AddCssClass("c-card__actions");

        return actionsContainer;
    }

    /// <inheritdoc />
    public TagBuilder GenerateCardImage(string? source)
    {
        // An Smart design card is a <div> whose inner HTML is a <img>
        var imageContainer = new TagBuilder("div");
        imageContainer.AddCssClass("c-card__img");

        var image = new TagBuilder("img");
        image.Attributes["src"] = source;
        image.Attributes["alt"] = "";

        imageContainer.InnerHtml.AppendHtml(image);

        return imageContainer;
    }
}
