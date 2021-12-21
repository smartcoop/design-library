using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Smart.Design.HtmlGenerator.Extensions;

/// <summary>
/// Collection of extensions method on <see cref="Type"/>
/// </summary>
public static class TypeExtensions
{
    /// <summary>
    /// Uses reflection to get all <see cref="FieldInfo"/> of the given <paramref name="type"/> that are constants.
    /// </summary>
    /// <param name="type">The type to introspect its constants.</param>
    /// <returns>A enumeration of <see cref="FieldInfo" /> that are constants of the <paramref name="type" />.</returns>
    public static IEnumerable<FieldInfo> GetConstants(this Type type)
    {
        var fieldInfos = type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);

        return fieldInfos.Where(fieldInfo => fieldInfo.IsLiteral && !fieldInfo.IsInitOnly);
    }

    /// <summary>
    /// Use reflection to retrieve all constant values matching a given <see cref="Type" />
    /// </summary>
    /// <typeparam name="T">The type on which should be filtered the constant values.</typeparam>
    /// <param name="type">The type to introspect its consants.</param>
    /// <returns>An enumeration of</returns>
    public static IEnumerable<T> GetConstantValues<T>(this Type type) where T : class
    {
        var fieldInfos = GetConstants(type).Where(fieldInfo => fieldInfo.FieldType == typeof(T));

        return fieldInfos.Select(fieldInfo => fieldInfo.GetRawConstantValue() as T);
    }
}
