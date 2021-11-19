using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Razor.TagHelpers.Base;
using Smart.Design.Razor.TagHelpers.Constants;
using Smart.Design.Razor.TagHelpers.Extensions;
using Smart.Design.Razor.TagHelpers.Html;

namespace Smart.Design.Razor.TagHelpers.Panel
{
    /// <summary>
    /// <see cref="ITagHelper" /> implementation of the smart design panel with a <c>header</c> attribute.
    /// Documentation is available <see href="https://design.smart.coop/development/docs/c-panel.html">here</see>.
    /// <para>
    ///     <term>Remark</term> Inherits from <see cref="BaseTagHelper"/>.
    /// </para>
    /// </summary>
    [HtmlTargetElement(TagNames.SmartPanelTagName, TagStructure = TagStructure.NormalOrSelfClosing)]
    public class SmartPanelTagHelper : BaseTagHelper
    {
        public string Header { get; set; }

        public SmartPanelTagHelper(ISmartHtmlGenerator smartHtmlGenerator) : base(smartHtmlGenerator)
        {
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var panelBody = await output.GetChildContentAsync();
            var panel = HtmlGenerator.GenerateSmartPanel(Header, panelBody);

            output.TagName = panel.TagName;
            output.TagMode = TagMode.StartTagAndEndTag;

            output.ClearAndMergeAttributes(panel);

            output.Content.SetHtmlContent(panel.InnerHtml);
        }
    }
}
