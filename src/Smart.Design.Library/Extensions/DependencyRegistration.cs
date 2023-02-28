using Microsoft.Extensions.DependencyInjection;
using Smart.Design.Library.TagHelpers.Alert;
using Smart.Design.Library.TagHelpers.AlertStack;
using Smart.Design.Library.TagHelpers.Avatar;
using Smart.Design.Library.TagHelpers.Badge;
using Smart.Design.Library.TagHelpers.Base;
using Smart.Design.Library.TagHelpers.Buttons.ButtonBackToTop;
using Smart.Design.Library.TagHelpers.Buttons.ButtonToolbar;
using Smart.Design.Library.TagHelpers.Card;
using Smart.Design.Library.TagHelpers.Citation;
using Smart.Design.Library.TagHelpers.Container;
using Smart.Design.Library.TagHelpers.Elements.Checkbox;
using Smart.Design.Library.TagHelpers.Elements.HorizontalRule;
using Smart.Design.Library.TagHelpers.Elements.Input;
using Smart.Design.Library.TagHelpers.Elements.Radio;
using Smart.Design.Library.TagHelpers.Elements.Textarea;
using Smart.Design.Library.TagHelpers.Elevation;
using Smart.Design.Library.TagHelpers.Form;
using Smart.Design.Library.TagHelpers.GlobalBanner;
using Smart.Design.Library.TagHelpers.Grid;
using Smart.Design.Library.TagHelpers.GridList;
using Smart.Design.Library.TagHelpers.Header;
using Smart.Design.Library.TagHelpers.Icon;
using Smart.Design.Library.TagHelpers.IconList;
using Smart.Design.Library.TagHelpers.InputGroup;
using Smart.Design.Library.TagHelpers.KeyValueList;
using Smart.Design.Library.TagHelpers.Layout;
using Smart.Design.Library.TagHelpers.Layout.TagHelpers;
using Smart.Design.Library.TagHelpers.Loader;
using Smart.Design.Library.TagHelpers.MutedText;
using Smart.Design.Library.TagHelpers.Pagination;
using Smart.Design.Library.TagHelpers.Panel;
using Smart.Design.Library.TagHelpers.Pill;
using Smart.Design.Library.TagHelpers.ProgressBar;
using Smart.Design.Library.TagHelpers.SideMenu;
using Smart.Design.Library.TagHelpers.Spacer;
using Smart.Design.Library.TagHelpers.TableOfContent;
using Smart.Design.Library.TagHelpers.Tabs;
using Smart.Design.Library.TagHelpers.ValidationMessage;

namespace Smart.Design.Library.Extensions;

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
            .AddTransient<IGridListHeaderHtmlGenerator, GridListHeaderHtmlGenerator>()
            .AddTransient<ITableOfContentHtmlGenerator, TableOfContentHtmlGenerator>()
            .AddTransient<ICitationHtmlGenerator, CitationHtmlGenerator>()
            .AddTransient<IButtonBackToTopHtmlGenerator, ButtonBackToTopHtmlGenerator>()
            .AddTransient<ISideMenuHtmlGenerator, SideMenuHtmlGenerator>()
            .AddTransient<IHeaderHtmlGenerator, HeaderHtmlGenerator>();
    }
}
