namespace Nudes.Retornator.Core;

/// <summary>
/// Protocol of an result
/// </summary>
public interface IResult
{
    /// <summary>
    /// Returns if error is not null
    /// </summary>
    bool HasError => Error is not null;

    /// <summary>
    /// Error returned
    /// </summary>
    Error Error { get; set; }
}
