using Microsoft.AspNetCore.Mvc.Rendering;

namespace Smart.Design.Razor.TagHelpers.Card;

/// <summary>
/// Generates necessary HTML to render Smart Design Cards.
/// </summary>
public interface ICardHtmlGenerator
{
    /// <summary>
    /// Generates a Smart Design card.
    /// </summary>
    /// <returns>An instance of a Smart Design card.</returns>
    TagBuilder GenerateCard();

    /// <summary>
    /// Generates the body of the Smart design card.
    /// </summary>
    /// <returns>An instance of the Smart Design card body.</returns>
    TagBuilder GenerateCardBody();

    /// <summary>
    /// Generates the title of the Smart Design card.
    /// </summary>
    /// <param name="text">The title.</param>
    /// <returns>An instance of the Smart Design title.</returns>
    TagBuilder GenerateCardTitle(string? text);

    /// <summary>
    /// Generates the HTML of the Smart Design actions.
    /// The Smart Design actions is a container holding elements that produces an action (i.e. buttons, anchors, etc.).
    /// </summary>
    /// <returns>An instance of the Smart Design card's actions.</returns>
    TagBuilder GenerateCardActions();

    /// <summary>
    /// Generates the html of a &lt;img&gt; for the Smart Design card.
    /// </summary>
    /// <param name="source">The uri of the file.</param>
    /// <returns>An instance of the Smart Card's image.</returns>
    TagBuilder GenerateCardImage(string? source);
}
