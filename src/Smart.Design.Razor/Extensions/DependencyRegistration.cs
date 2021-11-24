using Microsoft.Extensions.DependencyInjection;
using Smart.Design.Razor.TagHelpers.Html;
using Smart.Design.Razor.TagHelpers.IconList;
using Smart.Design.Razor.TagHelpers.ProgressBar;

namespace Smart.Design.Razor.Extensions
{
    public static class DependencyRegistration
    {
        public static IServiceCollection AddSmartDesign(this IServiceCollection services)
        {
            return services
                .AddTransient<ISmartHtmlGenerator, SmartHtmlGenerator>()
                .AddTransient<IProgressBarHtmlGenerator, ProgressBarHtmlGenerator>()
                .AddTransient<ISmartIconListHtmlGenerator, SmartIconListHtmlGenerator>();
        }
    }
}
