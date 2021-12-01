using CommandLine;

namespace Smart.Design.HtmlGenerator.CommandOptions
{
    [Verb("list", HelpText = "Lists design elements")]
    public class ListingOptions
    {
        [Option('c', "category", Required = false, HelpText = "Category of design elements")]
        public string DesignElementCategory { get; set; }
    }
}
