using Nudes.Retornator.Sample.Errors;

namespace Nudes.Retornator.Sample.Features.Values.Errors
{
    public class ValueNotFoundError : NotFoundError
    {
        public ValueNotFoundError(int id) : base() {
            ValueId = id;
        }

        public int ValueId { get; set; }
    }
}
