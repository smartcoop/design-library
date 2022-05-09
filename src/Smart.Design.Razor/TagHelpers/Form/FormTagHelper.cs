using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Razor.TagHelpers.Base;
using Smart.Design.Razor.TagHelpers.Constants;

namespace Smart.Design.Razor.TagHelpers.Form;

/// <summary>
/// <see cref="ITagHelper" /> implementation of a Smart design &lt;form&gt;.
/// </summary>
[HtmlTargetElement(TagNames.FormTagName)]
public class FormTagHelper : BaseTagHelper
{
    private const string MethodAttributeName = "method";
    private const string LayoutAttributeName = "layout";

    private readonly IFormHtmlGenerator _generator;
    private readonly IHtmlGenerator _htmlGenerator;

    [HtmlAttributeName(MethodAttributeName)]
    public FormMethod Method { get; set; }

    [HtmlAttributeName(LayoutAttributeName)]
    public FormLayout Layout {get; set;}

    public FormTagHelper(IFormHtmlGenerator generator, IHtmlGenerator htmlGenerator)
    {
        _generator = generator;
        _htmlGenerator = htmlGenerator;
    }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        // The framework checks if the form is sending an antiforgery token upon posting.
        // Therefore we need to generate one.
        var generateAntiforgery = _htmlGenerator.GenerateAntiforgery(ViewContext);
        var content = await output.GetChildContentAsync();
        content.AppendHtml(generateAntiforgery);

        var form = _generator.GenerateForm(Id, Layout, content, Method);

        output.MergeAttributes(form);
        output.TagName = form.TagName;
        output.TagMode = TagMode.StartTagAndEndTag;
        output.Content.SetHtmlContent(form.InnerHtml);
    }
}
