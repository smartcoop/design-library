namespace Smart.Design.Console.Generator;

public class Settings
{
    public const string Section = "Settings";

    public string MissingComponentFileName { get; set; } = "missing_components.txt";
    public DesignShowcase DesignShowcase { get; set; } = new();
    public DesignLibrary DesignLibrary { get; set; } = new();
}

public class DesignShowcase
{
    public string ComponentListFileName { get; set; } = "_ComponentList.cshtml";
    public DirectoryPath DirectoryPath { get; set; }
    public Template Template { get; set; }
}

public class DirectoryPath
{
    public string RootDirectory { get; set; } = "../../../..";
    public string PageDirectory { get; set; } = "design-library-showcase/Smart.Design.Showcase.WebApp/Pages";
    public string ComponentDirectory { get; set; } = "Components";
    public string SharedDirectory { get; set; } = "Shared";
}

public class Template
{
    public string CodeFileName { get; set; } = "Template.cshtml.cs";
    public string ViewFileName { get; set; } = "Template.cshtml";
}

public class DesignLibrary
{
    public string RootDirectory { get; set; } = "../../../..";
    public string ComponentPath { get; set; } = "design-cs/src/Smart.Design.Razor/TagHelpers";
}
