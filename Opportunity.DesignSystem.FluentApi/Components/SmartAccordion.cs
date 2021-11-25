using System;
using Definux.HtmlBuilder;

namespace Opportunity.DesignSystem.FluentApi.Components
{
    public static class Component
    {
        public static HtmlBuilder SmartAccordion(this HtmlBuilder builder, string title, string content)
        {
            try
            {
                builder.StartElement(HtmlTags.Div)
                    .WithClasses("c-accordion")
                    .Append(parent => parent.OpenElement(HtmlTags.Div)
                        .WithClasses("c-accordion__item")
                        .AddAccordionHeader(title)
                        .AddAccordionContent(content)
                    );
                return builder;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private static HtmlElement AddAccordionHeader(this HtmlElement el, string title)
        {
            return el.Append(element =>
                element.OpenElement(HtmlTags.Div).WithClasses("c-accordion__item-header")
                    .AddToolbar(title));
        }

        private static HtmlElement AddAccordionContent(this HtmlElement el, string content)
        {
            return el.Append(element =>
                element.OpenElement(HtmlTags.Div)
                    .WithClasses("c-accordion__item-content").Append(content));
        }

        private static HtmlElement AddToolbar(this HtmlElement el, string title)
        {
            return el.Append(element => element.OpenElement(HtmlTags.Div)
                .WithClasses("c-toolbar")
                .AddAccordionTitle(title)
                .AddRightToolBarItem()
                .AddLeftToolBarItem());
        }

        private static HtmlElement AddAccordionTitle(this HtmlElement el, string title)
        {
            return el.Append(element => element.OpenElement(HtmlTags.Span)
                .WithClasses("c-accordion__item-title")
                .Append(title));
        }

        private static HtmlElement AddLeftToolBarItem(this HtmlElement el)
        {
            return el.Append(element => element.OpenElement(HtmlTags.Div)
                .WithClasses("c-toolbar__left")
                .Append(toolbarEl => toolbarEl.OpenElement(HtmlTags.Button)
                    .WithClasses("c-button c-button--borderless c-button--icon")
                    .WithAttribute("type", "button")
                    .AddChevronRightImage()));
        }

        private static HtmlElement AddRightToolBarItem(this HtmlElement el)
        {
            return el.Append(element => element.OpenElement(HtmlTags.Div)
                .WithClasses("c-toolbar__right")
                .Append(toolbarEl => toolbarEl.OpenElement(HtmlTags.Button)
                    .WithClasses("c-button c-button--borderless c-button--icon")
                    .WithAttribute("type", "button")
                    .AddImage()));
        }

        private static HtmlElement AddChevronRightImage(this HtmlElement el)
        {
            return el.Append(element => element
                .OpenElement(HtmlTags.Span)
                .WithClasses("c_button__content")
                .Append(span => span.OpenElement(HtmlTags.Div)
                    .WithClasses("o-svg-icon o-svg-icon-chevron-right")
                    .Append(svg => svg.OpenElement(new HtmlTag("svg"))
                        .WithAttribute("width", "24")
                        .WithAttribute("height", "24")
                        .WithAttribute("viewBox", "0 0 24 24")
                        .WithAttribute("fill", "none")
                        .WithAttribute("xmlns", "http://www.w3.org/2000/svg")
                        .Append(path => path.OpenElement(new HtmlTag("path"))
                            .WithAttribute("fill", "#595959")
                            .WithAttribute("d",
                                "M9.29289 18.7071C8.90237 18.3166 8.90237 17.6834 9.29289 17.2929L14.5858 12L9.29289 6.70711C8.90237 6.31658 8.90237 5.68342 9.29289 5.29289C9.68342 4.90237 10.3166 4.90237 10.7071 5.29289L16.7071 11.2929C17.0976 11.6834 17.0976 12.3166 16.7071 12.7071L10.7071 18.7071C10.3166 19.0976 9.68342 19.0976 9.29289 18.7071Z")))));
        }

        private static HtmlElement AddImage(this HtmlElement el)
        {
            return el.Append(element => element
                .OpenElement(HtmlTags.Span)
                .WithClasses("c_button__content")
                .Append(span => span.OpenElement(HtmlTags.Div)
                    .WithClasses("o-svg-icon o-svg-icon-add")
                    .Append(svg => svg.OpenElement(new HtmlTag("svg"))
                        .WithAttribute("width", "24")
                        .WithAttribute("height", "24")
                        .WithAttribute("viewBox", "0 0 24 24")
                        .WithAttribute("fill", "none")
                        .WithAttribute("xmlns", "http://www.w3.org/2000/svg")
                        .Append(path => path.OpenElement(new HtmlTag("path"))
                            .WithAttribute("fill", "#595959")
                            .WithAttribute("d",
                                "M9.29289 18.7071C8.90237 18.3166 8.90237 17.6834 9.29289 17.2929L14.5858 12L9.29289 6.70711C8.90237 6.31658 8.90237 5.68342 9.29289 5.29289C9.68342 4.90237 10.3166 4.90237 10.7071 5.29289L16.7071 11.2929C17.0976 11.6834 17.0976 12.3166 16.7071 12.7071L10.7071 18.7071C10.3166 19.0976 9.68342 19.0976 9.29289 18.7071Z")))));
        }
    }
}
