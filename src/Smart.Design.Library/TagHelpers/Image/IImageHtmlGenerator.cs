using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Smart.Design.Library.TagHelpers.Image;

public interface IImageHtmlGenerator
{
    /// <summary>
    /// Generates a &lt;div&gt; whose content is a &lt;svg&gt;.
    /// </summary>
    /// <param name="image">The icon to render.</param>
    /// <returns>An instance of the icon.</returns>
    TagBuilder GenerateIcon(Image image);

    /// <summary>
    /// Generates a &lt;div&gt; whose content is a &lt;svg&gt;.
    /// </summary>
    /// <returns>An instance of the image.</returns>
    TagBuilder GenerateImage(Image image);

    /// <summary>
    /// Generates asynchronously a div whose content is a &lt;svg&gt;.
    /// </summary>
    /// <param name="image">The icon to render</param>
    /// <returns>
    /// A task that represents the rendering asynchronous operation.
    /// The task result is the instance of the icon.
    /// </returns>
    Task<TagBuilder> GenerateIconAsync(Image image);


}
