using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Smart.Design.Razor.Enums;
using Smart.Design.Razor.TagHelpers.Html;

namespace Smart.Design.Razor.TagHelpers.IconList
{
    public class SmartIconListHtmlGenerator : ISmartIconListHtmlGenerator
    {
        private readonly ISmartHtmlGenerator _smartHtmlGenerator;

        public SmartIconListHtmlGenerator(ISmartHtmlGenerator smartHtmlGenerator)
        {
            _smartHtmlGenerator = smartHtmlGenerator;
        }

        /// <inheritdoc />
        public TagBuilder GenerateIconList()
        {
            var iconList = new TagBuilder("ul");
            iconList.AddCssClass("c-icon-list");

            return iconList;
        }

        /// <inheritdoc />
        public TagBuilder GenerateIconListItem(Icon icon, string label)
        {
            // An smart design icon item has an icon and a label.
            var li = new TagBuilder("li");
            li.AddCssClass("c-icon-list__item");

            var htmlIcon = _smartHtmlGenerator.GenerateIcon(icon);
            li.InnerHtml.AppendHtml(htmlIcon);

            var messageSpan = new TagBuilder("span");
            messageSpan.InnerHtml.SetContent(label);
            li.InnerHtml.AppendHtml(messageSpan);

            return li;
        }
    }
}
