using System.Collections.Generic;

namespace Nudes.Retornator.Core;

/// <summary>
/// Represents a collection of errors for each field
/// </summary>
public class FieldErrors
{
    private readonly Dictionary<string, ICollection<string>> _internal;

    /// <summary>
    /// Constructor
    /// </summary>
    public FieldErrors()
    {
        _internal = new();
    }

    /// <summary>
    /// Returns or sets a collection of errors for a field
    /// </summary>
    /// <param name="fieldName">name of the field</param>
    public ICollection<string> this[string fieldName]
    {
        get => _internal[fieldName];
        set => _internal[fieldName] = value;
    }

    /// <summary>
    /// Add an error for a field
    /// </summary>
    /// <param name="fieldName">field name</param>
    /// <param name="error">error description</param>
    public void AddError(string fieldName, string error)
    {
        if (!_internal.ContainsKey(fieldName))
            _internal[fieldName] = new List<string>();

        _internal[fieldName].Add(error);
    }

    /// <summary>
    /// Add a collection of errors to a field
    /// </summary>
    /// <param name="fieldName">field name</param>
    /// <param name="errors">collection of errors</param>
    public void AddErrors(string fieldName, params string[] errors)
    {
        if (!_internal.ContainsKey(fieldName))
            _internal[fieldName] = new List<string>(errors);
        else
            for (int i = 0; i < errors.Length; i++)
                _internal[fieldName].Add(errors[i]);
    }

    /// <summary>
    /// Clear all errors
    /// </summary>
    public void Clear() => _internal.Clear();

    /// <summary>
    /// Clear all errors for a field
    /// </summary>
    /// <param name="fieldName">name of the field</param>
    public void Clear(string fieldName)
    {
        if (_internal.ContainsKey(fieldName))
            _internal[fieldName].Clear();
    }
}
