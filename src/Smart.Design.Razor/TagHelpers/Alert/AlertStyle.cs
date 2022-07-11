namespace Smart.Design.Razor.TagHelpers.Alert;

/// <summary>
/// Possible styles for an <see cref="AlertTagHelper"/>.
/// </summary>
public enum AlertStyle
{
    /// <summary>
    /// Default style.
    /// </summary>
    Default = 0,
    /// <summary>
    /// Style that indicates the state is in error.
    /// </summary>
    Error,
    /// <summary>
    /// Style that indicates the state is in warning.
    /// </summary>
    Warning,
    /// <summary>
    /// Style that indicates the state is in success.
    /// </summary>
    Success
}
