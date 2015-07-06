using DDDSkeletonNET.Portal.ApplicationServices.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DDDSkeletonNET.Portal
{
    /// <summary>
    /// Exception dictionary extension methods, holds the map between the exception types 
    /// and http status code.
    /// </summary>
    public static class ExceptionDictionary
    {
        /// <summary>
        /// Converts to HTTP status code.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <returns></returns>
        public static HttpStatusCode ConvertToHttpStatusCode(this Exception exception)
        {
            Dictionary<Type, HttpStatusCode> dict = GetExceptionDictionary();
            if (dict.ContainsKey(exception.GetType()))
            {
                return dict[exception.GetType()];
            }

            return dict[typeof(Exception)];
        }

        /// <summary>
        /// Gets the exception dictionary.
        /// </summary>
        /// <returns></returns>
        private static Dictionary<Type, HttpStatusCode> GetExceptionDictionary()
        {
            Dictionary<Type, HttpStatusCode> dict = new Dictionary<Type, HttpStatusCode>();
            dict[typeof(ResourceNotFoundException)] = HttpStatusCode.NotFound;
            dict[typeof(Exception)] = HttpStatusCode.InternalServerError;
            return dict;
        }
    }
}
