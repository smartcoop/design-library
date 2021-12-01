// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

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

            StringBuilder stringBuilder = new("Exception Stacks");
            Errors.ForEach(error => stringBuilder.AppendLine((string?) $"exception with message => {error}"));
            return stringBuilder.ToString();
        }

        public void AddError(Exception exception)
            => Errors.Add(exception);

        public void SetSuccessMessage(string message) => SuccessMessage = message;
    }
}
