using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Smart.Design.Library.TagHelpers.Image;

namespace Smart.Design.Library.TagHelpers.Pagination;

/// <inheritdoc cref="ISmartPaginationHtmlGenerator"/>
public class SmartPaginationHtmlGenerator : ISmartPaginationHtmlGenerator
{
    private readonly IImageHtmlGenerator _imageHtmlGenerator;

    private int _startPageNumber;
    private int _endPageNumber;
    private int _currentPageNumber;
    private int _numberOfLinks;
    private int _numberOfLinksAroundCurrentPageNumberLink;

    private PaginationSettings _settings = null!;

    /// <summary>
    /// Instantiate a <see cref="SmartPaginationHtmlGenerator"/>.
    /// </summary>
    /// <param name="imageHtmlGenerator">The service which serves images as svg html tag.</param>
    public SmartPaginationHtmlGenerator(IImageHtmlGenerator imageHtmlGenerator)
    {
        _imageHtmlGenerator = imageHtmlGenerator;
    }

    /// <inheritdoc />
    public async Task<TagBuilder> GenerateSmartPaginationAsync(PaginationSettings settings)
    {
        _settings = settings ?? throw new ArgumentNullException(nameof(settings));
        EnsureSettings();
        ComputePaginationValues();

        var navBar = BuildNavBar();
        var ulContainer = BuildUlContainer();

        ulContainer.InnerHtml.AppendHtml(await GetChevronLinkAsync(Image.Image.ChevronLeft));

        for (var pageNumber = _startPageNumber; pageNumber <= _endPageNumber; pageNumber++)
        {
            ulContainer.InnerHtml.AppendHtml(GeneratePageLink(pageNumber));
        }

        ulContainer.InnerHtml.AppendHtml(await GetChevronLinkAsync(Image.Image.ChevronRight));

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

    private void ComputePaginationValues()
    {
        ComputePath();
        ComputeCurrentPageNumber();
        ComputeNumberOfLinks();
        ComputeEndPageNumber();
        ComputeStartPageNumber();
    }

    private void ComputePath()
    {
        _settings.Path ??= string.Empty;
    }

    private void ComputeCurrentPageNumber()
    {
        _currentPageNumber = _settings.PageNumber < 1
            ? 1
            : Math.Min(_settings.PageNumber, _settings.TotalPages);
    }

    private void ComputeNumberOfLinks()
    {
        // This makes sure to have the same number of links around the current page link.
        // Example: [4] [5] [6] [7] [8] [9] [10]. [7] being the current page number.
        _numberOfLinks = _settings.NumberOfLinks % 2 == 0
            ? _settings.NumberOfLinks + 1
            : _settings.NumberOfLinks;

        _numberOfLinksAroundCurrentPageNumberLink = _numberOfLinks / 2;
    }
    private void ComputeEndPageNumber()
    {
        _endPageNumber = _settings.PageNumber <= _numberOfLinksAroundCurrentPageNumberLink
            ? _numberOfLinks
            : _currentPageNumber + _numberOfLinksAroundCurrentPageNumberLink;

        _endPageNumber = Math.Min(_endPageNumber, _settings.TotalPages);
    }

    private void ComputeStartPageNumber()
    {
        _startPageNumber = Math.Max(_endPageNumber - (_numberOfLinks + 1), 1);
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

    private TagBuilder GeneratePageLink(int pageNumber)
    {
        var pageLink = MakePaginationItem();
        pageLink.AddCssClass($"{(pageNumber == _settings.PageNumber ? "c-pagination__item--active" : string.Empty)}");

        var anchorPageLink = new TagBuilder("a");
        anchorPageLink.AddCssClass("c-pagination__link");
        anchorPageLink.Attributes["href"] = GetQueryString(pageNumber);
        anchorPageLink.InnerHtml.Append(pageNumber.ToString());

        pageLink.InnerHtml.AppendHtml(anchorPageLink);
        return pageLink;
    }

    private async Task<IHtmlContent> GetChevronLinkAsync(Image.Image chevron)
    {
        var paginationItem = MakePaginationItem();
        var chevronLink = new TagBuilder("a");
        chevronLink.AddCssClass("c-button c-button--borderless c-button--icon");
        chevronLink.Attributes["href"] = GetQueryString(chevron == Image.Image.ChevronLeft ? _currentPageNumber - 1 : _currentPageNumber + 1);

        if (chevron == Image.Image.ChevronLeft && _currentPageNumber <= 1 || chevron == Image.Image.ChevronRight && _currentPageNumber >= _settings.TotalPages)
        {
            chevronLink.Attributes["disabled"] = "disabled";
        }

        var span = new TagBuilder("span");
        span.AddCssClass("c-button__content");
        span.InnerHtml.AppendHtml(await _imageHtmlGenerator.GenerateIconAsync(chevron));

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
}
