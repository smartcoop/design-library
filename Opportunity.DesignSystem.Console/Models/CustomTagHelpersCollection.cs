using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Smart.Design.Razor.TagHelpers.Constants;

namespace Opportunity.DesignSystem.Console.Models
{
    /// <summary>
    /// </summary>
    public class CustomTagHelperCollections
    {
        public IEnumerable<string> Names => GetNamesFromTypeByReflection(typeof(TagNames)).ToList()
            .Select(v => v.GetRawConstantValue() as string).ToList();

        private IEnumerable<FieldInfo> GetNamesFromTypeByReflection(Type type)
        {
            var constants = new ArrayList();

            var fieldInfos = type.GetFields(
                BindingFlags.Public | BindingFlags.Static |
                BindingFlags.FlattenHierarchy);

            foreach (var fi in fieldInfos)
                if (fi.IsLiteral && !fi.IsInitOnly)
                    constants.Add(fi);

            return (FieldInfo[]) constants.ToArray(typeof(FieldInfo));
        }
    }
}
