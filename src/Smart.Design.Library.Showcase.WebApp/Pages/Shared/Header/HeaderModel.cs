namespace Smart.Design.Library.Showcase.Pages.Shared;

public class HeaderModel
{
    public string HomePageUrl { get; set; }
    public Dictionary<string, string> LanguagesAndLinks { get; set; } = new Dictionary<string, string>();
    public string? TargetLanguage { get; set; }
    public string FullNameWithTrigram { get; set; } = null!;
    public string AvatarPath { get; set; } = "~/images/default_image.svg";
    public string LogoutLink { get; set; } = null!;
    public Dictionary<string, string> LabelsAndLinks { get; set; } = new Dictionary<string, string>();
}
