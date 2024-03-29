using System.Collections.Generic;
using System.Linq;
using Smart.Design.HtmlGenerator.Extensions;
using Smart.Design.Library.TagHelpers.Constants;

namespace Smart.Design.HtmlGenerator.Managers;

public class ComponentDiscoverer : IComponentDiscoverer
{
    /// <summary>
    /// Returns a collection of the Smart design components implemented with Tag Helpers in Smart.Design.Library library.
    /// </summary>
    /// <returns>A list of Tag Helpers rendering Smart design components</returns>
    public List<string> GetAllTagHelperNames()
    {
        var tagHelperNames = typeof(TagNames).GetConstantValues<string>();

        return tagHelperNames.ToList();
    }
}
