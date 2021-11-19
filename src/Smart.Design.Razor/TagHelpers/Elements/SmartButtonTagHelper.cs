using System;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Razor.Enums;
using Smart.Design.Razor.TagHelpers.Base;
using Smart.Design.Razor.TagHelpers.Constants;
using Smart.Design.Razor.TagHelpers.Extensions;
using Smart.Design.Razor.TagHelpers.Html;

namespace Smart.Design.Razor.TagHelpers.Elements
{
    /// <summary>
    /// <see cref="ITagHelper" /> implementation of the smart design button with
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
    [HtmlTargetElement(TagNames.SmartButtonTagName, TagStructure = TagStructure.NormalOrSelfClosing)]
    public class SmartButtonTagHelper : BaseTagHelper
    {
        [HtmlAttributeName("disabled")]
        public bool Disabled { get; set; }

        [HtmlAttributeName("leading-icon")]
        public Icon LeadingIcon { get; set; }

        [HtmlAttributeName("trailing-icon")]
        public Icon TrailingIcon { get; set; }

        [HtmlAttributeName("label")]
        public string Label { get; set; }

        [HtmlAttributeName("button-type")]
        public ButtonType Type { get; set; } = ButtonType.Button;

        [HtmlAttributeName("button-style")]
        public ButtonStyle Style { get; set; } = ButtonStyle.Primary;

        [HtmlAttributeName("is-block")]
        public bool IsBlock { get; set; }

        [HtmlAttributeName("icon-only")]
        public bool IconOnly { get; set; }

        [HtmlAttributeName("loading")]
        public bool IsLoading { get; set; }

        public SmartButtonTagHelper(ISmartHtmlGenerator smartHtmlGenerator) : base(smartHtmlGenerator)
        {
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var button = await HtmlGenerator.GenerateSmartButton(this.ToOptions());

            output.TagName = button.TagName;
            output.TagMode = TagMode.StartTagAndEndTag;

            output.Attributes.Clear();
            output.MergeAttributes(button);

            output.Content.SetHtmlContent(button.InnerHtml);
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
                _                           => throw new NotImplementedException($"Style undefined for style {Style}")
            };
        }
    }
}
