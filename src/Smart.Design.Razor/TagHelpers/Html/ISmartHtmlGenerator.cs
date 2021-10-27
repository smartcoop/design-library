using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable enable
namespace Smart.Design.Razor.TagHelpers.Html
{
    /// <summary>
    /// Contract for a service supporting <see cref="IHtmlHelper"/> and <c>ITagHelper</c> implementations compliant with
    /// <see href="https://design.smart.coop">smart design</see>.
    /// </summary>
    public interface ISmartHtmlGenerator
    {
        /// <summary>
        /// Generates a &lt;input&gt; text compliant with smart design guidelines.
        /// </summary>
        /// <param name="viewContext">A <see cref="ViewContext"/> instance for the current scope.</param>
        /// <param name="id">Id of the element</param>
        /// <param name="name">The name of the element</param>
        /// <param name="placeholder"></param>
        /// <param name="value">The value of the input</param>
        /// <param name="for">The <see cref="ModelExpression"/> for the <paramref name="name"/>.</param>
        /// <returns></returns>
        TagBuilder GenerateSmartInputText(ViewContext viewContext, string id, string name, string placeholder,
            object? value, ModelExpression @for);
    }
#nullable disable
}
