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

            if (items != null)
            {
                var noOptionTagBuilder = new TagBuilder("option");
                noOptionTagBuilder.InnerHtml.AppendHtml("Choisir une valeur");
                selectTagBuilder.InnerHtml.AppendHtml(noOptionTagBuilder);
                foreach (var item in items)
                {
                    var optionTagBuilder = new TagBuilder("option");
                    optionTagBuilder.Attributes.Add("value", item.Value);
                    optionTagBuilder.InnerHtml.AppendHtml(item.Key);
                    selectTagBuilder.InnerHtml.AppendHtml(optionTagBuilder);
                }
            }


            // If there are any errors for a named field, we add the CSS attribute.
            if (!string.IsNullOrWhiteSpace(selectName) && viewContext?.HasModelStateErrorsByKey(selectName) is true)
            {
                selectTagBuilder.AddCssClass("c-input--error");
            }

            divSelectTagBuilder.InnerHtml.AppendHtml(selectTagBuilder);

            return divSelectTagBuilder;
        }
    }
}
