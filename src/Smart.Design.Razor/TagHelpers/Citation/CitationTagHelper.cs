using System.Collections.Generic;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Razor.TagHelpers.Constants;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using System.Threading.Tasks;

namespace Smart.Design.Razor.TagHelpers.Citation;

/// <summary>
/// Implementation of a Smart design citation.
/// Documentation is available <see href="https://design.smart.coop/development/docs/c-citation.html">here</see>.
/// </summary>
[HtmlTargetElement(TagNames.CitationTagName)]
public class CitationTagHelper : TagHelper
{
    private readonly ICitationGenerator _citationGenerator;

    /// <summary>
    /// Title of the citation.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Text of the citation.
    /// </summary>
    public string Content { get; set; }

    /// <summary>
    /// Creates a new <see cref="CitationTagHelper"/>.
    /// </summary>
    /// <param name="citationGenerator">The service that generates Smart Design citation HTML.</param>
    public CitationTagHelper(ICitationGenerator citationGenerator)
    {
        _citationGenerator = citationGenerator;
    }

    /// <inheritdoc />
    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        var citation = _citationGenerator.GenerateCitation(Title, Content);

        output.MergeAttributes(citation);
        output.TagName = citation.TagName;
        output.TagMode = TagMode.StartTagAndEndTag;
        output.Content.SetHtmlContent(citation.InnerHtml);
    }
}
