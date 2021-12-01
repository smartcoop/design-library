using System;
using Smart.Design.HtmlGenerator.CommandOptions;
using Smart.Design.HtmlGenerator.Models;
using Smart.Design.RazorView;

namespace Smart.Design.HtmlGenerator.UseCases;

/// <summary>
/// Listing of available design elements
/// </summary>
public class ListingUseCase
{
    private readonly ListingOptions _options;

    /// <summary>
    /// </summary>
    /// <param name="options"></param>
    public ListingUseCase(ListingOptions options)
    {
        _options = options;
    }

    public CommandResponse Run()
    {
        CommandResponse response = new();
        try
        {
            var customTagHelperNames = new CustomTagHelperCollections().Names;
            response.SetSuccessMessage(string.IsNullOrWhiteSpace(_options.DesignElementCategory)
                ? string.Join('\n', customTagHelperNames)
                : $"list all of category {_options.DesignElementCategory}");
        }
        catch (Exception e)
        {
            response.AddError(e);
        }

        return response;
    }
}
