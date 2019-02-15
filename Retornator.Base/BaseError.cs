using System.Collections.Generic;

namespace NUDES.Retornator.Base
{
    /// <summary>
    /// Represents a specific error launched on the service layer of an application.
    /// </summary>
    public class Error
    {
        public Error() { }

        /// <summary>
        /// </summary>
        /// /// <param name="name">Name of the error.</param>
        /// <param name="description">Message describing the error.</param>
        public Error(string name,string descprition)
        {
            Name = name;
            Description = descprition;
        }

        /// <summary>
        /// Name of the error.
        /// </summary>
        public virtual string Name { get; internal set; }

        /// <summary>
        /// Message describing about the error.
        /// </summary>
        public virtual string Description { get; internal set; }
    }

    /// <summary>
    /// Represents a detailed error launched on the service layer of an application.
    /// </summary>
    public class DetailedError
    {
        /// <summary>
        /// Name of the error.
        /// </summary>
        public virtual string Name { get; internal set; }

        /// <summary>
        /// Message describing about the error.
        /// </summary>

        public virtual string Description { get; internal set; }

        /// <summary>
        /// List of errors used as details
        /// </summary>
        public List<Error> Details { get; set; }


        public DetailedError(string name, string description)
        {
            Name = name;
            Description = description;
        }
        
    }
}
