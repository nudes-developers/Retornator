using NUDES.Retornator.Base;
using NUDES.Retornator.Sample.Errors;
using NUDES.Retornator.Sample.Features.Values.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NUDES.Retornator.Sample.Features.Values
{
    public class Write
    {
        public class Result : BaseResult<Write.Result>
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public static async Task<Result> Handle(bool returnWithError)
        {
            if (returnWithError)
                return Result.Throw(new ValueInvalidError("5.1"));

            return new Result()
            {
                Id = 3,
                Name = "Result of a success write"
            };
        }
    }
}
