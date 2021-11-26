namespace Nudes.Retornator.Core;

/// <summary>
/// Represents some error on the service layer of an application.
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
    /// Representation of all errors related to specific fields
    /// </summary>
    public FieldErrors FieldErrors { get; set; }

    /// <summary>
    /// Constructor
    /// </summary>
    public Error() : this(string.Empty, string.Empty)
    {
        // as is
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="name">name of the error</param>
    /// <param name="description">description fo the error</param>
    public Error(string name, string description)
    {
        Name = name;
        Description = description;
        FieldErrors = new FieldErrors();
    }

}
