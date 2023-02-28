using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using HtmlBuilders;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Smart.Design.Console.Generator;

public class SmartPanelGenerator
{
    private readonly ILogger<SmartPanelGenerator> _logger;
    public string RepositoryDirectory { get; }

    public string ComponentDirectory { get; }

    public string TagHelperDirectory { get; }

    public string PageDirectory { get; }

    public string SharedDirectory { get; }

    public Settings settings { get; }

    public SmartPanelGenerator(ILogger<SmartPanelGenerator> logger, IOptions<Settings> settingsOptions)
    {
        _logger = logger;
        settings = settingsOptions.Value;
        RepositoryDirectory = settings.DesignShowcase.DirectoryPath.RootDirectory;
        PageDirectory = Path.Combine(RepositoryDirectory, settings.DesignShowcase.DirectoryPath.PageDirectory);
        ComponentDirectory = Path.Combine(PageDirectory, settings.DesignShowcase.DirectoryPath.ComponentDirectory);
        SharedDirectory = Path.Combine(PageDirectory, settings.DesignShowcase.DirectoryPath.SharedDirectory);
        TagHelperDirectory = Path.Combine(settings.DesignLibrary.RootDirectory, settings.DesignLibrary.ComponentPath);
    }

    public void Generate()
    {
        var fileNamesFromLibrary = GetTotalComponentNameList();
        var fileNamesFromShowcase = GetImplementedComponentNameList();
        var uncreatedFileComponents = fileNamesFromLibrary.Where(file => fileNamesFromShowcase.All(tmp => tmp != file));

        _logger.LogInformation("Creating the files for the components");
        GenerateComponentFiles(uncreatedFileComponents);

        _logger.LogInformation("Creating flat file text for missing components (defaulted to templated file)");
        GenerateMissingComponentsFile(uncreatedFileComponents);

        _logger.LogInformation("Update side panel info");
        ReGenerateSidePanel(fileNamesFromLibrary);
    }

    /// <summary>
    /// Generate a file with all the missing components
    /// </summary>
    /// <param name="uncreatedFileComponents"></param>
    private void GenerateMissingComponentsFile(IEnumerable<string> uncreatedFileComponents)
    {
        var errorFile = Path.Combine(PageDirectory, settings.MissingComponentFileName);
        uncreatedFileComponents = uncreatedFileComponents.Prepend("Missing Components:");
        if (File.Exists(errorFile))
        {
            File.Delete(errorFile);
        }

        File.AppendAllLines(errorFile, uncreatedFileComponents);
    }

    /// <summary>
    /// Generate the different items of the side panel of the design showcase, taking for reference the list of all components created in the Design Library.
    /// </summary>
    /// <param name="fileNamesFromLibrary"></param>
    private void ReGenerateSidePanel(List<string> fileNamesFromLibrary)
    {
        var stringBuilder = new StringBuilder();
        fileNamesFromLibrary.ForEach(file => stringBuilder.AppendLine(WebUtility.HtmlDecode(HtmlTags
            .Li
            .Class($"c-styleguide-list__item @IsActive(\"{file}\")")
            .Append(HtmlTags.A.Attribute("asp-page", $"../{file}/{file}").Append(GetCleanedUpListOfFileNames(file)))
            .ToHtmlString())));

        var componentListPath = Path.Combine(SharedDirectory, settings.DesignShowcase.ComponentListFileName);
        var componentListContentLines = File.ReadAllLines(componentListPath);
        var newText = new StringBuilder();
        foreach (var line in componentListContentLines)
        {
            if (line.Contains("To_Replace"))
            {
                newText.AppendLine(stringBuilder.ToString());
                continue;
            }

            newText.AppendLine(line);
        }

        File.WriteAllText(componentListPath, newText.ToString());
    }

    /// <summary>
    /// Generate a templated file per components in the design library which have not yet been created in the design showcase.
    /// </summary>
    /// <param name="uncreatedFileComponents"></param>
    private void GenerateComponentFiles(IEnumerable<string> uncreatedFileComponents)
    {
        var templateFileViewContent = File.ReadAllText(Path.Combine(ComponentDirectory, settings.DesignShowcase.Template.ViewFileName));
        var templatedCode = File.ReadAllText(Path.Combine(ComponentDirectory, settings.DesignShowcase.Template.CodeFileName));

        foreach (var file in uncreatedFileComponents)
        {
            var directoryPath = Path.Combine(ComponentDirectory, file);
            Directory.CreateDirectory(directoryPath);
            var templatedFileViewContent = templateFileViewContent
                .Replace("Replace_Title", GetCleanedUpListOfFileNames(file))
                .Replace("Template", file);
            var filePath = Path.Combine(directoryPath, file);
            File.WriteAllText($"{filePath}.cshtml", templatedFileViewContent);

            var newCode = templatedCode.Replace("Template", file);
            File.WriteAllText(Path.Combine(ComponentDirectory, file, $"{file}.cshtml.cs"), newCode);
        }
    }

    /// <summary>
    /// Get a complete list of the components which have already been implemented in the design showcase.
    /// </summary>
    /// <returns></returns>
    private List<string> GetImplementedComponentNameList()
    {
        var files = Directory.GetDirectories(ComponentDirectory).ToList();
        return files.Select(Path.GetFileNameWithoutExtension).ToList()!;
    }

    /// <summary>
    /// Get a list of all the component names which exists in the design library.
    /// </summary>
    /// <returns></returns>
    private List<string> GetTotalComponentNameList()
    {
        // Get all files in TagHelpers folder
        var files = Directory.GetFiles(TagHelperDirectory, "*.*", SearchOption.AllDirectories).ToList();

        // Regex filtering on all file names ending in TagHelper
        var tagHelperFileNames = new List<string>();
        var regex = new Regex("(.*)(TagHelper)$");
        files.ForEach(file =>
        {
            var fileName = Path.GetFileNameWithoutExtension(file);
            if (regex.IsMatch(fileName))
            {
                fileName = regex.Replace(fileName, test => test.Groups[1].Value);
                tagHelperFileNames.Add(fileName);
            }
        });

        tagHelperFileNames.Sort();

        return tagHelperFileNames;
    }

    /// <summary>
    /// Convert Pascal case in Uppercase on first letter and whitespace separated string
    /// </summary>
    /// <param name="fileName">A pascal case tagHelper's name</param>
    /// <returns></returns>
    private string GetCleanedUpListOfFileNames(string fileName)
    {
        fileName = Regex.Replace(fileName, "(\\B[A-Z])", " $1");
        fileName = fileName.ToLower();
        return char.ToUpper(fileName[0]) + fileName[1..];
    }
}
