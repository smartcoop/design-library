using CommandLine;

namespace Smart.Design.Console.CommandOptions
{
    [Verb("list", HelpText = "Lists design elements")]
    public class ListingOptions
    {
        [Option('c', "category", Required = false, HelpText = "Category of design Elements")]
        public string DesignElementCategory { get; set; }
    }
}
