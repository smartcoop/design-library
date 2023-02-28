// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;

namespace Smart.Design.HtmlGenerator.Managers;

public interface IComponentDiscoverer
{
    /// <summary>
    /// Returns a collection of the Smart design components implemented with Tag Helpers in Smart.Design.Library library.
    /// </summary>
    /// <returns>A list of Tag Helpers rendering Smart design components</returns>
    List<string> GetAllTagHelperNames();
}
