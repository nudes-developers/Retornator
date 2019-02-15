using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

namespace NUDES.Retornator.Base
{
    public abstract class BaseResult
    {
        internal DetailedError Error { get; set; }

        public DetailedError GetError() => Error;
    }


    /// <summary>
    /// Represents a result of an operation to be returned on the service layer.
    /// </summary>
    /// <typeparam name="T">Type of the implementing child class.</typeparam>
    public class BaseResult<T> : BaseResult where T : BaseResult, new()
    {
        /// <summary>
        /// Throw an error to the base result. This error shall be detected on some part of the application in order to trigger a handle operation.
        /// </summary>
        /// <param name="error">The error to throw.</param>
        /// <returns>This instance of BaseResult&lt;T&gt;</returns>
        public static T Throw(DetailedError error) => new T() { Error = error };

        /// <summary>
        /// Throw an error to the base result. This error shall be detected on some part of the application in order to trigger a handle operation.
        /// </summary>
        /// <param name="name">The name of the error to throw.</param>
        /// <param name="descprition">The description of the error to throw.</param>
        /// <returns>This instance of BaseResult&lt;T&gt;/></returns>
        public static T Throw(string name, string descprition) => Throw(new DetailedError(name, descprition));


        /// <summary>
        /// Add a Error to the BaseResult.Error.Details collection. 
        /// </summary>
        /// <param name="detail">The error to add.</param>
        /// <returns>The calling object.</returns>
        public T AddDescription(Error detail)
        {
            if (Error is null)
                throw new InvalidOperationException($"The error is null. Use ResultBase<T>.Throw before add a description.");

            if (Error.Details is null)
                Error.Details = new List<Error>();

            Error.Details.Add(detail);

            return this as T;
        }

        /// <summary>
        /// Add a Error created based on the params to the BaseResult.Error.Details collection. 
        /// </summary>
        /// <param name="name">The name of the error to add.</param>
        /// <param name="description">The description error to add.</param>
        /// <returns>The calling object.</returns>
        public T AddDescription(string name, string description) => AddDescription(new Error(name, description));

        /// <summary>
        /// Add a list of Errors to the BaseResult.Error.Details collection. 
        /// </summary>
        /// <param name="details">The error list to add.</param>
        /// <returns>The calling object.</returns>
        public T AddDescriptions(IEnumerable<Error> details)
        {
            if (Error is null)
                throw new InvalidOperationException($"The error is null. Use ResultBase<T>.Throw before add a description.");

            if (Error.Details is null)
                Error.Details = new List<Error>(details);
            else
                Error.Details.AddRange(details);

            foreach (var detail in details)
                AddDescription(detail);

            return this as T;
        }

        /// <summary>
        /// Add a list of Errors based on the string fields (first is name, second is description) to the BaseResult.Error.Details collection. 
        /// </summary>
        /// <param name="details">The error list to add.</param>
        /// <returns>The calling object.</returns>
        public T AddDescriptions(IEnumerable<(string, string)> details) => AddDescriptions(details.Select(detail => new Error(detail.Item1, detail.Item2)));

    }
}
