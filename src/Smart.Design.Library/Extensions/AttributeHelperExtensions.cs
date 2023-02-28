using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Library.TagHelpers.Base;

namespace Smart.Design.Library.Extensions;

public static class AttributeHelperExtensions
{
    /// <summary>
    /// List All extra attributes which are not explicitly defined properties on the custom tag helper implementation
    /// </summary>
    /// <param name="obj">Instance of the tag helper (this)</param>
    /// <param name="context">Context of the tag helper</param>
    /// <typeparam name="T">Type of the tag helper</typeparam>
    /// <returns></returns>
    public static List<TagHelperAttribute> ListUndefinedTagHelperAttributes<T>(this T obj, TagHelperContext context) where T : BaseTagHelper
    {
        var type = typeof(T);
        var attributeObjects = context.AllAttributes.ToList();
        var properties = type.GetProperties().Select(p => p.Name.ToLower());
        attributeObjects.RemoveAll(a => properties.Contains(a.Name));
        return attributeObjects;
    }
}
