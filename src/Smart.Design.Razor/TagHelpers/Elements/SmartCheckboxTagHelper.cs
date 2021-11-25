using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Razor.TagHelpers.Constants;
using Smart.Design.Razor.TagHelpers.Extensions;

namespace Smart.Design.Razor.TagHelpers.Elements
{
    /// <summary>
    ///     <see cref="ITagHelper" /> implementation of the smart design checkbox.
    ///     Documentation is available <see href="https://design.smart.coop/development/docs/c-checkbox.html">here</see>.
    /// </summary>
    [HtmlTargetElement(TagNames.SmartCheckboxTagName)]
    public class SmartCheckboxTagHelper : InputTagHelper
    {
        private const string LabelAttributeName = "label";

        public SmartCheckboxTagHelper(IHtmlGenerator generator) : base(generator)
        {
        }

        [HtmlAttributeName(LabelAttributeName)]
        public string Label { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output);

            // We create a new input element an re-use the attributes generated by the base class.
            var inputRadio = new TagBuilder("input");
            inputRadio.MergeAttributes(output.Attributes);
            inputRadio.TagRenderMode = TagRenderMode.SelfClosing;

            // The div containing all elements.
            var mainDiv = new TagBuilder("div");
            mainDiv.AddCssClass("c-checkbox");

            var labelTag = new TagBuilder("label");
            labelTag.InnerHtml.AppendHtml(inputRadio);
            if (!string.IsNullOrWhiteSpace(Label)) labelTag.InnerHtml.Append(Label);

            mainDiv.InnerHtml.AppendHtml(labelTag);

            output.Content.Reinitialize();
            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;

            output.ClearAllAttributes();
            output.MergeAttributes(mainDiv);

            output.Content.SetHtmlContent(mainDiv.InnerHtml);
        }
    }
}