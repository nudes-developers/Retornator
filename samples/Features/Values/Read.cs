using Nudes.Retornator.Core;
using Nudes.Retornator.Sample.Errors;
using Nudes.Retornator.Sample.Features.Values.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nudes.Retornator.Sample.Features.Values
{
    public class Read
    {
        public class Result : BaseResult<Read.Result>
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public static async Task<Result> Handle(bool returnWithError)
        {
            if (returnWithError)
                return Result.Throw(new ValueNotFoundError(1));
            
            return new Result()
            {
                Id = 1,
                Name = "Result of a success read"
            };
        }
    }
}
