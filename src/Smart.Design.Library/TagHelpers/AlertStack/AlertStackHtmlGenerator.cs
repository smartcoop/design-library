using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Smart.Design.Library.TagHelpers.Image;

namespace Smart.Design.Library.TagHelpers.AlertStack;

public class AlertStackHtmlGenerator : IAlertStackHtmlGenerator
{
    private readonly IImageHtmlGenerator _imageHtmlGenerator;

    public AlertStackHtmlGenerator(IImageHtmlGenerator imageHtmlGenerator)
    {
        _imageHtmlGenerator = imageHtmlGenerator;
    }

    public async Task<TagBuilder> GenerateAlertStackAsync(Image.Image icon, string? message)
    {
        var mainDiv = new TagBuilder("div");
        mainDiv.Attributes.Add("style", "position: relative; width: 100%; height: 100%; min-height: 220px;");

        var ul = new TagBuilder("ul");
        ul.AddCssClass("c-alert-stack");
        ul.Attributes["position"] = "absolute";

        var li = new TagBuilder("li");
        li.AddCssClass("c-alert c-alert--dark");

        var trailingIcon = await _imageHtmlGenerator.GenerateIconAsync(icon).ConfigureAwait(false);

        var messageContainer = new TagBuilder("div");
        messageContainer.AddCssClass("c-alert__body");
        var messageParagraph = new TagBuilder("p");
        messageParagraph.InnerHtml.SetContent(message!);
        messageContainer.InnerHtml.SetHtmlContent(messageParagraph);

        li.InnerHtml.AppendHtml(trailingIcon);
        li.InnerHtml.AppendHtml(messageContainer);

        ul.InnerHtml.AppendHtml(li);

        mainDiv.InnerHtml.AppendHtml(ul);

        return mainDiv;
    }
}
