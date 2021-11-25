using System;
using System.CommandLine;
using Opportunity.DesignSystem.Console.CommandOptions;
using Opportunity.DesignSystem.Console.Models;
using Opportunity.DesignSystem.RazorView;

namespace Opportunity.DesignSystem.Console.UseCases
{
    /// <summary>
    ///     Listing of available Components
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
}
