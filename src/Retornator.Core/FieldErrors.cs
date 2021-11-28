using System.Collections.Generic;
using System.Linq;

namespace Nudes.Retornator.Core;

/// <summary>
/// Represents a collection of errors for each field
/// </summary>
public class FieldErrors
{
    /// <summary>
    /// Internal dictionary source
    /// </summary>
    public Dictionary<string, ICollection<string>> InternalSource { get; private set; }

    /// <summary>
    /// Constructor
    /// </summary>
    public FieldErrors()
    {
        InternalSource = new();
    }

    /// <summary>
    /// Construct from a dictionary source
    /// </summary>
    /// <param name="source">Dictionary source</param>
    public FieldErrors(Dictionary<string, IEnumerable<string>> source)
    {
        InternalSource = source.ToDictionary(d=>d.Key, d=>d.Value is ICollection<string> col ? col : d.Value.ToList());
    }

    /// <summary>
    /// Construct from a dicitonary source
    /// </summary>
    /// <param name="source">Dictionary source</param>
    public FieldErrors(Dictionary<string, ICollection<string>> source)
    {
        InternalSource = source;
    }

    /// <summary>
    /// Returns or sets a collection of errors for a field
    /// </summary>
    /// <param name="fieldName">name of the field</param>
    public ICollection<string> this[string fieldName]
    {
        get => InternalSource[fieldName];
        set => InternalSource[fieldName] = value;
    }

    /// <summary>
    /// Add an error for a field
    /// </summary>
    /// <param name="fieldName">field name</param>
    /// <param name="error">error description</param>
    public void AddError(string fieldName, string error)
    {
        if (!InternalSource.ContainsKey(fieldName))
            InternalSource[fieldName] = new List<string>();

        InternalSource[fieldName].Add(error);
    }

    /// <summary>
    /// Add a collection of errors to a field
    /// </summary>
    /// <param name="fieldName">field name</param>
    /// <param name="errors">collection of errors</param>
    public void AddErrors(string fieldName, params string[] errors)
    {
        if (!InternalSource.ContainsKey(fieldName))
            InternalSource[fieldName] = new List<string>(errors);
        else
            for (int i = 0; i < errors.Length; i++)
                InternalSource[fieldName].Add(errors[i]);
    }

    /// <summary>
    /// Clear all errors
    /// </summary>
    public void Clear() => InternalSource.Clear();

    /// <summary>
    /// Clear all errors for a field
    /// </summary>
    /// <param name="fieldName">name of the field</param>
    public void Clear(string fieldName)
    {
        if (InternalSource.ContainsKey(fieldName))
            InternalSource[fieldName].Clear();
    }

    /// <summary>
    /// explicit cast for dictionary
    /// </summary>
    /// <param name="field"></param>
    public static explicit operator Dictionary<string, ICollection<string>>(FieldErrors field) => field.InternalSource;

    /// <summary>
    /// explicit cast from dictionary
    /// </summary>
    /// <param name="dictionary"></param>
    public static explicit operator FieldErrors(Dictionary<string, ICollection<string>> dictionary) => new(dictionary);
}
