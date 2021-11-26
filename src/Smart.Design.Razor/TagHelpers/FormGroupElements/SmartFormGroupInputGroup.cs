using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Razor.Enums;
using Smart.Design.Razor.TagHelpers.Base;
using Smart.Design.Razor.TagHelpers.Html;

namespace Smart.Design.Razor.TagHelpers.FormGroupElements
{
    /// <summary>
    /// <see cref="BaseSmartFormGroupTagHelper"/> implementation with a <see cref="SmartFormGroupInputGroup" />.
    /// </summary>
    public class SmartFormGroupInputGroup : BaseSmartFormGroupTagHelper
    {
        private const string AlignmentAttributeName = "alignment";
        private const string GroupedTextAttributeName = "grouped-text";
        private const string IconAttributeName = "icon";
        private const string PlaceholderAttributeName = "placeholder";

        [HtmlAttributeName(PlaceholderAttributeName)]
        public string Placeholder { get; set; }

        [HtmlAttributeName(IconAttributeName)]
        public Icon Icon { get; set; }

        [HtmlAttributeName(GroupedTextAttributeName)]
        public string GroupedText { get; set; }

        [HtmlAttributeName(AlignmentAttributeName)]
        public Alignment Alignment { get; set; }

        public SmartFormGroupInputGroup(ISmartHtmlGenerator htmlGenerator) : base(htmlGenerator)
        {
        }

        public override void Init(TagHelperContext context)
        {
            base.Init(context);

            if (!string.IsNullOrWhiteSpace(GroupedText) && Icon != Icon.None)
            {
                throw new InvalidOperationException("input group cannot have and icon and a grouped text set");
            }
        }

        public override TagBuilder GenerateFormGroupControl()
        {
            return HtmlGenerator.GenerateInputGroup(ViewContext, Id, Name, Placeholder, Value, For, Alignment, Icon, GroupedText);
        }
    }
}
