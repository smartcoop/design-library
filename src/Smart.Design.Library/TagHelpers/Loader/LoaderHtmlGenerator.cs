using Microsoft.AspNetCore.Mvc.Rendering;

namespace Smart.Design.Library.TagHelpers.Loader;

public class LoaderHtmlGenerator : ILoaderHtmlGenerator
{
    /// <inheritdoc />
    public TagBuilder GenerateLoader(bool loading)
    {
        var loader = new TagBuilder("div");
        loader.AddCssClass("c-loader");
        loader.Attributes["role"] = "alert";
        loader.Attributes["aria-busy"] = loading.ToString();

        return loader;
    }
}
