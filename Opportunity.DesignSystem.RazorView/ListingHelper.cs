using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Smart.Design.Razor.TagHelpers.Constants;

namespace Opportunity.DesignSystem.RazorView
{
    /// <summary>
    /// </summary>
    public static class ListingHelper
    {
        public static IEnumerable<string> Run()
        {
            return GetConstants(typeof(TagNames)).ToList().Select(v => v.GetRawConstantValue() as string).ToList();
        }

        private static IEnumerable<FieldInfo> GetConstants(Type type)
        {
            var constants = new ArrayList();

            var fieldInfos = type.GetFields(
                BindingFlags.Public | BindingFlags.Static |
                BindingFlags.FlattenHierarchy);

            foreach (var fi in fieldInfos)
                if (fi.IsLiteral && !fi.IsInitOnly)
                    constants.Add(fi);

            // Return an array of FieldInfos
            return (FieldInfo[]) constants.ToArray(typeof(FieldInfo));
        }
    }
}
