using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Smart.Design.Library.TagHelpers.Image;

namespace Smart.Design.Library.TagHelpers.Alert;

/// <inheritdoc cref="IAlertHtmlGenerator" />
public class AlertHtmlGenerator : IAlertHtmlGenerator
{
    private readonly IImageHtmlGenerator _imageHtmlGenerator;

    /// <summary>
    /// Generates an <see cref="AlertHtmlGenerator"/>.
    /// </summary>
    /// <param name="imageHtmlGenerator">A services that services HTML to render images.</param>
    public AlertHtmlGenerator(IImageHtmlGenerator imageHtmlGenerator)
    {
        _imageHtmlGenerator = imageHtmlGenerator;
    }

    /// <inheritdoc />
    public Task<TagBuilder> GenerateAlertAsync(string? title, string? message, AlertStyle alertStyle, Image.Image icon, bool isClosable, bool isLight)
    {
        return GenerateAlertAsync(title, new List<string>() { message ?? string.Empty }, alertStyle, icon, isClosable, isLight);
    }

    /// <inheritdoc />
    public async Task<TagBuilder> GenerateAlertAsync(
        string? title,
        List<string>? messages,
        AlertStyle alertStyle,
        Image.Image icon,
        bool isClosable,
        bool isLight)
    {
        // This <div> is the main container of the component.
        var alert = new TagBuilder("div");
        alert.AddCssClass("c-alert");

        // Add the css class accordingly to the specified style.
        alert.AddCssClass(AlertCssClassByStyle(alertStyle));

        if (isLight)
        {
            alert.AddCssClass("c-alert--light");
        }

        // First child of a Alert is an icon.
        var iconDiv = await GetIconAsync(alertStyle, icon);
        alert.InnerHtml.AppendHtml(iconDiv);

        // Next comes the body.
        var alertBody = new TagBuilder("div");
        alertBody.AddCssClass("c-alert__body");
        alert.InnerHtml.AppendHtml(alertBody);

        // The body has three nested <div>'s: alert__text > alert__message > content.
        var alertText = new TagBuilder("div");
        alertText.AddCssClass("c-alert__text");
        alertBody.InnerHtml.AppendHtml(alertText);

        // Append the title, it is optional.
        if (!string.IsNullOrWhiteSpace(title))
        {
            var htmlTitle = new TagBuilder("h4");
            htmlTitle.AddCssClass("c-h4");
            htmlTitle.InnerHtml.Append(title);
            alertText.InnerHtml.AppendHtml(htmlTitle);
        }

        var alertMessage = new TagBuilder("div");
        alertMessage.AddCssClass("c-alert__message");

        alertText.InnerHtml.AppendHtml(alertMessage);

        var alertMessageContent = new TagBuilder("div");
        alertMessageContent.AddCssClass("c-content");

        alertMessage.InnerHtml.AppendHtml(alertMessageContent);

        // The generated HTML differs if there are multiple messages.
        if (messages?.Count == 1)
        {
            AddSingleMessage(messages, alertMessageContent);
        }
        else if (messages?.Count > 1)
        {
            AddMultipleMessages(messages, alertMessageContent);
        }

        if (isClosable)
        {
            // The button that allows the end-user to close the alert is specific for the component.
            alert.InnerHtml.AppendHtml(await GenerateClosingButtonAsync());
            alert.Attributes["data-alert-closable"] = "data-alert-closable";
        }

        return alert;
    }

    private void AddSingleMessage(List<string> messages, TagBuilder alertMessageContent)
    {
        var messageDiv = new TagBuilder("div");
        messageDiv.InnerHtml.AppendHtml(messages[0]);
        alertMessageContent.InnerHtml.AppendHtml(messageDiv);
    }

    private void AddMultipleMessages(List<string> messages, TagBuilder alertMessageContent)
    {
        var messagesContainer = new TagBuilder("ul");
        foreach (var message in messages)
        {
            var htmlMessage = new TagBuilder("li");
            htmlMessage.InnerHtml.AppendHtml(message);
            messagesContainer.InnerHtml.AppendHtml(htmlMessage);
        }

        alertMessageContent.InnerHtml.AppendHtml(messagesContainer);
    }

    private string AlertCssClassByStyle(AlertStyle alertStyle)
    {
        return "c-alert--" + alertStyle.ToString().ToLowerInvariant();
    }

    private async Task<TagBuilder> GetIconAsync(AlertStyle alertStyle, Image.Image icon)
    {
        // If an icon is specified then it overrides default behaviour.
        if (icon is not Image.Image.None)
        {
            return await _imageHtmlGenerator.GenerateIconAsync(icon);
        }

        return alertStyle switch
        {
            AlertStyle.Default => await _imageHtmlGenerator.GenerateIconAsync(Image.Image.CircleInformation),
            AlertStyle.Error   => await _imageHtmlGenerator.GenerateIconAsync(Image.Image.CircleError),
            AlertStyle.Warning => await _imageHtmlGenerator.GenerateIconAsync(Image.Image.Warning),
            AlertStyle.Success => await _imageHtmlGenerator.GenerateIconAsync(Image.Image.CircleCheck),
            _                  =>
                throw new ArgumentOutOfRangeException(nameof(alertStyle), alertStyle, $"Unknown handling for {alertStyle}")
        };
    }

    private async Task<TagBuilder> GenerateClosingButtonAsync()
    {
        var button = new TagBuilder("button");
        button.AddCssClass("c-button-link c-button--borderless-muted c-button--icon");

        button.Attributes["type"] = "button";
        button.Attributes["data-alert-close"] = "data-alert-close";
        button.Attributes["aria-label"] = "Close alert";

        var span = new TagBuilder("span");
        span.AddCssClass("c-button__content");

        span.InnerHtml.AppendHtml(await _imageHtmlGenerator.GenerateIconAsync(Image.Image.Close));

        var accessible = new TagBuilder("div");
        accessible.AddCssClass("u-sr-accessible");
        accessible.InnerHtml.Append("Alert sluiten");

        span.InnerHtml.AppendHtml(accessible);

        button.InnerHtml.AppendHtml(span);

        return button;
    }
}
