namespace Smart.Design.Razor.TagHelpers.Spacer;

/// <summary>
/// Size of the margin to be applied around the <see cref="SpacerTagHelper"/>.
/// </summary>
public enum Size
{
    // We don't use Nullable<Size> therefore we need a default value that tells the generator there is nothing to do.
    /// <summary>
    /// Applies no margin. Used to avoid using Nullable&lt;Size&gt; properties.
    /// </summary>
    Unspecified = 0,
    /// <summary>
    /// Default Smart Design margin size.
    /// </summary>
    Default,
    /// <summary>
    /// Extra small Smart Design margin size.
    /// </summary>
    ExtraSmall,
    /// <summary>
    /// Small Smart Design margin size.
    /// </summary>
    Small,
    /// <summary>
    /// Large Smart Design margin size.
    /// </summary>
    Large,
    /// <summary>
    /// Extra Large Smart Design margin size.
    /// </summary>
    ExtraLarge,
    /// <summary>
    /// Applies auto margin. (In term of css: "The browser selects a suitable margin to use. For example, in certain cases this value can be used to center an element.")
    /// </summary>
    Auto
}
