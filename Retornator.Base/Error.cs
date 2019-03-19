using System.Collections.Generic;

namespace NUDES.Retornator.Base
{
    /// <summary>
    /// Represents some error launched on the service layer of an application.
    /// </summary>
    public class Error
    {
        /// <summary>
        /// Name of the error (a quick description of what happened).
        /// </summary>
        public virtual string Name { get; internal set; }

        /// <summary>
        /// Message describing the error (a deep explanation of what happened).
        /// </summary>

        public virtual string Description { get; internal set; }

        /// <summary>
        /// List who represents details of this error.
        /// </summary>
        public List<Detail> Details { get; set; }


        public Error(string name, string description)
        {
            Name = name;
            Description = description;
        }
        
    }
}
