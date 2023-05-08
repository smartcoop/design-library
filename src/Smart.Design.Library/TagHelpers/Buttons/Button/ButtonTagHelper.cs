using System;
using System.Collections.Generic;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Routing;
using Smart.Design.Library.TagHelpers.Base;
using Smart.Design.Library.TagHelpers.Constants;
using Smart.Design.Library.TagHelpers.Icon;
using Smart.Design.Library.TagHelpers.Image;

namespace Smart.Design.Library.TagHelpers.Buttons.Button;

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
    private const string FormAction = "formaction";

    private const string FormAttributeName = "form";
    private const string FragmentAttributeName = "asp-fragment";
    private const string PageAttributeName = "asp-page";
    private const string PageHandlerAttributeName = "asp-page-handler";
    private const string RouteAttributeName = "asp-route";
    private const string RouteValuesDictionaryName = "asp-all-route-data";
    private const string RouteValuesPrefix = "asp-route-";

    private IDictionary<string, string>? _routeValues;

    private readonly IImageHtmlGenerator _imageHtmlGenerator;
    private readonly IUrlHelperFactory _urlHelperFactory;

    /// <summary>
    /// Indicates if the button is disabled or not.
    /// </summary>
    [HtmlAttributeName("disabled")]
    public bool Disabled { get; set; }

    /// <summary>
    /// Defines a leading icon (i.e. before the button's label).
    /// </summary>
    [HtmlAttributeName("leading-icon")]
    public Image.Image LeadingIcon { get; set; }

    /// <summary>
    /// Defines a trailing icon (i.e. after the button's label).
    /// </summary>
    [HtmlAttributeName("trailing-icon")]
    public Image.Image TrailingIcon { get; set; }

    /// <summary>
    /// The label of the button.
    /// </summary>
    [HtmlAttributeName("label")]
    public string? Label { get; set; }

    /// <summary>
    /// Type attribute of the button.
    /// Default is <see cref="ButtonType.Button"/>.
    /// </summary>
    [HtmlAttributeName("button-type")]
    public ButtonType Type { get; set; } = ButtonType.Button;

    /// <summary>
    /// Style of the button.
    /// See <see cref="ButtonStyle"/> for possible values.
    /// </summary>
    [HtmlAttributeName("button-style")]
    public ButtonStyle Style { get; set; } = ButtonStyle.Primary;

    /// <summary>
    /// Determines if the button is a full width block button. The default state is <see langword="false"/>.
    /// </summary>
    [HtmlAttributeName("is-block")]
    public bool IsBlock { get; set; }

    /// <summary>
    /// Determines if the button is an icon only. The default state is <see langword="false"/>.
    /// </summary>
    [HtmlAttributeName("icon-only")]
    public bool IconOnly { get; set; }

    /// <summary>
    /// The &lt;form&gt; element to associate the button with (its form owner). The value of this attribute must be the id of a &lt;form&gt; in the same document.
    /// </summary>
    [HtmlAttributeName(FormAttributeName)]
    public string? Form { get; set; }

    /// <summary>
    /// Gets or sets the URL fragment.
    /// </summary>
    [HtmlAttributeName(FragmentAttributeName)]
    public string? Fragment { get; set; }

    /// <summary>
    /// Attribute helper to specify routes such as asp-route-id.
    /// </summary>
    /// <remarks>
    /// This attributes doesn't do anything as it is used only to help developer with autocomplete.
    /// </remarks>
    [HtmlAttributeName(RouteAttributeName)]
    public string? Route { get; set; }

    /// <summary>
    /// Additional parameters for the route.
    /// </summary>
    [HtmlAttributeName(RouteValuesDictionaryName, DictionaryAttributePrefix = RouteValuesPrefix)]
    public IDictionary<string, string> RouteValues
    {
        get => _routeValues ??= new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        set => _routeValues = value;
    }

    /// <summary>
    /// The name of the page.
    /// </summary>
    [HtmlAttributeName(PageAttributeName)]
    public string? Page { get; set; }

    /// <summary>
    /// The name of the page handler.
    /// </summary>
    [HtmlAttributeName(PageHandlerAttributeName)]
    public string? PageHandler { get; set; }

    /// <summary>
    /// Creates a new <see cref="ButtonTagHelper"/>.
    /// </summary>
    /// <param name="imageHtmlGenerator">The <see cref="IImageHtmlGenerator"/>.</param>
    /// <param name="urlHelperFactory">The <see cref="IUrlHelperFactory"/>.</param>
    public ButtonTagHelper(IImageHtmlGenerator imageHtmlGenerator, IUrlHelperFactory urlHelperFactory)
    {
        _imageHtmlGenerator = imageHtmlGenerator;
        _urlHelperFactory = urlHelperFactory;
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

        if (!string.IsNullOrWhiteSpace(Id))
        {
            output.Attributes.Add("id", Id);
        }

        if (Disabled)
        {
            output.Attributes.Add("disabled", "disabled");
        }

        if (IsBlock)
        {
            output.AddClass("c-button--block", HtmlEncoder.Default);
        }

        // The content of a smart button is actually a span.
        var buttonContent = new TagBuilder("span");
        buttonContent.AddCssClass("c-button__content");

        // If a leading icon is specified it needs to be added as the first child of the container.
        if (LeadingIcon != Image.Image.None)
        {
            var leadingIcon = await _imageHtmlGenerator.GenerateIconAsync(LeadingIcon);
            buttonContent.InnerHtml.AppendHtml(leadingIcon);
        }

        // If the attribute icon-only is not set to true, we expect to put the label inside a span.
        if (!IconOnly)
        {
            var spanButtonLabelTagBuilder = new TagBuilder("span");
            spanButtonLabelTagBuilder.AddCssClass("c-button__label");
            if (Label is not null)
            {
                spanButtonLabelTagBuilder.InnerHtml.SetContent(Label);
            }

            buttonContent.InnerHtml.AppendHtml(spanButtonLabelTagBuilder);
        }

        // We cannot put a a trailing icon if IconOnly attribute is set to true.
        // Obviously a trailing icon needs to be set.
        if (TrailingIcon != Image.Image.None && !IconOnly)
        {
            var trailingIcon = await _imageHtmlGenerator.GenerateIconAsync(TrailingIcon);
            buttonContent.InnerHtml.AppendHtml(trailingIcon);
        }

        // When creating a icon only icon last child of the container needs to a class with `u-sr-accessible` attribute.
        // See Smart design documentation for more insight.
        if (IconOnly)
        {
            output.AddClass("c-button--icon", HtmlEncoder.Default);

            var iconOnlyDiv = new TagBuilder("div");
            iconOnlyDiv.AddCssClass("u-sr-accessible");
            if (Label is not null)
            {
                iconOnlyDiv.InnerHtml.SetContent(Label);
            }
        }

        if (!string.IsNullOrWhiteSpace(Form))
        {
            output.Attributes.Add(FormAttributeName, Form);
        }

        // If there is any custom handler specified we need to add its route to to the attribute formaction.
        SetFormAction(output);

        output.Content.SetHtmlContent(buttonContent);
    }

    private string ComputeButtonStyleCssClass()
    {
        return Style switch
        {
            ButtonStyle.Primary         => "c-button--primary",
            ButtonStyle.Secondary       => "c-button--secondary",
            ButtonStyle.Borderless      => "c-button--borderless",
            ButtonStyle.Danger          => "c-button--danger",
            ButtonStyle.DangerSecondary => "c-button--danger-secondary",
            ButtonStyle.Warning => "c-button--warning",
            ButtonStyle.Highlight => "c-button--highlights",
            _=> throw new NotImplementedException($"Style undefined for style {Style}")
        };
    }

    private void SetFormAction(TagHelperOutput output)
    {
        // Checks if a custom handler has been set.
        var hasCustomPageLink = Page != null || PageHandler != null;
        if (!hasCustomPageLink)
        {
            return;
        }

        RouteValueDictionary? routeValues = null;
        if (RouteValues is {Count: > 0})
        {
            routeValues = new RouteValueDictionary(RouteValues);
        }

        var urlHelper = _urlHelperFactory.GetUrlHelper(ViewContext!);
        var url = urlHelper.Page(Page, PageHandler, routeValues, null, null, Fragment);
        output.Attributes.SetAttribute(FormAction, url);
    }
}
