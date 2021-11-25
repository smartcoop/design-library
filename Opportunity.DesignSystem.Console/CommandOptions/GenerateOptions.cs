using CommandLine;

namespace Opportunity.DesignSystem.Console.CommandOptions
{
    [Verb("generate", HelpText = "Generates html for a specific design element")]
    public class GenerateOptions
    {
        [Option('n', "name", Required = true, HelpText = "Name of the design element")]
        public string DesignElementName { get; set; }
    }
}
