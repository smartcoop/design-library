using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using CaseExtensions;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Smart.Design.Razor.Enums;

namespace Smart.Design.Razor.TagHelpers.Html
{
    public class SmartHtmlGenerator : ISmartHtmlGenerator
    {
        private static string? s_baseIconPath;
        private static string BaseIconPath => s_baseIconPath ??=
        	$"{Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}/wwwroot/icons";

        private readonly ValidationHtmlAttributeProvider _validationHtmlAttributeProvider;

        public SmartHtmlGenerator(ValidationHtmlAttributeProvider validationHtmlAttributeProvider)
        {
            _validationHtmlAttributeProvider = validationHtmlAttributeProvider;
        }

        /// <inheritdoc />
        public TagBuilder GenerateSmartInputText(ViewContext viewContext, string id, string name, string placeholder, object? value, ModelExpression @for)
        {
            var inputTextTagBuilder = new TagBuilder("input");

            var inputName = GetAttributeName(name, @for);

            inputTextTagBuilder.Attributes.Add("type", "text");
            inputTextTagBuilder.AddCssClass("c-input");
            inputTextTagBuilder.TagRenderMode = TagRenderMode.SelfClosing;

            if (!string.IsNullOrWhiteSpace(id))
            {
                inputTextTagBuilder.Attributes[id] = id;
            }

            if (!string.IsNullOrWhiteSpace(inputName))
            {
                inputTextTagBuilder.Attributes["name"] = inputName;
            }

            if (!string.IsNullOrWhiteSpace(placeholder))
            {
                inputTextTagBuilder.Attributes["placeholder"] = placeholder;
            }

            if (@for?.Model is string val)
            {
                inputTextTagBuilder.Attributes["value"] = val;
            }
            else if (value is string inputValue && !string.IsNullOrWhiteSpace(inputValue))
            {
                inputTextTagBuilder.Attributes["value"] = inputValue;
            }

            if (@for is not null)
                _validationHtmlAttributeProvider.AddAndTrackValidationAttributes(viewContext, @for.ModelExplorer,
                    inputName, inputTextTagBuilder.Attributes);

            return inputTextTagBuilder;
        }

        /// <inheritdoc />
        public virtual TagBuilder GenerateSmartPanel(string header, IHtmlContent content)
        {
            var panel = new TagBuilder("div");
            panel.AddCssClass("c-panel");

            // div that contains the actual header html element.
            var panelHeader = new TagBuilder("div");
            panelHeader.AddCssClass("c-panel__header");

            // Actual header title.
            var headerTagBuilder = new TagBuilder("h2");
            headerTagBuilder.AddCssClass("c-panel__title");
            if (!string.IsNullOrEmpty(header))
            {
                headerTagBuilder.InnerHtml.SetContent(header);
            }

            panelHeader.InnerHtml.AppendHtml(headerTagBuilder);

            // div containing the body
            var panelBody = new TagBuilder("div");
            panelBody.AddCssClass("c-panel__body");
            panelBody.InnerHtml.AppendHtml(content);

            panel.InnerHtml.AppendHtml(panelHeader);
            panel.InnerHtml.AppendHtml(panelBody);

            return panel;
        }

        /// <inheritdoc />
        public TagBuilder GenerateSmartButtonToolbar(ButtonToolbarLayout layout, bool isCompact)
        {
            var toolbar = new TagBuilder("div");
            toolbar.AddCssClass("c-button-toolbar");

            if (layout == ButtonToolbarLayout.Vertical)
            {
                toolbar.AddCssClass("c-button-toolbar--vertical");
            }

            if (isCompact)
            {
                toolbar.AddCssClass("c-button-toolbar--compact");
            }

            return toolbar;
        }

        /// <inheritdoc />
        public TagBuilder GenerateHorizontalRule()
        {
            var hr = new TagBuilder("hr");
            hr.AddCssClass("c-hr");
            return hr;
        }

        /// <inheritdoc />
        public TagBuilder GenerateIcon(Icon icon)
        {
            var iconDiv = new TagBuilder("div");
            iconDiv.AddCssClass($"o-svg-icon o-svg-icon-{icon.ToString().ToKebabCase()}");
            if (icon != Icon.None)
            {
                var svg = File.ReadAllText($"{BaseIconPath}/{icon.ToString().ToKebabCase()}.svg");
                iconDiv.InnerHtml.AppendHtml(svg);
            }

            return iconDiv;
        }

        /// <inheritdoc />
        public async Task<TagBuilder> GenerateIconAsync(Icon icon)
        {
            var iconDiv = new TagBuilder("div");
            iconDiv.AddCssClass($"o-svg-icon o-svg-icon-{icon.ToString().ToKebabCase()}");
            var svg = await File.ReadAllTextAsync($"{BaseIconPath}/{icon.ToString().ToKebabCase()}.svg");
            iconDiv.InnerHtml.AppendHtml(svg);

            return iconDiv;
        }

        private string GetAttributeName(string name, ModelExpression modelExpression)
        {
            return !string.IsNullOrWhiteSpace(modelExpression?.Name) ? modelExpression.Name : name;
        }
    }
}
