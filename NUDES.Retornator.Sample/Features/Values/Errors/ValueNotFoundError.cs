using NUDES.Retornator.Base;
using NUDES.Retornator.Sample.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NUDES.Retornator.Sample.Features.Values.Errors
{
    public class ValueNotFoundError : NotFoundError
    {
        public ValueNotFoundError(int id) : base() {
            ValueId = id;
        }

        public int ValueId { get; set; }
    }
}
