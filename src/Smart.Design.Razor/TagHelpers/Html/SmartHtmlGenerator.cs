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
using Smart.Design.Razor.TagHelpers.Html.Options;

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

        public TagBuilder GenerateInputGroup(ViewContext viewContext, string id, string name, string placeholder, string value, ModelExpression @for,
            Alignment alignment, Icon icon, string text)
        {
            var inputGroup = new TagBuilder("div");
            inputGroup.AddCssClass("c-input-group");

            if (!string.IsNullOrWhiteSpace(text) && icon != Icon.None)
            {
                throw new ArgumentException($"{nameof(text)} and {nameof(icon)} can not be specified at the same time");
            }

            // Content can be aligned at the beginning or at the end of the inputGroup.

            TagBuilder group = null;

            // If text or icon is set we need to prepare the grouping.
            if (!string.IsNullOrWhiteSpace(text) || icon != Icon.None)
            {
                group = new TagBuilder("div");
                group.AddCssClass($"c-input-group__{(alignment == Alignment.Start ? "prepend" : "append")}");

                if (icon is not Icon.None)
                {
                    var svgIcon = GenerateIcon(icon);
                    group.InnerHtml.SetHtmlContent(svgIcon);
                }
                else if (text is not null)
                {
                    group.InnerHtml.SetHtmlContent(text);
                }
            }

            if (group is not null && alignment == Alignment.Start)
            {
                inputGroup.InnerHtml.AppendHtml(group);
            }

            inputGroup.InnerHtml.AppendHtml(GenerateSmartInputText(viewContext, id, name, placeholder, value, @for));

            if (alignment == Alignment.End && group.HasInnerHtml)
            {
                inputGroup.InnerHtml.AppendHtml(group);
            }

            return inputGroup;
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

        /// <inheritdoc />
        public TagBuilder GenerateGlobalBanner(GlobalBannerType globalBannerType, string label)
        {
            var globalBanner = new TagBuilder("div");
            var extraClass = globalBannerType == GlobalBannerType.Info ? "default" : "warning";
            globalBanner.AddCssClass($"c-global-banner c-global-banner--{extraClass}");

            // Leading icon can be either info a info or a warning.
            var leadIcon = globalBannerType == GlobalBannerType.Info ? GenerateIcon(Icon.CircleInformation) : GenerateIcon(Icon.Warning);

            // Label is the inner html of a paragraph inside a div.
            var labelDiv = new TagBuilder("div");
            labelDiv.AddCssClass("c-global-banner__label");
            var paragraph = new TagBuilder("p");
            paragraph.InnerHtml.Append(label);
            labelDiv.InnerHtml.AppendHtml(paragraph);

            // The button is aligned at the end.
            var button = new TagBuilder("button");
            button.AddCssClass("c-button c-button--borderless c-button--icon");
            button.Attributes["type"] = "button";
            button.Attributes["data-banner-close"] = "data-banner-close";

            // Content of the button
            var spanContent = new TagBuilder("span");
            spanContent.AddCssClass("c-button__content");
            var closeIcon = GenerateIcon(Icon.Close);
            spanContent.InnerHtml.AppendHtml(closeIcon);

            // Accessibility
            var accessibilityDiv = new TagBuilder("div");
            accessibilityDiv.AddCssClass("u-sr-accessible");
            accessibilityDiv.InnerHtml.SetContent("Close");
            spanContent.InnerHtml.AppendHtml(accessibilityDiv);

            button.InnerHtml.AppendHtml(spanContent);

            globalBanner.InnerHtml.AppendHtml(leadIcon);
            globalBanner.InnerHtml.AppendHtml(labelDiv);
            globalBanner.InnerHtml.AppendHtml(button);

            return globalBanner;
        }

        /// <inheritdoc />
        public TagBuilder GenerateElevation(ElevationSize elevation)
        {
            var div = new TagBuilder("div");
            div.AddCssClass($"u-shadow-{(int) elevation}");
            return div;
        }

        public TagBuilder GenerateAlertStack(Icon icon, string message)
        {
            var mainDiv = new TagBuilder("div");
            mainDiv.Attributes.Add("style", "position: relative; width: 100%; height: 100%; min-height: 220px;");

            var ul = new TagBuilder("ul");
            ul.AddCssClass("c-alert-stack");
            ul.Attributes["position"] = "absolute";

            var li = new TagBuilder("li");
            li.AddCssClass("c-alert c-alert--dark");

            var trailingIcon = GenerateIcon(icon);

            var messageContainer = new TagBuilder("div");
            messageContainer.AddCssClass("c-alert__body");
            var messageParagraph = new TagBuilder("p");
            messageParagraph.InnerHtml.SetContent(message);
            messageContainer.InnerHtml.SetHtmlContent(messageParagraph);

            li.InnerHtml.AppendHtml(trailingIcon);
            li.InnerHtml.AppendHtml(messageContainer);

            ul.InnerHtml.AppendHtml(li);

            mainDiv.InnerHtml.AppendHtml(ul);

            return mainDiv;
        }

        /// <inheritdoc />
        public TagBuilder GenerateLoader(bool loading)
        {
            var loader = new TagBuilder("div");
            loader.AddCssClass("c-loader");
            loader.Attributes["role"] = "alert";
            loader.Attributes["aria-busy"] = loading.ToString();

            return loader;

        }

        /// <inheritdoc />
        public TagBuilder GenerateAvatar(AvatarSize size, string imageUrl, string text, Icon icon, string initial, string link)
        {
            var avatar = new TagBuilder("div");
            var avatarClass = $"c-avatar c-avatar--{size.ToString().ToLowerInvariant()}";

            // If an image is set we need to add the following class.
            if (!string.IsNullOrWhiteSpace(imageUrl))
            {
                avatarClass += " c-avatar--img";
            }
            avatar.AddCssClass(avatarClass);

            if (!string.IsNullOrWhiteSpace(imageUrl))
            {
                var image = new TagBuilder("img")
                {
                    Attributes =
                    {
                        ["src"] = imageUrl,
                        ["alt"] = "avatar"
                    }
                };
                avatar.InnerHtml.AppendHtml(image);
            }

            if (icon != Icon.None)
            {
                var iconHtml = GenerateIcon(icon);
                avatar.InnerHtml.AppendHtml(iconHtml);
            }

            if (!string.IsNullOrWhiteSpace(initial))
            {
                avatar.InnerHtml.Append(initial);
            }

            if (!string.IsNullOrWhiteSpace(link))
            {
                var newAvatar = new TagBuilder("a");
                newAvatar.AddCssClass(avatarClass);
                newAvatar.Attributes["href"] = link;
                newAvatar.InnerHtml.SetHtmlContent(avatar.InnerHtml);
                avatar = newAvatar;
            }

            // Generate the div containing text.
            // When text is defined the root tag is no longer the avatar, so we need to encapsulate avatar into another div.
            if (!string.IsNullOrWhiteSpace(text))
            {
                var divText = new TagBuilder("div");
                var paragraph = new TagBuilder("p");
                paragraph.AddCssClass("c-avatar-and-text__text");
                paragraph.InnerHtml.SetContent(text);
                divText.InnerHtml.SetHtmlContent(paragraph);

                var textAvatarContainer = new TagBuilder("div");
                textAvatarContainer.AddCssClass("c-avatar-and-text");

                textAvatarContainer.InnerHtml.SetHtmlContent(avatar);
                textAvatarContainer.InnerHtml.AppendHtml(divText);

                avatar = textAvatarContainer;
            }

            return avatar;
        }

        /// <inheritdoc />
        public async Task<TagBuilder> GenerateSmartButton(SmartButtonOptions buttonOptions)
        {
            var button = new TagBuilder("button");

            button.AddCssClass("c-button");

            var styleCssClass = ComputeButtonStyleCssClass(buttonOptions);
            button.AddCssClass(styleCssClass);
            button.Attributes["type"] = buttonOptions.Type.ToString().ToLowerInvariant();

            if (buttonOptions.Disabled || buttonOptions.IsLoading)
            {
                button.Attributes["disabled"] = "disabled";
            }

            if (buttonOptions.IsBlock)
            {
                button.AddCssClass("c-button--block");
            }

            if (buttonOptions.IsLoading)
            {
                var loadingDiv = new TagBuilder("div");
                loadingDiv.AddCssClass("c-loader");
                button.InnerHtml.AppendHtml(loadingDiv);
            }

            var buttonContent = new TagBuilder("span");
            buttonContent.AddCssClass("c-button__content");

            // If a leading icon is specified it needs to be added as the first child of the container.
            if (buttonOptions.LeadingIcon != Icon.None)
            {
                var leadingIcon = await GenerateIconAsync(buttonOptions.LeadingIcon);
                buttonContent.InnerHtml.AppendHtml(leadingIcon);
            }

            // If the attribute icon-only is not set to true, we expect to put a span.
            if (!buttonOptions.IconOnly)
            {
                var spanButtonLabelTagBuilder = new TagBuilder("span");
                spanButtonLabelTagBuilder.AddCssClass("c-button__label");
                spanButtonLabelTagBuilder.InnerHtml.SetContent(buttonOptions.Label);
                buttonContent.InnerHtml.AppendHtml(spanButtonLabelTagBuilder);
            }

            // We cannot put a a trailing icon if IconOnly attribute is set to true.
            // Obviously a trailing icon needs to be set.
            if (buttonOptions.TrailingIcon != Icon.None && !buttonOptions.IconOnly)
            {
                var trailingIcon = await GenerateIconAsync(buttonOptions.TrailingIcon);
                buttonContent.InnerHtml.AppendHtml(trailingIcon);
            }

            // When creating a icon only icon last child of the container needs to a class with `u-sr-accessible` attribute.
            // See smart design documentation for more insight.
            if (buttonOptions.IconOnly)
            {
                var iconOnlyDiv = new TagBuilder("div");
                iconOnlyDiv.AddCssClass("u-sr-accessible");
                iconOnlyDiv.InnerHtml.SetContent(buttonOptions.Label);
            }

            button.InnerHtml.AppendHtml(buttonContent);

            return button;
        }

        private string ComputeButtonStyleCssClass(SmartButtonOptions options)
        {
            var style = options.Style;
            var cssClasses = style switch
            {
                ButtonStyle.Primary         => "c-button--primary",
                ButtonStyle.Secondary       => "c-button--secondary",
                ButtonStyle.Borderless      => "c-button--borderless",
                ButtonStyle.Danger          => "c-button--danger",
                ButtonStyle.DangerSecondary => "c-button--danger-secondary",
                _                           => throw new NotImplementedException($"Style undefined for style {style}")
            };

            if (options.IsLoading)
            {
                cssClasses = $" {cssClasses} c-button--loading";
            }

            return cssClasses;
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
