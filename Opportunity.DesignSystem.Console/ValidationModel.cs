using System.Collections.Generic;
using System.Linq;

namespace Opportunity.DesignSystem.Console
{
    public abstract class ValidationModel
    {
        public IEnumerable<ErrorModel> Errors { get; set; }

        public bool IsValid()
        {
            return !Errors.Any();
        }
    }

    public class ErrorModel
    {
        public string Name { get; set; }
        public string Message { get; set; }
    }
}
