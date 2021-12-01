using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smart.Design.HtmlGenerator.Models
{
    public class CommandResponse
    {
        private string SuccessMessage;

        private List<Exception> Errors = new();

        public bool IsSuccess => !Errors.Any();

        public string GetResponseMessage()
        {
            if (IsSuccess) return SuccessMessage;

            StringBuilder stringBuilder = new("Exception Stack");
            stringBuilder.AppendLine();
            Errors.ForEach(error => stringBuilder.AppendLine((string?) $"Exception with message => {error}"));
            return stringBuilder.ToString();
        }

        public void AddError(Exception exception)
            => Errors.Add(exception);

        public void SetSuccessMessage(string message) => SuccessMessage = message;
    }
}
