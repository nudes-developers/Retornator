using NUDES.Retornator.Base;
using NUDES.Retornator.Sample.Errors;
using NUDES.Retornator.Sample.Features.Values.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NUDES.Retornator.Sample.Features.Values
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
