namespace Nudes.Retornator.Core;

/// <summary>
/// Represents a result of type T
/// </summary>
/// <typeparam name="T">Type of result</typeparam>
public class ResultOf<T> : IResult
{
    /// <summary>
    /// Error returned
    /// </summary>
    public virtual Error Error { get; set; }

    /// <summary>
    /// Expected result returned
    /// </summary>
    public virtual T Result { get; set; }

    /// <summary>
    /// Implicit conversion from Result, it will contain the same error but null result
    /// </summary>
    public static implicit operator ResultOf<T>(Result result) => new() { Error = result.Error };

    /// <summary>
    /// Implicit conversion from T (result). it will contain no error
    /// </summary>
    /// <param name="result">result</param>
    public static implicit operator ResultOf<T>(T result) => new() { Result = result };

    /// <summary>
    /// Implicit conversion from T (error). it will contain no result
    /// </summary>
    /// <param name="error"></param>
    public static implicit operator ResultOf<T>(Error error) => new() { Error = error };
}
