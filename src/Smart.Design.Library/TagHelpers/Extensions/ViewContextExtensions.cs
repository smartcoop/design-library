using System;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Smart.Design.Library.TagHelpers.Extensions;

/// <summary>
/// Defines extension methods on <see cref="ViewContext"/>.
/// </summary>
public static class ViewContextExtensions
{
    /// <summary>
    /// Checks if there are any ModelState errors associated to <paramref name="viewContext"/> for a given <paramref name="key"/>.
    /// </summary>
    /// <param name="viewContext">The view context from which the ModelState will be checked.</param>
    /// <param name="key">The key of a <see cref="ModelStateEntry"/> belonging to the ModelState of <paramref name="viewContext"/>.</param>
    /// <returns>True if there is an entry with key <paramref name="key"/> having one or more errors, false otherwise.</returns>
    /// <exception cref="ArgumentNullException">If the key is null.</exception>
    public static bool HasModelStateErrorsByKey(this ViewContext viewContext, string key)
    {
        return viewContext.GetModelErrorsByKey(key).Count > 0;
    }

    /// <summary>
    /// Returns the ModelState errors of a <see cref="ModelStateEntry"/> associated to a given <paramref name="viewContext"/> for a given <paramref name="key"/>.
    /// </summary>
    /// <param name="viewContext">The view context from which the ModelState will be checked.</param>
    /// <param name="key">The key of a <see cref="ModelStateEntry"/> belonging to the ModelState of <paramref name="viewContext"/>.</param>
    /// <returns>The collection of ModelState errors given a key (<see cref="ModelErrorCollection"/>).
    /// If no errors are found, then an empty collection of <see cref="ModelError"/> is returned.</returns>
    /// <exception cref="ArgumentNullException">If the key is null.</exception>
    public static ModelErrorCollection GetModelErrorsByKey(this ViewContext viewContext, string key)
    {
        key = key ?? throw new ArgumentNullException(nameof(key));

        var modelState = viewContext.ModelState;

        if (modelState.TryGetValue(key, out var modelStateEntry))
        {
            return modelStateEntry.Errors;
        }

        return new ModelErrorCollection();
    }
}
