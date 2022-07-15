using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Smart.Design.Razor.TagHelpers.Icon;

namespace Smart.Design.Razor.TagHelpers.Alert;

/// <summary>
/// Contract interface to generate HTML of Smart Alert.
/// </summary>
public interface IAlertHtmlGenerator
{
    /// <summary>
    /// Generates a Smart Design Alert.
    /// </summary>
    /// <param name="title">The title of the Alert, this parameter is optional.</param>
    /// <param name="messages">The list of messages to e displayed inside the Alert.</param>
    /// <param name="alertStyle"><see cref="AlertStyle"/> of the Alert.</param>
    /// <param name="icon"><see cref="Image"/>Overrides the default icon with another icon.</param>
    /// <param name="isClosable">Defines if the Alert can be closed or not.</param>
    /// <param name="isLight">Defines if the Alert should use a light theme.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result is an instance of the Smart Design Alert.
    /// </returns>
    public Task<TagBuilder> GenerateAlertAsync(
        string? title,
        List<string>? messages,
        AlertStyle alertStyle,
        Image icon,
        bool isClosable,
        bool isLight);

    /// <summary>
    /// Generates a Smart Design Alert.
    /// </summary>
    /// <param name="title">The title of the Alert, this parameter is optional.</param>
    /// <param name="message">The list of messages to e displayed inside the Alert.</param>
    /// <param name="alertStyle"><see cref="AlertStyle"/> of the Alert.</param>
    /// <param name="icon"><see cref="Image"/>Overrides the default icon with another icon.</param>
    /// <param name="isClosable">Defines if the Alert can be closed or not.</param>
    /// <param name="isLight">Defines if the Alert should use a light theme.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result is an instance of the Smart Design Alert.
    /// </returns>
    public Task<TagBuilder> GenerateAlertAsync(
        string? title,
        string? message,
        AlertStyle alertStyle,
        Image icon,
        bool isClosable,
        bool isLight);
}
