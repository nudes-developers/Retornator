using Nudes.Retornator.Core;

namespace Nudes.Retornator.AspnetCore.Errors;

/// <summary>
/// Request requires payment to be completed
/// </summary>
public class PaymentRequiredError : Error
{
    /// <summary>
    /// 
    /// </summary>
    public PaymentRequiredError() : base("Payment required", "Missing payment for the resource")
    { }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="resourceName"></param>
    public PaymentRequiredError(string resourceName) : base("Payment required", $"Missing payment for {resourceName}")
    { }
}
