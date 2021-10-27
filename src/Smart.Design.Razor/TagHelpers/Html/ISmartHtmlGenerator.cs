using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Razor.Enums;

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

        /// <summary>
        /// Generate a form group with its label and an empty controls container.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="label">The label associated to the form group.</param>
        /// <param name="helperText"></param>
        /// <param name="controls">The content of the controls container.</param>
        /// <returns>A instance of a form group.</returns>
        TagBuilder GenerateFormGroup(string id, string name, string label, string helperText, TagBuilder controls);

        /// <summary>
        /// Generates a form group &lt;div&gt;.
        /// The combination of a form label and an element field are usually wrapped inside this element.
        /// The consistent markup pattern makes it easy to manipulate grouped form elements.
        /// </summary>
        /// <returns> An instance of the &lt;div&gt;</returns>
        TagBuilder GenerateFormGroup();

        /// <summary>
        /// Generate a &lt;label&gt; element.
        /// </summary>
        /// <param name="label">The value of the label.</param>
        /// <param name="labelFor"></param>
        /// <returns>A instance of the &lt;label&gt;</returns>
        TagBuilder GenerateFormGroupLabel(string label, string labelFor);

        /// <summary>
        /// Generate a &lt;div&gt; in which are grouped element of a form group.
        /// </summary>
        /// <returns> An instance of the &lt;div&gt;</returns>
        TagBuilder GenerateFormGroupControlsContainer();

        /// <summary>
        /// Generate a &lt;div&gt; that represents a panel and is compliant with smart design.
        /// A panel is composed of two things: a header and a body.
        /// </summary>
        /// <param name="header">The header of the panel.</param>
        /// <param name="body">The content of the panel. This can be any html.</param>
        /// <returns>A instance of a &lt;div&gt; that represents a panel.</returns>
        TagBuilder GenerateSmartPanel(string header, IHtmlContent body);

        /// <summary>
        /// Generate a &lt;textarea&gt; that is compliant with smart design.
        /// </summary>
        /// <param name="id">The id of the &lt;textarea&gt;</param>
        /// <param name="name">The name of the &lt;textarea&gt;</param>
        /// <param name="rows">The number of rows of the &lt;textarea&gt;. This parameter is optional.</param>
        /// <param name="textareaSize"></param>
        /// <param name="for"></param>
        /// <returns>An instance of the &lt;textarea&gt;</returns>
        TagBuilder GenerateSmartTextArea(string id, string name, int? rows, TextAreaSize textareaSize, ModelExpression @for);

        /// <summary>
        /// Generate a div that represents the smart button toolbar.
        /// Documentation is available <see href="https://design.smart.coop/development/docs/c-button-toolbar.html">here</see>.
        /// </summary>
        /// <param name="layout">The orientation of the item inside the toolbar. Value are.</param>
        /// <param name="isCompact">Tells is there should be no space between items.</param>
        /// <returns>A instance of a smart button toolbar</returns>
        TagBuilder GenerateSmartButtonToolbar(ButtonToolbarLayout layout, bool isCompact);

        /// <summary>
        /// Generates a &lt;div&gt; that is a smart container.
        /// More info can be seen <see href="https://design.smart.coop/development/docs/o-container.html">here</see>.
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        TagBuilder GenerateSmartContainer(ContainerSize size);

        /// <summary>
        /// Generate a &lt;hr&gt; that is compliant with smart design
        /// More information can be seen <see href="https://sesign.smart.coop">here</see>.
        /// </summary>
        /// <returns></returns>
        TagBuilder GenerateHorizontalRule();

        /// <summary>
        /// Generates a &lt;div&gt; whose content is a &lt;svg&gt;.
        /// </summary>
        /// <param name="icon">The icon to render.</param>
        /// <returns>An instance of the icon.</returns>
        TagBuilder GenerateIcon(Icon icon);

        /// <summary>
        /// Generates asynchronously a div whose content is a &lt;svg&gt;.
        /// </summary>
        /// <param name="icon">The icon to render</param>
        /// <returns>
        /// A task that represents the rendering asynchronous operation.
        /// The task result is the instance of the icon.
        /// </returns>
        Task<TagBuilder> GenerateIconAsync(Icon icon);

        /// <summary>
        /// Generates a &lt;div&gt; that is a smart design grid.
        /// Documentation is available <see href="https://design.smart.coop/development/docs/o-grid.html">here</see>.
        /// </summary>
        /// <returns>An instance of the grid.</returns>
        TagBuilder GenerateSmartGrid();

        /// <summary>
        /// Generates a column for the smart grid.
        /// Documentation is available <see href="https://design.smart.coop/development/docs/o-grid.html">here</see>.
        /// </summary>
        /// <param name="width">The width of the column.</param>
        /// <returns>An instance of a column.</returns>
        TagBuilder GenerateSmartColumnGrid(int width);
    }
#nullable disable
}
