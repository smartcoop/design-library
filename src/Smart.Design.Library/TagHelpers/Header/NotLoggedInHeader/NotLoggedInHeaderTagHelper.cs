using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Library.TagHelpers.Constants;

namespace Smart.Design.Library.TagHelpers.Header.NotLoggedInHeader;

[HtmlTargetElement(TagNames.NotLoggedInHeaderTagName)]
public class NotLoggedInHeaderTagHelper : TagHelper
{
    private readonly INotLoggedInHeaderHtmlGenerator _notLoggedInHeaderHtmlGenerator;
    public string HomePageUrl { get; set; }

    public Dictionary<string, string> LanguagesAndLinks { get; set; }

    public string? TargetLanguage { get; set; }

    public List<StepperItem>? StepperItems { get; set; }

    public NotLoggedInHeaderTagHelper(INotLoggedInHeaderHtmlGenerator notLoggedInHeaderHtmlGenerator)
    {
        _notLoggedInHeaderHtmlGenerator = notLoggedInHeaderHtmlGenerator;
    }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        if (!LanguagesAndLinks.Any())
        {
            throw new ArgumentException($"{nameof(LanguagesAndLinks)} cannot be empty");
        }

        var header = new TagBuilder("header");
        header.AddCssClass("o-container-vertical c-navbar c-navbar--white c-navbar--entry");
        header.InnerHtml.SetHtmlContent(_notLoggedInHeaderHtmlGenerator.GenerateNotLoggedInHeader(HomePageUrl, LanguagesAndLinks, TargetLanguage, StepperItems));

        var finalOutput = new TagBuilder("div");

        if (StepperItems != null && StepperItems.Any())
        {
            var wrapperDiv = new TagBuilder("div");
            wrapperDiv.AddCssClass("c-navbar--with-stepper");
            wrapperDiv.InnerHtml.AppendHtml(header);

            var stepsHtml = GenerateStepsHtml();
            wrapperDiv.InnerHtml.AppendHtml(stepsHtml);
            finalOutput.InnerHtml.AppendHtml(wrapperDiv);
        }
        else
        {
            finalOutput.InnerHtml.AppendHtml(header);
        }


        output.TagName = finalOutput.TagName;
        output.MergeAttributes(finalOutput);
        output.TagMode = TagMode.StartTagAndEndTag;
        output.Content.SetHtmlContent(finalOutput.InnerHtml);
    }

    private IHtmlContent GenerateStepsHtml()
    {
        var tagBuilder = new TagBuilder("div");
        tagBuilder.AddCssClass("o-container o-container--small");

        var h2 = new TagBuilder("h2");
        h2.AddCssClass("c-d-h4 u-spacer-top-xl br-styleguide-brand-heading");
        h2.InnerHtml.AppendHtml("Inscrivez-vous en suivant ces 2 étapes");
        tagBuilder.InnerHtml.AppendHtml(h2);

        var nav = new TagBuilder("nav");
        nav.AddCssClass("c-wizard");

        var ul = new TagBuilder("ul");

        // Use Select to get both the item and its index
        foreach (var (item, index) in StepperItems.Select((item, index) => (item, index)))
        {
            var li = new TagBuilder("li");

            var a = new TagBuilder("a");
            a.AddCssClass("c-wizard__item");
            if (item.IsActive)
            {
                a.AddCssClass("c-wizard--active");
            }
            else
            {
                a.AddCssClass("c-wizard--complete");
            }

            var divIndicator = new TagBuilder("div");
            divIndicator.AddCssClass("c-wizard__indicator");
            if (item.IsActive)
            {
                // Set the indicator's content to the index, adjusted for human-readable numbering
                divIndicator.InnerHtml.AppendHtml((index + 1).ToString());
            }

            var divLabel = new TagBuilder("div");
            divLabel.AddCssClass("c-wizard__label");
            divLabel.InnerHtml.AppendHtml(item.Label);

            a.InnerHtml.AppendHtml(divIndicator);
            a.InnerHtml.AppendHtml(divLabel);

            li.InnerHtml.AppendHtml(a);
            ul.InnerHtml.AppendHtml(li);
        }

        nav.InnerHtml.AppendHtml(ul);
        tagBuilder.InnerHtml.AppendHtml(nav);

        return tagBuilder;
    }


}
