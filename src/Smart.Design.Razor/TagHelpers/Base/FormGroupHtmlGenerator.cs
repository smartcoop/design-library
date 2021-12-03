using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Smart.Design.Razor.TagHelpers.Base;

public class FormGroupHtmlGenerator : BaseHtmlGenerator, IFormGroupHtmlGenerator
{
    /// <inheritdoc />
    public TagBuilder GenerateFormGroup(string? id, string? name, string? label, string? helperText, TagBuilder? controls)
    {
        var formGroup = GenerateFormGroup();

        // We allow whitespace in case the developer wants actually to generate the <label> element.
        if (!string.IsNullOrEmpty(label))
        {
            var formGroupLabel = GenerateFormGroupLabel(label, id);
            formGroup.InnerHtml.AppendHtml(formGroupLabel);
        }

        // Generate the div holding controls regardless it has content or not.
        var formGroupControlsContainer = GenerateFormGroupControlsContainer();

        if (controls is not null)
            formGroupControlsContainer.InnerHtml.AppendHtml(controls);

        if (!string.IsNullOrEmpty(helperText))
        {
            var helperTextTagBuilder = GenerateFormGroupHelperText(helperText);
            formGroupControlsContainer.InnerHtml.AppendHtml(helperTextTagBuilder);
        }

        formGroup.InnerHtml.AppendHtml(formGroupControlsContainer);
        return formGroup;
    }

    /// <inheritdoc />
    public virtual TagBuilder GenerateFormGroup()
    {
        var builder = new TagBuilder("div");
        builder.AddCssClass("o-form-group");

        return builder;
    }

    /// <inheritdoc />
    public TagBuilder GenerateFormGroupLabel(string? label, string? labelFor)
    {
        var labelTagBuilder = new TagBuilder("label");
        labelTagBuilder.AddCssClass("o-form-group__label");
        if (!string.IsNullOrWhiteSpace(label))
        {
            labelTagBuilder.InnerHtml.Append(label);
        }

        if (!string.IsNullOrWhiteSpace(labelFor))
        {
            labelTagBuilder.Attributes.Add("for", labelFor);
        }

        return labelTagBuilder;
    }

    /// <inheritdoc />
    public virtual TagBuilder GenerateFormGroupControlsContainer()
    {
        var formGroupDiv = new TagBuilder("div");
        formGroupDiv.AddCssClass("o-form-group__controls");

        return formGroupDiv;
    }

    /// <inheritdoc />
    public TagBuilder GenerateFormGroupHelperText(string? helperText)
    {
        var tagBuilder = new TagBuilder("p");
        tagBuilder.AddCssClass("c-form-help-text");
        tagBuilder.InnerHtml.SetContent(helperText!);

        return tagBuilder;
    }
}
