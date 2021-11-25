//using System.Collections.Generic;
//using System.Linq;
//using System;

//namespace Nudes.Retornator.Core
//{
//    /// <summary>
//    /// Represents a result of an operation to be returned on the service layer.
//    /// </summary>
//    public abstract class BaseResult
//    {
//        internal Error Error { get; set; }

//        public Error GetError() => Error;

//    }

//    /// <summary>
//    /// Represents a result of an operation to be returned on the service layer.
//    /// </summary>
//    /// <typeparam name="T">Type of the implementing child class.</typeparam>
//    public class BaseResult<T> : BaseResult where T : BaseResult, new()
//    {
//        /// <summary>
//        /// Creates a BaseResult&lt;T&gt; with a error. This error shall be detected and handled further on the application. 
//        /// </summary>
//        /// <param name="error">The error to throw.</param>
//        /// <returns>A instance of BaseResult&lt;T&gt;</returns>
//        public static T Throw(Error error) => new() { Error = error };

//        /// <summary>
//        /// Creates a BaseResult&lt;T&gt; with a error. This error shall be detected and handled further on the application. 
//        /// </summary>
//        /// <param name="name">Name of the error (a quick description of what happened).</param>
//        /// <param name="description">Message describing the error (a deep explanation of what happened).</param>
//        /// <returns>A instance of BaseResult&lt;T&gt;/></returns>
//        public static T Throw(string name, string description) => Throw(new Error(name, description));

//        /// <summary>
//        /// Add a error closely coupled to a field/argument of the request
//        /// </summary>
//        /// <param name="fieldName">Name of field that caused the error</param>
//        /// <param name="errors">Errors caused by the field value</param>
//        /// <returns></returns>
//        public T AddFieldError(string fieldName, params string[] errors)
//        {
//            if (Error is null)
//                throw new InvalidOperationException($"The error is null. This method should be used with the reuslt of BaseResult<T>.Throw.");

//            if (Error.FieldErrors is null)
//                Error.FieldErrors = new Dictionary<string, List<string>>();

//            if (String.IsNullOrEmpty(fieldName))
//                throw new ArgumentNullException(nameof(fieldName));

//            if (errors.Length == 0)
//                throw new ArgumentNullException(nameof(errors));

//            if (Error.FieldErrors.ContainsKey(fieldName))
//                Error.FieldErrors[fieldName].AddRange(errors);
//            else
//                Error.FieldErrors[fieldName] = new List<string>(errors);

//            return this as T;
//        }

//    }
//}
