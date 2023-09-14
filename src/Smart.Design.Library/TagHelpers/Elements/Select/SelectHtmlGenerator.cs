using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Smart.Design.Library.TagHelpers.Base;
using Smart.Design.Library.TagHelpers.Extensions;

namespace Smart.Design.Library.TagHelpers.Elements.Select
{
    public class SelectHtmlGenerator : BaseHtmlGenerator, ISelectHtmlGenerator
    {
        public TagBuilder GenerateSelect(
            ViewContext? viewContext,
            string? id,
            string? name,
            string? defaultValueLabel,
            bool? required,
            Dictionary<string, string>? items,
            ModelExpression? @for)
        {
            if (viewContext is null)
            {
                throw new ArgumentNullException(nameof(viewContext), "A ViewContext must be supplied");
            }

            var divSelectTagBuilder = new TagBuilder("div");
            divSelectTagBuilder.AddCssClass("c-select-holder");

            var selectTagBuilder = new TagBuilder("select");
            selectTagBuilder.AddCssClass("c-select");

            var selectName = GetAttributeName(name, @for);

            if (!string.IsNullOrWhiteSpace(id))
            {
                selectTagBuilder.Attributes["id"] = id;
            }

            if (!string.IsNullOrWhiteSpace(selectName))
            {
                selectTagBuilder.Attributes["name"] = selectName;
            }

            if (required == true)
            {
                selectTagBuilder.Attributes.Add("required", "true");
            }

            if (items != null)
            {
                var defaultLabel = defaultValueLabel != null ? defaultValueLabel : "Choisir une valeur";
                var noOptionTagBuilder = new TagBuilder("option");
                noOptionTagBuilder.InnerHtml.AppendHtml(defaultLabel);
                noOptionTagBuilder.Attributes.Add("disabled", "true");
                noOptionTagBuilder.Attributes.Add("selected", "true");
                selectTagBuilder.InnerHtml.AppendHtml(noOptionTagBuilder);
                foreach (var item in items)
                {
                    var optionTagBuilder = new TagBuilder("option");
                    optionTagBuilder.Attributes.Add("value", item.Value);
                    optionTagBuilder.InnerHtml.AppendHtml(item.Key);

                    // Check if the current option should be selected based on the model's value
                    if (@for != null && @for.Model != null && item.Value == @for.Model.ToString())
                    {
                        optionTagBuilder.Attributes.Add("selected", "true");
                    }

                    selectTagBuilder.InnerHtml.AppendHtml(optionTagBuilder);
                }
            }


            // If there are any errors for a named field, we add the CSS attribute.
            if (!string.IsNullOrWhiteSpace(selectName) && viewContext?.HasModelStateErrorsByKey(selectName) is true)
            {
                selectTagBuilder.AddCssClass("c-select--error");
            }

            divSelectTagBuilder.InnerHtml.AppendHtml(selectTagBuilder);

            return divSelectTagBuilder;
        }
    }
}
