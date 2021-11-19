using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Razor.TagHelpers.Extensions;
using Smart.Design.Razor.TagHelpers.Html;

namespace Smart.Design.Razor.TagHelpers.Base
{
    /// <summary>
    /// Abstract base class <see cref="ITagHelper" /> to render smart design form groups with asp-for, helper-text , label, value, value attributes.
    /// Inheriting this class imposes to implement the content of the form group control(s) programatically.
    /// More information can be see <see href="https://design.smart.coop/development/docs/o-form-group.html">here</see>.
    /// </summary>
    [HtmlTargetElement(TagStructure = TagStructure.NormalOrSelfClosing)]
    public abstract class BaseSmartFormGroupTagHelper : BaseTagHelper
    {
        private const string ForAttributeName = "asp-for";
        private const string HelperTextAttributeName = "helper-text";
        private const string LabelAttributeName = "label";
        private const string ValueAttributeName = "value";

        [HtmlAttributeName(HelperTextAttributeName)]
        public string HelperText { get; set; }

        [HtmlAttributeName(LabelAttributeName)]
        public string Label { get; set; }

        [HtmlAttributeName(ValueAttributeName)]
        public string Value { get; set; }

        [HtmlAttributeName(ForAttributeName)]
        public ModelExpression For { get; set; }

        public abstract TagBuilder GenerateFormGroupControl();

        protected BaseSmartFormGroupTagHelper(ISmartHtmlGenerator htmlGenerator) : base(htmlGenerator)
        {
        }

        public override void Init(TagHelperContext context)
        {
            if (string.IsNullOrWhiteSpace(Id))
            {
                Id = context.UniqueId;
            }

            if (!string.IsNullOrWhiteSpace(For?.Name))
            {
                Name = For.Name;
            }
            else if (string.IsNullOrWhiteSpace(Name))
            {
                Name = Id;
            }
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var formGroup = HtmlGenerator.GenerateFormGroup(Id, Name, Label, HelperText, GenerateFormGroupControl());

            output.TagName = formGroup.TagName;
            output.TagMode = TagMode.StartTagAndEndTag;

            output.ClearAndMergeAttributes(formGroup);
            output.Content.SetHtmlContent(formGroup.InnerHtml);
        }
    }
}
