using Microsoft.Extensions.DependencyInjection;
using Smart.Design.Razor.TagHelpers.Alert;
using Smart.Design.Razor.TagHelpers.AlertStack;
using Smart.Design.Razor.TagHelpers.Avatar;
using Smart.Design.Razor.TagHelpers.Badge;
using Smart.Design.Razor.TagHelpers.Base;
using Smart.Design.Razor.TagHelpers.ButtonToolbar;
using Smart.Design.Razor.TagHelpers.Card;
using Smart.Design.Razor.TagHelpers.Citation;
using Smart.Design.Razor.TagHelpers.Container;
using Smart.Design.Razor.TagHelpers.Elements.Checkbox;
using Smart.Design.Razor.TagHelpers.Elements.HorizontalRule;
using Smart.Design.Razor.TagHelpers.Elements.Input;
using Smart.Design.Razor.TagHelpers.Elements.Radio;
using Smart.Design.Razor.TagHelpers.Elements.Textarea;
using Smart.Design.Razor.TagHelpers.Elevation;
using Smart.Design.Razor.TagHelpers.Form;
using Smart.Design.Razor.TagHelpers.GlobalBanner;
using Smart.Design.Razor.TagHelpers.Grid;
using Smart.Design.Razor.TagHelpers.GridList;
using Smart.Design.Razor.TagHelpers.Icon;
using Smart.Design.Razor.TagHelpers.IconList;
using Smart.Design.Razor.TagHelpers.InputGroup;
using Smart.Design.Razor.TagHelpers.KeyValueList;
using Smart.Design.Razor.TagHelpers.Layout;
using Smart.Design.Razor.TagHelpers.Layout.TagHelpers;
using Smart.Design.Razor.TagHelpers.Loader;
using Smart.Design.Razor.TagHelpers.MutedText;
using Smart.Design.Razor.TagHelpers.Pagination;
using Smart.Design.Razor.TagHelpers.Panel;
using Smart.Design.Razor.TagHelpers.Pill;
using Smart.Design.Razor.TagHelpers.ProgressBar;
using Smart.Design.Razor.TagHelpers.Spacer;
using Smart.Design.Razor.TagHelpers.TableOfContent;
using Smart.Design.Razor.TagHelpers.Tabs;
using Smart.Design.Razor.TagHelpers.ValidationMessage;

namespace Smart.Design.Razor.Extensions;

public static class DependencyRegistration
{
    public static IServiceCollection AddSmartDesign(this IServiceCollection services)
    {
        return services
            .AddTransient<IAlertStackHtmlGenerator, AlertStackHtmlGenerator>()
            .AddTransient<IAvatarHtmlGenerator, AvatarHtmlGenerator>()
            .AddTransient<IBadgeHtmlGenerator, BadgeHtmlGenerator>()
            .AddTransient<IContainerHtmlGenerator, ContainerHtmlGenerator>()
            .AddTransient<IInputHtmlGenerator, InputHtmlGenerator>()
            .AddTransient<IElevationHtmlGenerator, ElevationHtmlGenerator>()
            .AddTransient<IFormHtmlGenerator, FormHtmlGenerator>()
            .AddTransient<IGlobalBannerHtmlGenerator, GlobalBannerHtmlGenerator>()
            .AddTransient<IGridHtmlGenerator, GridHtmlGenerator>()
            .AddTransient<IIconHtmlGenerator, IconHtmlGenerator>()
            .AddTransient<IIconListHtmlGenerator, IconListHtmlGenerator>()
            .AddTransient<IInputGroupHtmlGenerator, InputGroupHtmlGenerator>()
            .AddTransient<ILoaderHtmlGenerator, LoaderHtmlGenerator>()
            .AddTransient<IPanelHtmlGenerator, PanelHtmlGenerator>()
            .AddTransient<ITabsHtmlGenerator, TabsHtmlGenerator>()
            .AddTransient<IButtonToolbarHtmlGenerator, ButtonToolbarHtmlGenerator>()
            .AddTransient<ITextareaHtmlGenerator, TextareaHtmlGenerator>()
            .AddTransient<IRadioHtmlGenerator, RadioHtmlGenerator>()
            .AddTransient<IHorizontalRuleHtmlGenerator, HorizontalRuleHtmlGenerator>()
            .AddTransient<IFormGroupHtmlGenerator, FormGroupHtmlGenerator>()
            .AddTransient<ICheckboxHtmlGenerator, CheckboxHtmlGenerator>()
            .AddTransient<IProgressBarHtmlGenerator, ProgressBarHtmlGenerator>()
            .AddTransient<IPillHtmlGenerator, PillHtmlHtmlGenerator>()
            .AddTransient<ICardHtmlGenerator, CardHtmlGenerator>()
            .AddTransient<IValidationMessageHtmlGenerator, ValidationMessageHtmlGenerator>()
            .AddTransient<IKeyValueListHtmlGenerator, KeyValueListHtmlGenerator>()
            .AddTransient<IMutedTextHtmlGenerator, MutedTextHtmlGenerator>()
            .AddTransient<ISpacerHtmlGenerator, SpacerHtmlGenerator>()
            .AddTransient<IHtmlLayoutGenerator, HtmlLayoutGenerator>()
            .AddTransient<IAlertHtmlGenerator, AlertHtmlGenerator>()
            .AddTransient<ISmartPaginationHtmlGenerator, SmartPaginationHtmlGenerator>()
            .AddTransient<IGridListHeaderGenerator, GridListHeaderGenerator>()
            .AddTransient<ITableOfContentGenerator, TableOfContentGenerator>()
            .AddTransient<ICitationGenerator, CitationGenerator>();
    }
}
