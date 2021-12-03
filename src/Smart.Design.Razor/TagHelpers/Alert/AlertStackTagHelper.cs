using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Razor.TagHelpers.Constants;
using Smart.Design.Razor.TagHelpers.Extensions;
using Smart.Design.Razor.TagHelpers.Icon;

namespace Smart.Design.Razor.TagHelpers.Alert;

[HtmlTargetElement(TagNames.AlertStack, TagStructure = TagStructure.NormalOrSelfClosing)]
public class AlertStackTagHelper : TagHelper
{
    private const string IconAttributeName = "icon";
    private const string MessageAttributeName = "message";

    private readonly IAlertStackHtmlGenerator _alertStackHtmlGenerator;

    [HtmlAttributeName(IconAttributeName)]
    public Image Icon { get; set; }

    [HtmlAttributeName(MessageAttributeName)]
    public string? Message { get; set; }

    public AlertStackTagHelper(IAlertStackHtmlGenerator alertStackHtmlGenerator)
    {
        _alertStackHtmlGenerator = alertStackHtmlGenerator;
    }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        var alertStack = await _alertStackHtmlGenerator.GenerateAlertStackAsync(Icon, Message);

        output.ClearAllAttributes();
        output.TagName = "div";
        output.TagMode = TagMode.StartTagAndEndTag;

        output.MergeAttributes(alertStack);
        output.Content.SetHtmlContent(alertStack);
    }
}
