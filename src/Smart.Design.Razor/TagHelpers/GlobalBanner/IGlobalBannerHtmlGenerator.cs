using Microsoft.AspNetCore.Mvc.Rendering;

namespace Smart.Design.Razor.TagHelpers.GlobalBanner;

/// <summary>
/// Generates Smart Design Global Banner HTMl.
/// </summary>
public interface IGlobalBannerHtmlGenerator
{
    /// <summary>
    /// Generates a global banner widget compliant with Smart design.
    /// Documentation is available <see href="https://design.smart.coop/development/docs/c-global-banner.html">here</see>.
    /// </summary>
    /// <param name="globalBannerType">The style <see cref="GlobalBannerType">type</see> of the banner.</param>
    /// <param name="label">The label displayed by the banner.</param>
    /// <returns>A instance of a global banner</returns>
    TagBuilder GenerateGlobalBanner(GlobalBannerType globalBannerType, string? label);
}
