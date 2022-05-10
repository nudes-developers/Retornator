using System;
using System.Collections.Generic;
using System.Linq;

namespace Nudes.Retornator.Core;

/// <summary>
/// Represents a collection of errors for each field
/// </summary>
public class FieldErrors
{
    private Dictionary<string, List<string>> _internal { get; set; }

    /// <summary>
    /// Constructor
    /// </summary>
    public FieldErrors()
    {
        _internal = new();
    }

    /// <summary>
    /// Construct from a dictionary source
    /// </summary>
    /// <param name="source">Dictionary source</param>
    public FieldErrors(Dictionary<string, IEnumerable<string>> source)
    {
        _internal = source.ToDictionary(d => d.Key, d => d.Value is List<string> col ? col : d.Value.ToList());
    }

    /// <summary>
    /// Construct from a dicitonary source
    /// </summary>
    /// <param name="source">Dictionary source</param>
    public FieldErrors(Dictionary<string, List<string>> source)
    {
        _internal = source.ToDictionary(d => d.Key, d => d.Value is List<string> col ? col : d.Value.ToList());
    }

    /// <summary>
    /// Returns or sets a collection of errors for a field
    /// </summary>
    /// <param name="fieldName">name of the field</param>
    public List<string> this[string fieldName]
    {
        get => _internal[fieldName];
        set => _internal[fieldName] = value;
    }

    /// <summary>
    /// Add an error for a field
    /// </summary>
    /// <param name="fieldName">field name</param>
    /// <param name="error">error description</param>
    /// <exception cref="ArgumentNullException">thrown when fieldName or error is null</exception>
    public void Add(string fieldName, string error)
    {
        fieldName = fieldName ?? throw new ArgumentNullException(nameof(fieldName));
        error = error ?? throw new ArgumentNullException(nameof(error));
        if (!_internal.ContainsKey(fieldName))
            _internal[fieldName] = new List<string>();

        _internal[fieldName].Add(error);
    }

    /// <summary>
    /// Add a collection of errors to a field
    /// </summary>
    /// <param name="fieldName">field name</param>
    /// <param name="errors">collection of errors</param>
    public void Add(string fieldName, params string[] errors)
    {
        fieldName = fieldName ?? throw new ArgumentNullException(nameof(fieldName));
        if (errors.Length == 0) throw new ArgumentOutOfRangeException(nameof(errors), errors, "Errors cannot be empty");
        if (!_internal.ContainsKey(fieldName))
            _internal[fieldName] = new List<string>(errors);
        else
            _internal[fieldName].AddRange(errors);
    }

    /// <summary>
    /// Add a enumerable of errors to a field
    /// </summary>
    /// <param name="fieldName">field name</param>
    /// <param name="errors">collection of errors</param>
    public void Add(string fieldName, IEnumerable<string> errors)
    {
        fieldName = fieldName ?? throw new ArgumentNullException(nameof(fieldName));
        errors = errors ?? throw new ArgumentNullException(nameof(errors));
        if (!errors.Any()) throw new ArgumentOutOfRangeException(nameof(errors), errors, "Errors cannot be empty");
        if (!_internal.ContainsKey(fieldName))
            _internal[fieldName] = new List<string>(errors);
        else
            _internal[fieldName].AddRange(errors);
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
        fieldName = fieldName ?? throw new ArgumentNullException(nameof(fieldName));
        if (_internal.ContainsKey(fieldName))
            _internal[fieldName].Clear();
    }

    /// <summary>
    /// Check if there is any errors
    /// </summary>
    /// <returns></returns>
    public bool Any() => _internal.Any();

    /// <summary>
    /// explicit cast for dictionary
    /// </summary>
    /// <param name="field"></param>
    public static explicit operator Dictionary<string, List<string>>(FieldErrors field) => field._internal;

    /// <summary>
    /// explicit cast from dictionary
    /// </summary>
    /// <param name="dictionary"></param>
    public static explicit operator FieldErrors(Dictionary<string, List<string>> dictionary) => new(dictionary);
}
