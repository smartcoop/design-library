using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using CaseExtensions;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
namespace Smart.Design.Razor.TagHelpers.Html
{
    public class SmartHtmlGenerator : ISmartHtmlGenerator
    {
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

        private string GetAttributeName(string name, ModelExpression modelExpression)
        {
            return !string.IsNullOrWhiteSpace(modelExpression?.Name) ? modelExpression.Name : name;
        }
    }
}
