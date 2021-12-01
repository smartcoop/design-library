using CommandLine;

namespace Smart.Design.HtmlGenerator.CommandOptions
{
    [Verb("generate", HelpText = "Generates html for a specific design component")]
    public class GenerateOptions
    {
        [Option('n', "name", Required = true, HelpText = "Name of the design component")]
        public string DesignElementName { get; set; }
    }
}
