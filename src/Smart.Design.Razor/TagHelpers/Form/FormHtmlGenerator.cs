using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Smart.Design.Razor.TagHelpers.Form;

public class FormHtmlGenerator : IFormHtmlGenerator
{
    /// <inheritdoc />
    public TagBuilder GenerateForm(string? id, FormLayout layout, IHtmlContent content, FormMethod method = default)
    {
        var form = new TagBuilder("form");
        form.Attributes.Add("method", method.ToString().ToLowerInvariant());

        if (!string.IsNullOrEmpty(id))
        {
            form.Attributes.Add("id", id);
        }

        var formGroupLayout = new TagBuilder("div");
        formGroupLayout.AddCssClass("o-form-group-layout");
        formGroupLayout.AddCssClass(LayoutCssClass(ref layout));

        formGroupLayout.InnerHtml.SetHtmlContent(content);
        form.InnerHtml.SetHtmlContent(formGroupLayout);

        return form;
    }

    private string LayoutCssClass(ref FormLayout layout)
    {
        return layout switch
        {
            FormLayout.Horizontal => "o-form-group-layout--horizontal",
            FormLayout.Standard   => "o-form-group-layout--standard",
            FormLayout.Inline     => "o-form-group-layout--inline",
            _                     => "o-form-group-layout--standard"
        };
    }
}
