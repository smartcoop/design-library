using System;
using System.Globalization;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Razor.TagHelpers.Base;
using Smart.Design.Razor.TagHelpers.Constants;
using Smart.Design.Razor.TagHelpers.Extensions;

namespace Smart.Design.Razor.TagHelpers.Elements.Input;

[HtmlTargetElement(TagNames.InputTimeTagName, TagStructure = TagStructure.NormalOrSelfClosing)]
public class InputTimeTagHelper : BaseTagHelper
{
    private readonly IInputHtmlGenerator _smartHtmlGenerator;
    private const string AspForAttributeName = "asp-for";
    private const string ValueAttributeName = "value";

    [HtmlAttributeName(AspForAttributeName)]
    public ModelExpression? For { get; set; }

    [HtmlAttributeName(ValueAttributeName)]
    public string? Value { get; set; }

    public InputTimeTagHelper(IInputHtmlGenerator smartHtmlGenerator)
    {
        _smartHtmlGenerator = smartHtmlGenerator;
    }

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
