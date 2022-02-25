namespace Smart.Design.Razor.TagHelpers.Spacer;

public enum Size
{
    // We don't use Nullable<Size> therefore we need a default value that tells the generator there is nothing to do.
    Unspecified = 0,
    Default,
    ExtraSmall,
    Small,
    Large,
    ExtraLarge,
    Auto
}
