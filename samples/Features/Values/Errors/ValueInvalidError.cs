using Nudes.Retornator.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nudes.Retornator.Sample.Features.Values.Errors
{
    public class ValueInvalidError : Error
    {
        public ValueInvalidError(string violatedRule) : base("Invalid Value", "The provided value is invalid.") {
            ViolatedRule = violatedRule;
        }

        public string ViolatedRule { get; set; }
    }
}
