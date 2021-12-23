using Microsoft.AspNetCore.Mvc.Rendering;

namespace Smart.Design.Razor.TagHelpers.Card;

public interface ICardHtmlGenerator
{
    /// <summary>
    /// Generates a Smart Design card.
    /// </summary>
    /// <returns>An instance of a Smart Design card.</returns>
    TagBuilder GenerateCard();

    /// <summary>
    /// Generates body of the Smart design card.
    /// </summary>
    /// <param name="containsActions">Determines if the body has one or multiple action items. Those can be clickable items.</param>
    /// <returns>An instance of the Smart Design card body.</returns>
    TagBuilder GenerateCardBody(bool containsActions);

    /// <summary>
    /// Generates title of the Smart Design card.
    /// </summary>
    /// <param name="text">The title.</param>
    /// <returns>An instance of the Smart Design title.</returns>
    TagBuilder GenerateCardTitle(string? text);

    /// <summary>
    /// Generates a &lt;div&gt; whose purpose is containing action items inside a Smart Design card body.
    /// An action item can be typically a button.
    /// </summary>
    /// <returns>A instance of a action items container.</returns>
    TagBuilder GenerateCarBodyAction();

    /// <summary>
    /// Generates a &lt;div&gt; whose purpose is containing primary content of a Smart Design card.
    /// </summary>
    /// <returns>An instance of the main content of a Smart design card body.</returns>
    TagBuilder GenerateCardBodyContent();
}
