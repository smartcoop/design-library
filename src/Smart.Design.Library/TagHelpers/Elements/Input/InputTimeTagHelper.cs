using System;
using System.Globalization;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Library.TagHelpers.Base;
using Smart.Design.Library.TagHelpers.Constants;
using Smart.Design.Library.TagHelpers.Extensions;

namespace Smart.Design.Library.TagHelpers.Elements.Input;

/// <summary>
/// <see cref="ITagHelper"/> implementation of the Smart Input time.
/// </summary>
[HtmlTargetElement(TagNames.InputTimeTagName, TagStructure = TagStructure.NormalOrSelfClosing)]
public class InputTimeTagHelper : BaseTagHelper
{
    private readonly IInputHtmlGenerator _smartHtmlGenerator;
    private const string AspForAttributeName = "asp-for";
    private const string ValueAttributeName = "value";

    /// <summary>
    /// <see cref="ModelExpression"/> associated with the Input.
    /// </summary>
    [HtmlAttributeName(AspForAttributeName)]
    public ModelExpression? For { get; set; }

    /// <summary>
    /// HTML Value of the Input.
    /// </summary>
    [HtmlAttributeName(ValueAttributeName)]
    public string? Value { get; set; }

    /// <summary>
    /// Creates a new <see cref="InputTimeTagHelper"/>.
    /// </summary>
    /// <param name="smartHtmlGenerator">The <see cref="IInputHtmlGenerator"/>.</param>
    public InputTimeTagHelper(IInputHtmlGenerator smartHtmlGenerator)
    {
        _smartHtmlGenerator = smartHtmlGenerator;
    }

    /// <inheritdoc />
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        DateTime? dateTimeValue = null;

        // If value is a correct time format (ex 15:00) the value will be used unless For.Model is a valid DateTime.
        if (DateTime.TryParseExact(Value, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out var parsed))
        {
            dateTimeValue = parsed;
        }

        var inputTime = _smartHtmlGenerator.GenerateInputTime(Id, Name, dateTimeValue, For);

        output.TagName = inputTime.TagName;
        output.TagMode = TagMode.SelfClosing;

        output.ClearAllAttributes();
        output.MergeAttributes(inputTime);
    }
}
