using System.Text;

namespace Smart.Design.Razor.Templates.Extensions;

public static class FileNameExtensions
{
    public static string ToHumanReadable(this string input)
    {
        if (!string.IsNullOrEmpty(input))
        {
            input = input.Replace("-", " ");
            input = input.Replace("_", " ");
            input = input.Replace(".html", " ");
            var stringBuilder = new StringBuilder(input);
            stringBuilder[0] = char.ToUpper(input[0]);
            return stringBuilder.ToString();
        }

        return input;
    }
}
