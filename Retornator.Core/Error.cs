using System.Collections.Generic;

namespace Nudes.Retornator.Core
{
    /// <summary>
    /// Represents some error thrown on the service layer of an application.
    /// </summary>
    public class Error
    {
        /// <summary>
        /// Name of the error (a quick description of what happened).
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// Message describing the error (a deep explanation of what happened).
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        /// List representing all errors related to fields
        /// </summary>
        public Dictionary<string, List<string>> FieldErrors { get; set; }


        public Error()
        {
            Name = string.Empty;
            Description = string.Empty;
        }

        public Error(string name, string description)
        {
            Name = name;
            Description = description;
        }

    }
}
