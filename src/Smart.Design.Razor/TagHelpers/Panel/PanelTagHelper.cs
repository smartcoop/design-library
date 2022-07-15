using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Razor.TagHelpers.Base;
using Smart.Design.Razor.TagHelpers.Constants;

namespace Smart.Design.Razor.TagHelpers.Panel;

/// <summary>
/// <see cref="ITagHelper" /> implementation of the Smart design panel with a <c>header</c> attribute.
/// Panels are used to separate page content into logical sections. A panel can consist of a panel header, a panel body.
/// Documentation is available <see href="https://design.smart.coop/development/docs/c-panel.html">here</see>.
/// <para>
///     <term>Remark</term> Inherits from <see cref="BaseTagHelper"/>.
/// </para>
/// </summary>
[HtmlTargetElement(TagNames.PanelTagName, TagStructure = TagStructure.NormalOrSelfClosing)]
public class PanelTagHelper : BaseTagHelper
{
    private readonly IPanelHtmlGenerator _panelHtmlGenerator;

    /// <summary>
    /// Header of the Smart Panel.
    /// If this is null or empty, no Header is rendered.
    /// </summary>
    public string? Header { get; set; }

    /// <summary>
    /// Creates a new <see cref="PanelTagHelper"/>.
    /// </summary>
    /// <param name="panelHtmlGenerator">The <see cref="IPanelHtmlGenerator"/>.</param>
    public PanelTagHelper(IPanelHtmlGenerator panelHtmlGenerator)
    {
        _panelHtmlGenerator = panelHtmlGenerator;
    }

    /// <inheritdoc />
    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        var panelBody = await output.GetChildContentAsync();
        var panel = _panelHtmlGenerator.GeneratePanel(Header, panelBody);
        output.TagName = panel.TagName;
        output.TagMode = TagMode.StartTagAndEndTag;

        output.MergeAttributes(panel);
        output.Content.SetHtmlContent(panel.InnerHtml);
    }
}
