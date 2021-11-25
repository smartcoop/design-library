using System.IO;
using Definux.HtmlBuilder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting.Internal;
using Smart.Design.Razor.TagHelpers.Html;
using ViewRenderer.Core;

namespace Smart.Presentation.Mvc
{
    public static class StartupDependencies
    {
        public static IServiceCollection Configure(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ISmartHtmlGenerator, SmartHtmlGenerator>();
            serviceCollection.AddScoped< HtmlBuilder >();
            return serviceCollection;
        }
    }
}