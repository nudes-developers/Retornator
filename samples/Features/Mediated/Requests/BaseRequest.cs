using Microsoft.AspNetCore.Mvc;

namespace Nudes.Retornator.Sample.Features.Mediated.Requests;

public class BaseRequest : IRequestQueryParam
{
    [FromQuery]
    public bool Error { get; set; }
}
