using System.Collections.Generic;
using System.Linq;

namespace Smart.Application.Console
{
    public abstract class ValidationModel
    {
        public IEnumerable<ErrorModel> Errors { get; set; }
        public bool IsValid() => !Errors.Any();
    }

    public class ErrorModel
    {
        public string Name { get; set; }
        public string Message { get; set; }
    }
}