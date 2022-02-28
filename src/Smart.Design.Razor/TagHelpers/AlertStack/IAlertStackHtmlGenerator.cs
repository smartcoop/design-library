using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Smart.Design.Razor.TagHelpers.Icon;

namespace Smart.Design.Razor.TagHelpers.AlertStack;

public interface IAlertStackHtmlGenerator
{
    /// <summary>
    /// Generates a Smart design alert stack.
    /// Documentation is available <see href="https://design.smart.coop/development/docs/c-alert-stack.html">here</see>.
    /// </summary>
    /// <param name="icon">The leading icon of the alert.</param>
    /// <param name="message">The message to be displayed.</param>
    /// <returns></returns>
    Task<TagBuilder> GenerateAlertStackAsync(Image icon, string? message);
}
