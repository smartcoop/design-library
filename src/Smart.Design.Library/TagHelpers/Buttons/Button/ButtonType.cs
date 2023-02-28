namespace Smart.Design.Library.TagHelpers.Buttons.Button;

public enum ButtonType
{
    /// <summary>
    /// The button has no default behavior, and does nothing when pressed by default.
    /// It can have client-side scripts listen to the element's events, which are triggered when the events occur.
    /// This is the default behavior.
    /// </summary>
    Button,
    /// <summary>
    /// The button submits the form data to the server.
    /// </summary>
    Submit
}
