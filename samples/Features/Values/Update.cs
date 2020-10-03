using Nudes.Retornator.Core;
using Nudes.Retornator.Sample.Errors;
using Nudes.Retornator.Sample.Features.Values.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nudes.Retornator.Sample.Features.Values
{
    public class Update
    {
        public class Result : BaseResult<Update.Result>
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public static Task<Result> Handle(bool returnWithError)
        {
            if (returnWithError)
                return Task.FromResult(Result.Throw(new ValueInvalidError("2.0"))
                        .AddFieldError("Name", "The field name must have 30 or more characters.")
                        .AddFieldError("Id", "The field Id cannot be altered."));

            return Task.FromResult(new Result()
            {
                Id = 2,
                Name = "Result of a success update"
            });
        }
    }
}
