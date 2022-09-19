using System.Collections.Generic;
using System;
using FluentAssertions;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Razor.TagHelpers.Panel;
using Xunit;
using Smart.Design.Razor.TagHelpers.Constants;
using System.Threading.Tasks;
using System.IO;
using System.Text.Encodings.Web;

namespace Smart.Design.Razor.Tests.TagHelperTests;

public class PanelTagHelperTests
{
    [Fact]
    public void TagHelperShouldReturnExpectedHtml()
    {
        var expectedHtml = "<div class=\"c-panel__header\"><h2 class=\"c-panel__title\">Test Panel</h2></div><div class=\"c-panel__body\"><smart-panel></smart-panel></div>";
        
        var htmlGenerator = new PanelHtmlGenerator();
        var tagHelper = new PanelTagHelper(htmlGenerator);
        var tagHelperContext = new TagHelperContext(
            new TagHelperAttributeList(),
            new Dictionary<object, object>(),
            Guid.NewGuid().ToString("N"));
        var tagHelperOutput = new TagHelperOutput(
            TagNames.PanelTagName,
            new TagHelperAttributeList(),
            (result, encoder) =>
            {
                var tagHelperContent = new DefaultTagHelperContent();
                tagHelperContent.SetHtmlContent("<p>TESTING</p>");
                return Task.FromResult<TagHelperContent>(tagHelperContent);
            });
        tagHelper.Process(tagHelperContext, tagHelperOutput);

        var tagBuilder = htmlGenerator.GeneratePanel("Test Panel", tagHelperOutput);
        using var sw = new StringWriter();
        tagBuilder.InnerHtml.WriteTo(sw, HtmlEncoder.Default);
        var html = sw.ToString();

        html.Should().NotBeNullOrEmpty();
        html.Should().Be(expectedHtml);
    }
}
