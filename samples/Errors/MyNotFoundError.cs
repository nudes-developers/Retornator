using Nudes.Retornator.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nudes.Retornator.Sample.Errors
{
    public class MyNotFoundError : Error
    {
        public MyNotFoundError() : base("Not Found", "The element was not found.") { }


        public MyNotFoundError(string name, string description) : base(name, description) { }
    }
}
