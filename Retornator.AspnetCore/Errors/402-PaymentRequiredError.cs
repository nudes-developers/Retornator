using Nudes.Retornator.Core;

namespace Nudes.Retornator.AspnetCore.Errors
{
    public class PaymentRequiredError : Error
    {
        public PaymentRequiredError() : base("Payment required", "Missing payment for the resource")
        { }

        public PaymentRequiredError(string resourceName) : base("Payment required", $"Missing payment for {resourceName}")
        { }
    }
}
