using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Razor.TagHelpers.Base;
using Smart.Design.Razor.TagHelpers.Constants;
using Smart.Design.Razor.TagHelpers.Html;

namespace Smart.Design.Razor.TagHelpers.FormGroups
{    /// <summary>
    /// <see cref="BaseSmartFormGroupTagHelper" /> implementation with a <see cref="SmartFormGroupInputTextTagHelper" />.
    /// </summary>
    [HtmlTargetElement(TagNames.SmartFormGroupInputText)]
    public class SmartFormGroupInputTextTagHelper : BaseSmartFormGroupTagHelper
    {
        private const string PlaceHolderAttributeName = "placeholder";

        [HtmlAttributeName(PlaceHolderAttributeName)]
        public string PlaceHolder { get; set; }

        public SmartFormGroupInputTextTagHelper(ISmartHtmlGenerator htmlGenerator) : base(htmlGenerator)
        {
        }

        public override TagBuilder GenerateFormGroupControl()
        {
            return HtmlGenerator.GenerateSmartInputText(ViewContext, Id, Name, PlaceHolder, Value, For);
        }
    }
}
