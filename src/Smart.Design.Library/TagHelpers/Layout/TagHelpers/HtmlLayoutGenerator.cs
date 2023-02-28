using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Smart.Design.Library.TagHelpers.Layout.TagHelpers;

/// <summary>
/// Generates all HTML components required for the layout of a Smart Design page.
/// </summary>
public class HtmlLayoutGenerator : IHtmlLayoutGenerator
{
    public TagBuilder GenerateApplicationLayoutInnerContent(IHtmlContent actualChildren)
    {
        var content = new TagBuilder("div");
        content.AddCssClass("c-app-layout-inner__content");

        // The inner content div has a direct u-scroll-wrapper.div
        var wrapper = new TagBuilder("div");
        wrapper.AddCssClass("u-scroll-wrapper");

        wrapper.InnerHtml.SetHtmlContent(actualChildren);
        return content;
    }

    /// <inheritdoc />
    public TagBuilder GenerateApplicationLayout()
    {
        var appLayout = new TagBuilder("div");
        appLayout.AddCssClass("c-app-layout");
        return appLayout;
    }

    public TagBuilder GenerateSideBar()
    {
        throw new System.NotImplementedException();
    }

    /// <inheritdoc />
    public TagBuilder GenerateBody()
    {
        var body = new TagBuilder("body");
        body.AddCssClass("u-maximize-height u-overflow-hidden");

        return body;
    }

    /// <inheritdoc />
    public TagBuilder GenerateBodyWrapper(IHtmlContent childContent)
    {
        // The body wrapper is the root HTML element.
        var bodyWrapper = new TagBuilder("div");
        bodyWrapper.AddCssClass("u-scroll-wrapper-body");

        // The body wrapper has a direct u-spacer-xl.div (XL spacer).
        var spacer = new TagBuilder("div");
        spacer.AddCssClass("x-spacer-xl");

        // And finally we have a bottom spacer that is child of the XL spacer
        var bottomSpacer = new TagBuilder("div");
        bottomSpacer.AddCssClass("u-spacer-bottom-l");

        // The actual HTML child will be the final content.
        bottomSpacer.InnerHtml.AppendHtml(childContent);

        // [Original children content] -> bottomSpacer -> xl spacer -> body wrapper.
        spacer.InnerHtml.AppendHtml(bottomSpacer);
        bodyWrapper.InnerHtml.AppendHtml(spacer);

        return bodyWrapper;
    }

    /// <inheritdoc />
    public TagBuilder GenerateMain(IHtmlContent childContent)
    {
        var mainElement = new TagBuilder("main");
        mainElement.AddCssClass("u-maximize-width u-scroll-wrapper");

        var innerLayout = new TagBuilder("div");
        innerLayout.AddCssClass("c-app-layout-inner");

        // The actual children HTML of the MainLayoutTagHelper is appended to the inner layout.
        // And then the inner layout is the direct child of the mainElement
        innerLayout.InnerHtml.AppendHtml(childContent);
        mainElement.InnerHtml.AppendHtml(innerLayout);

        return mainElement;
    }
}
