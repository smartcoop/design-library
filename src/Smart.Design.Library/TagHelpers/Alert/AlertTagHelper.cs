using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Library.TagHelpers.Extensions;
using Smart.Design.Library.TagHelpers.Icon;

namespace Smart.Design.Library.TagHelpers.Alert;

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

    /// <summary>
    /// Style of Alert: Default, War
    /// </summary>
    [HtmlAttributeName(AlertStyleAttributeName)]
    public AlertStyle AlertStyle { get; set; }

    /// <summary>
    /// Icon to override the default one.
    /// </summary>
    [HtmlAttributeName(IconAttributeName)]
    public Image Icon { get; set; }

    /// <summary>
    /// Determines if the alert has a lighter, more neutral skin. The default state is <see langword="false" />.
    /// </summary>
    [HtmlAttributeName(IsLightAttributeName)]
    public bool IsLight { get; set; }

    /// <summary>
    /// Determines if the Alert can be closed. The default state is <see langword="false" />.
    /// </summary>
    [HtmlAttributeName(IsClosableAttributeName)]
    public bool IsClosable { get; set; }

    /// <summary>
    /// Single message displayed inside the Alert.
    /// </summary>
    [HtmlAttributeName(MessageAttributeName)]
    public string? Message { get; set; }

    /// <summary>
    /// Multiple messages displayed inside the Alert. (Bullet point list).
    /// </summary>
    [HtmlAttributeName(MessagesAttributeName)]
    public List<string>? Messages { get; set; }

    /// <summary>
    /// Title of the Alert.
    /// </summary>
    [HtmlAttributeName(TitleAttributeName)]
    public string? Title { get; set; }

    /// <summary>
    /// Creates a new <see cref="AlertTagHelper" />.
    /// </summary>
    /// <param name="alertHtmlGenerator">The <see cref="IAlertHtmlGenerator" />.</param>
    public AlertTagHelper(IAlertHtmlGenerator alertHtmlGenerator)
    {
        _alertHtmlGenerator = alertHtmlGenerator;
    }

    /// <inheritdoc />
    public override void Init(TagHelperContext context)
    {
        if (Message is not null && Messages is not null)
        {
            throw new InvalidOperationException($"Property {nameof(Message)} and {nameof(Messages)} cannot be set at the same time");
        }
    }

    /// <inheritdoc />
    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        TagBuilder alert;
        if (Message is not null)
        {
            alert = await _alertHtmlGenerator.GenerateAlertAsync(Title, Message, AlertStyle, Icon, IsClosable, IsLight);
        }
        else
        {
            alert = await _alertHtmlGenerator.GenerateAlertAsync(Title, Messages, AlertStyle, Icon, IsClosable, IsLight);
        }

        output.TagName = alert.TagName;
        output.ClearAndMergeAttributes(alert);
        output.Content.SetHtmlContent(alert.InnerHtml);
    }
}
