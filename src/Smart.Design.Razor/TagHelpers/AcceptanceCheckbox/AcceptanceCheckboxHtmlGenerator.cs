using System;
using System.Globalization;
using System.Threading;
using Microsoft.AspNetCore.Mvc.Rendering;
using Smart.Design.Razor.Resources;
using Smart.Design.Razor.TagHelpers.Icon;

namespace Smart.Design.Razor.TagHelpers.AcceptanceCheckbox;
/// <inheritdoc/>
public class AcceptanceCheckboxHtmlGenerator : IAcceptanceCheckboxHtmlGenerator
{
    private readonly IIconHtmlGenerator _iconHtmlGenerator;

    public AcceptanceCheckboxHtmlGenerator(IIconHtmlGenerator iconHtmlGenerator)
    {
        _iconHtmlGenerator = iconHtmlGenerator;
    }

    /// <inheritdoc/>
    public TagBuilder GenerateAcceptanceCheckbox(string label, AcceptanceCheckboxStyle style, string currentLanguage)
    {
        if (!string.IsNullOrEmpty(currentLanguage))
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(currentLanguage);
        }
        var iconAndLabel = style switch
        {
            AcceptanceCheckboxStyle.Danger => new Tuple<Image, string>(Image.Close, Translations.NotValidate),
            AcceptanceCheckboxStyle.Warning => new Tuple<Image, string>(Image.Check, Translations.Validate),
            _ => new Tuple<Image, string>(Image.Check, Translations.Validate)
        };
        var divFlex = new TagBuilder("div");
        divFlex.AddCssClass("u-flex u-flex--twins o-flex--vertical-center");

        var div1 = new TagBuilder("div");
        var divCheckboxGroup = new TagBuilder("div");
        divCheckboxGroup.AddCssClass("c-checkbox-group");

        var divCheckbox = new TagBuilder("div");
        divCheckbox.AddCssClass("c-checkbox");

        var labelTag = new TagBuilder("label");
        var input = new TagBuilder("input");
        input.Attributes["type"] = "checkbox";
        input.Attributes["data-toggle"] = "disabled";
        input.Attributes["data-switch-target"] = "c-button--warning";
        input.InnerHtml.Append(label);

        labelTag.InnerHtml.AppendHtml(input);
        divCheckbox.InnerHtml.AppendHtml(labelTag);
        divCheckboxGroup.InnerHtml.AppendHtml(divCheckbox);
        div1.InnerHtml.AppendHtml(divCheckboxGroup);

        var div2 = new TagBuilder("div");
        var button = new TagBuilder("button");
        button.AddCssClass($"c-button c-button--{style.ToString().ToLowerInvariant()}");
        button.Attributes["type"] = "button";
        button.Attributes["disabled"] = "";

        var span = new TagBuilder("span");
        span.AddCssClass("c - button__content");
        var icon = _iconHtmlGenerator.GenerateIcon(iconAndLabel.Item1);
        var spanLabel = new TagBuilder("span");
        spanLabel.AddCssClass("c-button__label");
        spanLabel.InnerHtml.Append(iconAndLabel.Item2);

        span.InnerHtml.AppendHtml(icon);
        span.InnerHtml.AppendHtml(spanLabel);
        button.InnerHtml.AppendHtml(span);
        div2.InnerHtml.AppendHtml(button);
        divFlex.InnerHtml.AppendHtml(div1);
        divFlex.InnerHtml.AppendHtml(div2);

        return divFlex;
    }
}
