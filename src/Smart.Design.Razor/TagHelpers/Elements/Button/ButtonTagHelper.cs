using System;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Razor.TagHelpers.Base;
using Smart.Design.Razor.TagHelpers.Constants;
using Smart.Design.Razor.TagHelpers.Icon;

namespace Smart.Design.Razor.TagHelpers.Elements.Button;

/// <summary>
/// <see cref="ITagHelper" /> implementation of the Smart design button with
/// <c>disabled</c>,
/// <c>leading-icon</c>,
/// <c>trailing-icon</c>,
/// <c>label</c>,
/// <c>button-type</c>,
/// <c>button-style</c>,
/// <c>is-block</c>,
/// <c>icon-only</c>,
/// attributes.
/// Documentation is available <see href="https://design.smart.coop/development/docs/c-button.html">here</see>.
/// <para>
///     <term>Remark </term>
///      Inherits from <see cref="BaseTagHelper"/>
/// </para>
/// </summary>
[HtmlTargetElement(TagNames.ButtonTagName, TagStructure = TagStructure.NormalOrSelfClosing)]
public class ButtonTagHelper : BaseTagHelper
{
    private readonly IIconHtmlGenerator _iconHtmlGenerator;

    [HtmlAttributeName("disabled")]
    public bool Disabled { get; set; }

    [HtmlAttributeName("leading-icon")]
    public Image LeadingIcon { get; set; }

    [HtmlAttributeName("trailing-icon")]
    public Image TrailingIcon { get; set; }

    [HtmlAttributeName("label")]
    public string? Label { get; set; }

    [HtmlAttributeName("button-type")]
    public ButtonType Type { get; set; } = ButtonType.Button;

    [HtmlAttributeName("button-style")]
    public ButtonStyle Style { get; set; } = ButtonStyle.Primary;

    [HtmlAttributeName("is-block")]
    public bool IsBlock { get; set; }

    [HtmlAttributeName("icon-only")]
    public bool IconOnly { get; set; }

    public ButtonTagHelper(IIconHtmlGenerator iconHtmlGenerator)
    {
        _iconHtmlGenerator = iconHtmlGenerator;
    }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        output.Attributes.Clear();
        output.TagName = "button";
        output.TagMode = TagMode.StartTagAndEndTag;

        var styleCssClass = ComputeButtonStyleCssClass();
        output.AddClass("c-button", HtmlEncoder.Default);
        output.AddClass(styleCssClass, HtmlEncoder.Default);
        output.Attributes.SetAttribute("type", Type.ToString().ToLowerInvariant());

        if (Disabled)
        {
            output.Attributes.Add("disabled", "disabled");
        }

        if (IsBlock)
        {
            output.AddClass("c-button--block", HtmlEncoder.Default);
        }

        var buttonContent = new TagBuilder("span");
        buttonContent.AddCssClass("c-button__content");

        // If a leading icon is specified it needs to be added as the first child of the container.
        if (LeadingIcon != Image.None)
        {
            var leadingIcon = await _iconHtmlGenerator.GenerateIconAsync(LeadingIcon);
            buttonContent.InnerHtml.AppendHtml(leadingIcon);
        }

        // If the attribute icon-only is not set to true, we expect to put a span.
        if (!IconOnly)
        {
            var spanButtonLabelTagBuilder = new TagBuilder("span");
            spanButtonLabelTagBuilder.AddCssClass("c-button__label");
            if (Label is not null)
                spanButtonLabelTagBuilder.InnerHtml.SetContent(Label);

            buttonContent.InnerHtml.AppendHtml(spanButtonLabelTagBuilder);
        }

        // We cannot put a a trailing icon if IconOnly attribute is set to true.
        // Obviously a trailing icon needs to be set.
        if (TrailingIcon != Image.None && !IconOnly)
        {
            var trailingIcon = await _iconHtmlGenerator.GenerateIconAsync(TrailingIcon);
            buttonContent.InnerHtml.AppendHtml(trailingIcon);
        }

        // When creating a icon only icon last child of the container needs to a class with `u-sr-accessible` attribute.
        // See Smart design documentation for more insight.
        if (IconOnly)
        {
            var iconOnlyDiv = new TagBuilder("div");
            iconOnlyDiv.AddCssClass("u-sr-accessible");
            if (Label is not null)
                iconOnlyDiv.InnerHtml.SetContent(Label);
        }

        output.Content.SetHtmlContent(buttonContent);
    }

    private string ComputeButtonStyleCssClass()
    {
        return Style switch
        {
            ButtonStyle.Primary => "c-button--primary",
            ButtonStyle.Secondary => "c-button--secondary",
            ButtonStyle.Borderless => "c-button--borderless",
            ButtonStyle.Danger => "c-button--danger",
            ButtonStyle.DangerSecondary => "c-button--danger-secondary",
            _ => throw new NotImplementedException($"Style undefined for style {Style}")
        };
    }
}
