using CommandLine;

namespace Smart.Design.HtmlGenerator.CommandOptions;

[Verb("list", HelpText = "Lists design components")]
public class ListingOptions
{
    [Option('c', "category", Required = false, HelpText = "Category of design components")]
    public string DesignElementCategory { get; set; }
}