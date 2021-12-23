using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Smart.Design.Razor.TagHelpers.Constants;

namespace Smart.Design.Templates;

/// <summary>
/// </summary>
public class CustomTagHelperCollections
{
    public IEnumerable<string> Names => GetNamesFromType(typeof(TagNames))
        .Select(v => v.GetRawConstantValue() as string);

    private IEnumerable<FieldInfo> GetNamesFromType(Type type)
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

    public IEnumerable<string> GetAvailableViewsName()
    {
        var filesDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Views");
        var files = Directory.GetFiles(filesDirectory).Select(Path.GetFileName)
            .Select(filename => filename.Split('.')[0]);
        return files;
    }
}
