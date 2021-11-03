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
        public TagBuilder GenerateFormGroup(string id, string name, string label, string helperText, TagBuilder controls)
        {
            var formGroup = GenerateFormGroup();

            // We allow whitespace in case the developer wants actually to generate the <label> element.
            if (!string.IsNullOrEmpty(label))
            {
                var formGroupLabel = GenerateFormGroupLabel(label, id);
                formGroup.InnerHtml.AppendHtml(formGroupLabel);
            }

            // Generate the div holding controls regardless it has content or not.
            var formGroupControlsContainer = GenerateFormGroupControlsContainer();
            if (controls is not null)
            {
                formGroupControlsContainer.InnerHtml.AppendHtml(controls);
            }

            if (!string.IsNullOrEmpty(helperText))
            {
                var helperTextTagBuilder = GenerateFormGroupHelperText(helperText);
                formGroupControlsContainer.InnerHtml.AppendHtml(helperTextTagBuilder);
            }

            formGroup.InnerHtml.AppendHtml(formGroupControlsContainer);
            return formGroup;
        }

        /// <inheritdoc />
        public virtual TagBuilder GenerateFormGroup()
        {
            var builder = new TagBuilder("div");
            builder.AddCssClass("o-form-group");

            return builder;
        }

        /// <inheritdoc />
        public TagBuilder GenerateFormGroupLabel(string label, string labelFor)
        {
            var labelTagBuilder = new TagBuilder("label");
            labelTagBuilder.AddCssClass("o-form-group__label");
            if (!string.IsNullOrWhiteSpace(label))
            {
                labelTagBuilder.InnerHtml.Append(label);
            }

            if (!string.IsNullOrWhiteSpace(labelFor))
            {
                labelTagBuilder.Attributes.Add("for", labelFor);
            }

            return labelTagBuilder;
        }

        /// <inheritdoc />
        public virtual TagBuilder GenerateFormGroupControlsContainer()
        {
            var formGroupDiv = new TagBuilder("div");
            formGroupDiv.AddCssClass("o-form-group__controls");

            return formGroupDiv;
        }

        public TagBuilder GenerateFormGroupHelperText(string helperText)
        {
            var tagBuilder = new TagBuilder("p");
            tagBuilder.AddCssClass("c-form-help-text");
            tagBuilder.InnerHtml.SetContent(helperText);

            return tagBuilder;
        }

        public TagBuilder GenerateSmartRadio(string id, string name, string label, string value, bool @checked, ModelExpression @for)
        {
            var inputRadioContainer = new TagBuilder("div");
            //if (output.Attributes.ContainsName("class"))
            //{
            //    output.Attributes.Remove(output.Attributes["class"]);
            //}

            inputRadioContainer.AddCssClass("c-radio");

            var radioName = !string.IsNullOrWhiteSpace(@for?.Name) ? @for.Name : name;

            var inputRadioTagBuilder = new TagBuilder("input");
            inputRadioTagBuilder.Attributes.Add("name", radioName);
            inputRadioTagBuilder.Attributes.Add("type", "radio");

            if (@checked)
            {
                inputRadioTagBuilder.Attributes.Add("checked", "checked");
            }

            var modelValue = Convert.ToString(@for?.Model, CultureInfo.CurrentCulture);

            if (modelValue != null &&
                string.Equals(modelValue, value, StringComparison.OrdinalIgnoreCase))
            {
                inputRadioTagBuilder.Attributes.Add("checked", "checked");
            }
            else if (!string.IsNullOrWhiteSpace(value))
            {
                inputRadioTagBuilder.Attributes.Add("value", value);
            }

            var labelTagBuilder = new TagBuilder("label");
            labelTagBuilder.InnerHtml.AppendHtml(inputRadioTagBuilder);
            labelTagBuilder.InnerHtml.Append(label);

            inputRadioContainer.InnerHtml.AppendHtml(labelTagBuilder);

            return inputRadioContainer;
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
        public TagBuilder GenerateSmartTextArea(string id, string name, int? rows, TextAreaSize textareaSize, ModelExpression @for)
        {
            var textAreaTagBuilder = new TagBuilder("textarea");
            textAreaTagBuilder.AddCssClass("c-textarea");

            if (!string.IsNullOrWhiteSpace(id))
            {
                textAreaTagBuilder.Attributes.Add("id", id);
            }

            AddNameAttribute(textAreaTagBuilder, @for, name);

            if (rows.HasValue)
            {
                textAreaTagBuilder.Attributes.Add("rows", rows.Value.ToString(CultureInfo.InvariantCulture));
            }

            if (textareaSize != TextAreaSize.Unspecified)
            {
                textAreaTagBuilder.AddCssClass($"c-input--h-{textareaSize.ToString().ToLowerInvariant()}");
            }

            if (@for?.Model is string content && !string.IsNullOrWhiteSpace(content))
            {
                textAreaTagBuilder.InnerHtml.SetHtmlContent(content);
            }

            return textAreaTagBuilder;
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
        public TagBuilder GenerateSmartContainer(ContainerSize size)
        {
            var container = new TagBuilder("div");
            var cssClass = ContainerSizeCssClass(size);
            container.AddCssClass("o-container");
            container.AddCssClass(cssClass);

            return container;
        }

        private static string ContainerSizeCssClass(ContainerSize size)
        {
            return size switch
            {
                ContainerSize.Small => "o-container--small",
                ContainerSize.Medium => "o-container--medium",
                ContainerSize.Large => "o-container--large",
                _ => "o-container--medium",
            };
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

        /// <inheritdoc />
        public TagBuilder GenerateSmartGrid()
        {
            var grid = new TagBuilder("div");
            grid.AddCssClass("o-grid");

            return grid;
        }

        /// <inheritdoc />
        public TagBuilder GenerateSmartColumnGrid(int width)
        {
            var tagBuilder = new TagBuilder("div");
            if (width is < 1 or > 24)
                throw new IndexOutOfRangeException("Width must be between 1 and 12");

            tagBuilder.AddCssClass($"o-grid-col-{width}");

            return tagBuilder;
        }

        /// <inheritdoc />
        public TagBuilder GenerateForm(FormLayout layout, IHtmlContent content)
        {
            string LayoutCssClass()
            {
                return layout switch
                {
                    FormLayout.Horizontal => "o-form-group-layout--horizontal",
                    FormLayout.Standard   => "o-form-group-layout--standard",
                    FormLayout.Inline     => "o-form-group-layout--inline",
                    _                     => "o-form-group-layout--standard"
                };
            }

            var form = new TagBuilder("form");

            var formGroupLayout = new TagBuilder("div");
            formGroupLayout.AddCssClass("o-form-group-layout");
            formGroupLayout.AddCssClass(LayoutCssClass());

            formGroupLayout.InnerHtml.SetHtmlContent(content);
            form.InnerHtml.SetHtmlContent(formGroupLayout);

            return form;
        }

        public TagBuilder GenerateInputTime(string id, string name, DateTime? value, ModelExpression @for)
        {
            var tagBuilder = new TagBuilder("input");

            if (!string.IsNullOrWhiteSpace(id))
            {
                tagBuilder.Attributes.Add("id", id);
            }

            AddNameAttribute(tagBuilder, @for, name);

            tagBuilder.AddCssClass("c-input");
            tagBuilder.Attributes.Add("type", "time");

            if (@for?.Model is DateTime modelValue)
            {
                tagBuilder.Attributes.Add("value", $"{modelValue:HH:mm}");
            }
            else if (value.HasValue)
            {
                tagBuilder.Attributes.Add("value", $"{value.Value:HH:mm}");
            }

            return tagBuilder;
        }

        private string GetAttributeName(string name, ModelExpression modelExpression)
        {
            return !string.IsNullOrWhiteSpace(modelExpression?.Name) ? modelExpression.Name : name;
        }

        /// <summary>
        /// Sets <see cref="TagBuilder" />'s name depending on the value of <paramref name="modelExpression" /> and <paramref name="name"/>.
        /// If both <paramref name="modelExpression"/> <see cref="ModelExpression.Name"/> and <paramref name="name"/> are empty or null, the attribute is not set.
        /// <see cref="ModelExpression.Name"/> of <paramref name="modelExpression"/> property has precedence over <paramref name="name" />.
        /// </summary>
        /// <param name="tagBuilder">The <see cref="TagBuilder"/> to which attribute name should be set.</param>
        /// <param name="modelExpression">A <see cref="ModelExpression" /> that can be associated to the <paramref name="tagBuilder" /></param>
        /// <param name="name">Value of the name attribute if specified.</param>
        private void AddNameAttribute(TagBuilder tagBuilder, ModelExpression modelExpression, string name)
        {
            var attributeName = GetAttributeName(name, modelExpression);
            if (!string.IsNullOrWhiteSpace(attributeName))
            {
                tagBuilder.Attributes["name"] = attributeName;
            }
        }
    }
}
