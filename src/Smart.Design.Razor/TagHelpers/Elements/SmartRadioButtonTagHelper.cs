using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Razor.TagHelpers.Base;
using Smart.Design.Razor.TagHelpers.Constants;
using Smart.Design.Razor.TagHelpers.Extensions;
using Smart.Design.Razor.TagHelpers.Html;

namespace Smart.Design.Razor.TagHelpers.Elements
{
    [HtmlTargetElement(TagNames.SmartRadioButtonTagName, TagStructure = TagStructure.NormalOrSelfClosing)]
    public class SmartRadioButtonTagHelper : BaseTagHelper
    {
        private const string AspForAttributeName = "asp-for";
        private const string CheckedAttributeName = "checked";
        private const string LabelAttributeName = "label";
        private const string ValueAttributeName = "value";

        private readonly ValidationHtmlAttributeProvider _validationAttributeProvider;

        public SmartRadioButtonTagHelper(ISmartHtmlGenerator smartHtmlGenerator,
            ValidationHtmlAttributeProvider validationAttributeProvider) : base(smartHtmlGenerator)
        {
            _validationAttributeProvider = validationAttributeProvider;
        }

        [HtmlAttributeName(AspForAttributeName)]
        public ModelExpression For { get; set; }

        [HtmlAttributeName(LabelAttributeName)]
        public string Label { get; set; }

        [HtmlAttributeName(ValueAttributeName)]
        public string Value { get; set; }

        [HtmlAttributeName(CheckedAttributeName)]
        public bool Checked { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var checkbox = HtmlGenerator.GenerateSmartRadio(Id, Name, Label, Value, Checked, For);

            output.TagName = checkbox.TagName;
            output.TagMode = TagMode.StartTagAndEndTag;

            output.ClearAllAttributes();
            output.MergeAttributes(checkbox);

            output.Content.SetHtmlContent(checkbox.InnerHtml);
        }
    }
}
