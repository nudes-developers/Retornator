namespace Nudes.Retornator.Core
{
    /// <summary>
    /// Represents a detail/part of an error. Made to be used with Base.Error.
    /// (e.g : In a error about some form filled incorrectly a Detail could be the representation of a wrong field, with the Title being the name of the field and/or 
    /// it's value and the Body being a explanation of why is it wrong.)
    /// </summary>
    public class Detail
    {
        public Detail() { }

        /// <summary>
        /// </summary>
        /// /// <param name="title">Title or main description for this part of the error.</param>
        /// <param name="message">Message describing deeply this part of the error.</param>
        public Detail(string title, string message)
        {
            Title = title;
            Body = message;
        }

        /// <summary>
        /// Title or main description for this part of the error.
        /// </summary>
        public virtual string Title { get; internal set; }

        /// <summary>
        /// Message describing deeply this part of the error.
        /// </summary>
        public virtual string Body { get; internal set; }
    }
}
