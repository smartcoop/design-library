using System;

namespace Smart.Design.HtmlGenerator.Models.Exceptions;

public class ValidationException : Exception
{
    public ValidationException(string message) : base(message)
    {
    }
}
