using NUDES.Retornator.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NUDES.Retornator.Sample.Errors
{
    public class NotFoundError : Error
    {
        public NotFoundError() : base("Not Found", "The element was not found.") { }


        public NotFoundError(string name, string description) : base(name, description) { }
    }
}
