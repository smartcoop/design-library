using System;
using System.CommandLine;
using Opportunity.DesignSystem.Console.Models;
using Opportunity.DesignSystem.Console.Options;

namespace Opportunity.DesignSystem.Console.UseCases
{
    /// <summary>
    ///     Listing of available Components
    /// </summary>
    public class ListingUseCase
    {
        private readonly ListOptions _options;

        /// <summary>
        /// </summary>
        /// <param name="options"></param>
        public ListingUseCase(ListOptions options)
        {
            _options = options;
        }

        public CommandResponse Run()
        {
            CommandResponse response = new();
            try
            {
                var customTagHelperNames = new CustomTagHelperCollections().Names;
                var componentNameListing = string.IsNullOrWhiteSpace(_options.DesignElementCategory)
                    ? string.Join('\n', customTagHelperNames)
                    : $"list all of category {_options.DesignElementCategory}";
            }
            catch (Exception e)
            {
                response.AddError(e);
            }

            return response;
        }
    }
}
