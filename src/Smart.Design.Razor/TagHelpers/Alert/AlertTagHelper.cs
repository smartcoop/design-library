using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Razor.TagHelpers.Extensions;
using Smart.Design.Razor.TagHelpers.Icon;

namespace Smart.Design.Razor.TagHelpers.Alert;

/// <summary>
/// <see cref="ITagHelper" /> implementation of the Smart Design Alert.
/// The documentation can be found <see href="https://design.smart.coop/development/docs/c-alert.html">here</see>.
/// </summary>
[HtmlTargetElement(TagNames.Alert)]
public class AlertTagHelper : TagHelper
{
    private const string AlertStyleAttributeName = "style";
    private const string IconAttributeName       = "icon";
    private const string IsLightAttributeName    = "is-light";
    private const string IsClosableAttributeName = "is-closable";
    private const string MessageAttributeName    = "message";
    private const string MessagesAttributeName   = "messages";
    private const string TitleAttributeName      = "title";

    private readonly IAlertHtmlGenerator _alertHtmlGenerator;

    [HtmlAttributeName(AlertStyleAttributeName)]
    public AlertStyle AlertStyle { get; set; }

    [HtmlAttributeName(IconAttributeName)]
    public Image Icon { get; set; }

    [HtmlAttributeName(IsLightAttributeName)]
    public bool IsLight { get; set; }

    [HtmlAttributeName(IsClosableAttributeName)]
    public bool IsClosable { get; set; }

    [HtmlAttributeName(MessageAttributeName)]
    public string? Message { get; set; }

    [HtmlAttributeName(MessagesAttributeName)]
    public List<string>? Messages { get; set; }

    [HtmlAttributeName(TitleAttributeName)]
    public string? Title { get; set; }

    public AlertTagHelper(IAlertHtmlGenerator alertHtmlGenerator)
    {
        _alertHtmlGenerator = alertHtmlGenerator;
    }

    public override void Init(TagHelperContext context)
    {
        if (Message is not null && Messages is not null)
        {
            throw new InvalidOperationException($"Property {nameof(Message)} and {nameof(Messages)} cannot be set at the same time");
        }
    }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        TagBuilder alert;
        if (Message is not null)
            alert = await _alertHtmlGenerator.GenerateAlertAsync(Title, Message, AlertStyle, Icon, IsClosable, IsLight);
        else
        {
            alert = await _alertHtmlGenerator.GenerateAlertAsync(Title, Messages, AlertStyle, Icon, IsClosable, IsLight);
        }

        output.TagName = alert.TagName;
        output.ClearAndMergeAttributes(alert);
        output.Content.SetHtmlContent(alert.InnerHtml);
    }
}
