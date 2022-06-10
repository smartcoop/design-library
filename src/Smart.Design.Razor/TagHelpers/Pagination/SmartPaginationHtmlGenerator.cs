using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Smart.Design.Razor.TagHelpers.Icon;

namespace Smart.Design.Razor.TagHelpers.Pagination;

public class SmartPaginationHtmlGenerator : ISmartPaginationHtmlGenerator
{
    private readonly IIconHtmlGenerator _iconHtmlGenerator;

    private int _startIndex;
    private int _endIndex;
    private int _currentPageNumber;
    private int _numberOfLinks;
    private int _numberOfLinksAroundCurrentPageNumberLink;

    private PaginationSettings _settings = null!;

    public SmartPaginationHtmlGenerator(IIconHtmlGenerator iconHtmlGenerator)
    {
        _iconHtmlGenerator = iconHtmlGenerator;
    }

    public async Task<TagBuilder> GenerateSmartPaginationAsync(PaginationSettings settings)
    {
        _settings = settings ?? throw new ArgumentNullException(nameof(settings));
        EnsureSettings();
        ComputePaginationProperties();

        var navBar = BuildNavBar();
        var ulContainer = BuildUlContainer();

        ulContainer.InnerHtml.AppendHtml(await GetChevronLinkAsync(Image.ChevronLeft));

        for (var index = _startIndex; index <= _endIndex; index++)
        {
            ulContainer.InnerHtml.AppendHtml(MakePageLink(index));
        }

        ulContainer.InnerHtml.AppendHtml(await GetChevronLinkAsync(Image.ChevronRight));

        navBar.InnerHtml.AppendHtml(ulContainer);
        return navBar;
    }

    private void EnsureSettings()
    {
        if (_settings.NumberOfLinks < 1)
        {
            throw new InvalidOperationException("Number of links must be equal or greater than one");
        }

        if (string.IsNullOrWhiteSpace(_settings.PageNumberParameterName))
        {
            throw new InvalidOperationException("Query parameter name for the current page number is missing");
        }
    }

    private void ComputePaginationProperties()
    {
        PrepareData();
        ComputeNumberOfLinks();
        ComputeEndIndex();
        ComputeStartIndex();
    }

    private TagBuilder BuildUlContainer()
    {
        var ulContainer = new TagBuilder("ul");
        ulContainer.AddCssClass("c-pagination__nav");
        return ulContainer;
    }

    private static TagBuilder BuildNavBar()
    {
        var navBar = new TagBuilder("nav");
        navBar.AddCssClass("c-pagination");
        navBar.Attributes["aria-label"] = "Pagination";
        return navBar;
    }

    private TagBuilder MakePageLink(int index)
    {
        var pageLink = MakePaginationItem();
        pageLink.AddCssClass($"{(index == _settings.PageNumber ? "c-pagination__item--active" : string.Empty)}");

        var anchorPageLink = new TagBuilder("a");
        anchorPageLink.AddCssClass("c-pagination__link");
        anchorPageLink.Attributes["href"] = GetQueryString(index);
        anchorPageLink.InnerHtml.Append(index.ToString());

        pageLink.InnerHtml.AppendHtml(anchorPageLink);
        return pageLink;
    }

    private async Task<IHtmlContent> GetChevronLinkAsync(Image chevron)
    {
        var paginationItem = MakePaginationItem();
        var chevronLink = new TagBuilder("a");
        chevronLink.AddCssClass("c-button c-button--borderless c-button--icon");
        chevronLink.Attributes["href"] = GetQueryString(chevron == Image.ChevronLeft ? _currentPageNumber - 1 : _currentPageNumber + 1);

        if (chevron == Image.ChevronLeft && _currentPageNumber <= 1 || chevron == Image.ChevronRight && _currentPageNumber >= _settings.TotalPages)
        {
            chevronLink.Attributes["disabled"] = "disabled";
        }

        var span = new TagBuilder("span");
        span.AddCssClass("c-button__content");
        span.InnerHtml.AppendHtml(await _iconHtmlGenerator.GenerateIconAsync(chevron));

        chevronLink.InnerHtml.AppendHtml(span);
        paginationItem.InnerHtml.AppendHtml(chevronLink);

        return paginationItem;
    }

    private TagBuilder MakePaginationItem()
    {
        var paginationItem = new TagBuilder("li");
        paginationItem.AddCssClass("c-pagination__item");
        return paginationItem;
    }

    private string GetQueryString(int pageNumber)
    {
        return $"{_settings.Path!.TrimEnd('/')}?{_settings.PageNumberParameterName}={pageNumber}&{_settings.QueryString}";
    }

    private void PrepareData()
    {
        _settings.Path ??= string.Empty;
        SetCurrentPageInPossibleInterval();
    }

    private void SetCurrentPageInPossibleInterval()
    {
        _currentPageNumber = _settings.PageNumber < 1
            ? Math.Max(_settings.PageNumber, 1)
            : Math.Min(_settings.PageNumber, _settings.TotalPages);
    }

    private void ComputeNumberOfLinks()
    {
        // This makes sure to have the same number of links around the current page link.
        _numberOfLinks = _settings.NumberOfLinks % 2 == 0
            ? _settings.NumberOfLinks + 1
            : _settings.NumberOfLinks;

        _numberOfLinksAroundCurrentPageNumberLink = _numberOfLinks / 2;
    }

    private void ComputeEndIndex()
    {
        _endIndex = _settings.PageNumber <= _numberOfLinksAroundCurrentPageNumberLink
            ? _numberOfLinks
            : _currentPageNumber + _numberOfLinksAroundCurrentPageNumberLink;

        _endIndex = Math.Min(_endIndex, _settings.TotalPages);
    }

    private void ComputeStartIndex()
    {
        _startIndex = Math.Max(_endIndex - (_numberOfLinks + 1), 1);
    }
}
