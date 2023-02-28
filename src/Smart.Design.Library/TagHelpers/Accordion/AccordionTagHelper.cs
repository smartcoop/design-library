using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Library.TagHelpers.Base;
using Smart.Design.Library.TagHelpers.Constants;
using Smart.Design.Library.TagHelpers.Icon;

namespace Smart.Design.Library.TagHelpers.Accordion;

/// <summary>
///<see cref="ITagHelper" /> implementation of the Smart design accordion.
///Documentation is available <see href="https://design.smart.coop/development/docs/c-accordion.html">here</see>.
///<para>
///<term>Remark</term>
///Inherits from <see cref="BaseTagHelper" />
///</para>
/// </summary>
[HtmlTargetElement(TagNames.AccordionTagName, TagStructure = TagStructure.NormalOrSelfClosing)]
public class AccordionTagHelper : TagHelper
{
    private readonly IIconHtmlGenerator _iconHtmlGenerator;
    private const string TitleAttributeName = "title";

    public AccordionTagHelper(IIconHtmlGenerator iconHtmlGenerator)
    {
        _iconHtmlGenerator = iconHtmlGenerator;
    }

    [HtmlAttributeName(TitleAttributeName)]
    public string? Title { get; set; }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        output.Attributes.Clear();
        output.TagName = "div";
        output.TagMode = TagMode.StartTagAndEndTag;

        var content = (await output.GetChildContentAsync()).GetContent();

        output.AddClass("c-accordion", HtmlEncoder.Default);

        var accordion = new TagBuilder("div");
        accordion.AddCssClass("c-accordion__item");

        var accordionHeader = new TagBuilder("div");
        accordionHeader.AddCssClass("c-accordion__item-header");

        var toolbarContainer = new TagBuilder("div");
        toolbarContainer.AddCssClass("c-toolbar");

        var toolbarParent = new TagBuilder("div");
        toolbarParent.AddCssClass("c-toolbar__left");

        var toolbarItem = new TagBuilder("div");
        toolbarItem.AddCssClass("c-toolbar__item");

        var toolbarButton = new TagBuilder("button");
        toolbarButton.AddCssClass("c-button c-button--borderless c-button--icon");
        toolbarButton.Attributes.Add("type", "button");

        var toolbarButtonContent = new TagBuilder("span");
        toolbarButtonContent.AddCssClass("c-button__content");

        var trailingIcon = await _iconHtmlGenerator.GenerateIconAsync(Image.ChevronRight);
        toolbarButtonContent.InnerHtml.AppendHtml(trailingIcon);

        var accordionTitle = new TagBuilder("span");
        accordionTitle.AddCssClass("c-accordion__item-title");

        if (Title is not null)
            accordionTitle.InnerHtml.Append(Title);

        var accordionContent = new TagBuilder("div");
        accordionContent.AddCssClass("c-accordion__item-content");
        accordionContent.InnerHtml.AppendHtml(content);

        toolbarButton.InnerHtml.AppendHtml(toolbarButtonContent);
        toolbarItem.InnerHtml.AppendHtml(toolbarButton);
        toolbarItem.InnerHtml.AppendHtml(accordionTitle);
        toolbarParent.InnerHtml.AppendHtml(toolbarItem);
        toolbarContainer.InnerHtml.AppendHtml(toolbarParent);
        accordionHeader.InnerHtml.AppendHtml(toolbarContainer);
        accordion.InnerHtml.AppendHtml(accordionHeader);
        accordion.InnerHtml.AppendHtml(accordionContent);

        output.Content.SetHtmlContent(accordion);
    }
}
