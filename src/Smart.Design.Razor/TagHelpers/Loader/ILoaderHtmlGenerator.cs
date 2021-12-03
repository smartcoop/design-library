using Microsoft.AspNetCore.Mvc.Rendering;

namespace Smart.Design.Razor.TagHelpers.Loader;

public interface ILoaderHtmlGenerator
{

    /// <summary>
    /// Generates a Smart design loader.
    /// Documentation is available <see ref="https://design.smart.coop/development/docs/c-loader.html">here</see>.
    /// </summary>
    /// <param name="loading">The state of the component, i.e. loading or not.</param>
    /// <returns>An instance of a Smart design loader.</returns>
    TagBuilder GenerateLoader(bool loading);
}
