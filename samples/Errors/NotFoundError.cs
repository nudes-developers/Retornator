using Nudes.Retornator.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nudes.Retornator.Sample.Errors
{
    public class NotFoundError : Error
    {
        public NotFoundError() : base("Not Found", "The element was not found.") { }


        public NotFoundError(string name, string description) : base(name, description) { }
    }
}
