using System;
using Smart.Application.Console.Options;

namespace Smart.Application.Console
{
    /// <summary>
    /// Listing of available Components
    /// </summary>
    public class ListingUseCase
    {
        private readonly ListOptions _options;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        public ListingUseCase( ListOptions options )
        {
            _options = options;
        }

        public string Run()
        {
            return string.IsNullOrWhiteSpace( _options.DesignElementCategory ) ? string.Join( '\n', ListingHelper.Run() ) : $"list all of category {_options.DesignElementCategory}";
        }
    }
}
