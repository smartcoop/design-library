using System.IO;
using System.Text;
using Smart.Design.RazorView;


CustomTagHelperCollections customTagHelperCollections = new();
var directoyFileDestination = Path.GetFullPath(@"..\..\..\..\Smart.Design.RazorView\Views");
foreach (var componentName in customTagHelperCollections.Names)
{
    StringBuilder viewContentStringBuilder = new StringBuilder($"<{componentName}>")
        .AppendLine($"</{componentName}>");
    File.WriteAllText(Path.Combine(directoyFileDestination, componentName + ".cshtml"), viewContentStringBuilder.ToString());
}
