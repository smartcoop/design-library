using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Smart.Design.Library.TagHelpers.Panel;

/// <inheritdoc cref="IPanelHtmlGenerator" />
public class PanelHtmlGenerator : IPanelHtmlGenerator
{

    /// <inheritdoc />
    public virtual TagBuilder GeneratePanel(string? header, IHtmlContent content)
    {
        var panel = new TagBuilder("div");
        panel.AddCssClass("c-panel");
        if (!string.IsNullOrEmpty(header))
        {
            // div that contains the actual header html element.
            var panelHeader = new TagBuilder("div");
            panelHeader.AddCssClass("c-panel__header");

            // Actual header title.
            var headerTagBuilder = new TagBuilder("h2");
            headerTagBuilder.AddCssClass("c-panel__title");

            headerTagBuilder.InnerHtml.SetContent(header);

            panelHeader.InnerHtml.AppendHtml(headerTagBuilder);
            panel.InnerHtml.AppendHtml(panelHeader);
        }

        // div containing the body
        var panelBody = new TagBuilder("div");
        panelBody.AddCssClass("c-panel__body");
        panelBody.InnerHtml.AppendHtml(content);

        panel.InnerHtml.AppendHtml(panelBody);

        return panel;
    }
}
