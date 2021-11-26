namespace Nudes.Retornator.Core;

/// <summary>
/// Most basic representation of a result, an empty result
/// </summary>
public class Result : IResult
{
    private static Result _success;
    /// <summary>
    /// Cached success result for minimal allocation
    /// </summary>
    public static Result Success => _success ??= new Result();

    /// <summary>
    /// Error returned
    /// </summary>
    public Error Error { get; set; }

    /// <summary>
    /// Creates a Result with an error. This error shall be detected and handled further on the application. 
    /// </summary>
    /// <param name="error">Error of the result</param>
    public static Result Throw(Error error) => new()
    {
        Error = error
    };

    /// <summary>
    /// Creates a Result with a basic error
    /// </summary>
    /// <param name="name">Name of the basic error</param>
    /// <param name="description">Description of the basic error</param>
    public static Result Throw(string name, string description) => Throw(new Error(name, description));

    /// <summary>
    /// Implicit convert an error to a result
    /// </summary>
    /// <param name="error"></param>
    public static implicit operator Result(Error error) => Result.Throw(error);

}
