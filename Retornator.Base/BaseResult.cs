using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

namespace NUDES.Retornator.Base
{
    /// <summary>
    /// Represents a result of an operation to be returned on the service layer.
    /// </summary>
    public abstract class BaseResult
    {
        internal Error Error { get; set; }

        public Error GetError() => Error;


        public class Empty : BaseResult<Empty> { }
    }

    /// <summary>
    /// Represents a result of an operation to be returned on the service layer.
    /// </summary>
    /// <typeparam name="T">Type of the implementing child class.</typeparam>
    public class BaseResult<T> : BaseResult where T : BaseResult, new()
    {
        /// <summary>
        /// Creates a BaseResult&lt;T&gt; with a error. This error shall be detected and handled further on the application. 
        /// </summary>
        /// <param name="error">The error to throw.</param>
        /// <returns>A instance of BaseResult&lt;T&gt;</returns>
        public static T Throw(Error error) => new T() { Error = error };

        /// <summary>
        /// Creates a BaseResult&lt;T&gt; with a error. This error shall be detected and handled further on the application. 
        /// </summary>
        /// <param name="name">Name of the error (a quick description of what happened).</param>
        /// <param name="descprition">Message describing the error (a deep explanation of what happened).</param>
        /// <returns>A instance of BaseResult&lt;T&gt;/></returns>
        public static T Throw(string name, string descprition) => Throw(new Error(name, descprition));


        /// <summary>
        /// Add a detail to the error of this BaseResult.
        /// </summary>
        /// <param name="detail">The detail to add.</param>
        /// <returns>The calling object.</returns>
        public T AddDescription(Detail detail)
        {
            if (Error is null)
                throw new InvalidOperationException($"The error is null. This method should be used with the result of BaseResult<T>.Throw.");

            if (Error.Details is null)
                Error.Details = new List<Detail>();

            Error.Details.Add(detail);

            return this as T;
        }

        /// <summary>
        /// Add a detail to the error of this BaseResult.
        /// </summary>
        /// <param name="name">Title or main description for the detail.</param>
        /// <param name="description">Message describing deeply the detail.</param>
        /// <returns>The calling object.</returns>
        public T AddDescription(string name, string description) => AddDescription(new Detail(name, description));

        /// <summary>
        /// Add a list of details to the error of this BaseResult.
        /// </summary>
        /// <param name="details">The detail list to add.</param>
        /// <returns>The calling object.</returns>
        public T AddDescriptions(IEnumerable<Detail> details)
        {
            if (Error is null)
                throw new InvalidOperationException($"The error is null. Use BaseResult<T>.Throw before add a description.");

            if (Error.Details is null)
                Error.Details = new List<Detail>(details);
            else
                Error.Details.AddRange(details);

            foreach (var detail in details)
                AddDescription(detail);

            return this as T;
        }

        /// <summary>
        /// Add a list of details to the error of this BaseResult based on the string fields (first is title, second is description).
        /// </summary>
        /// <param name="details">The detail list to add.</param>
        /// <returns>The calling object.</returns>
        public T AddDescriptions(IEnumerable<(string, string)> details) => AddDescriptions(details.Select(detail => new Detail(detail.Item1, detail.Item2)));

    }
}
