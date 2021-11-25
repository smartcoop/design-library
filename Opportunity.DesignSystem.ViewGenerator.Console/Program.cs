using System.IO;
using System.Text;
using Opportunity.DesignSystem.RazorView;


CustomTagHelperCollections customTagHelperCollections = new();
var directoyFileDestination = Path.GetFullPath(@"..\..\..\..\Opportunity.DesignSystem.RazorView\Views");
foreach (var componentName in customTagHelperCollections.Names)
{
    StringBuilder viewContentStringBuilder = new StringBuilder($"<{componentName}>")
        .AppendLine($"</{componentName}>");
    File.WriteAllText(Path.Combine(directoyFileDestination, componentName + ".cshtml"), viewContentStringBuilder.ToString());
}
