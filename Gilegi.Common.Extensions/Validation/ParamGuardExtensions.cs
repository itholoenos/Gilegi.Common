using System;

namespace Gilegi.Common.Extensions.Validation
{
    public static class ParamGuardExtensions
    {
        /// <summary>
        /// Checks if the given param is null and throws an ArgumentNullException. 
        /// 
        /// PLEASE GIVE the name of the param using nameof() method
        /// </summary>
        /// <param name="param">the parameter to check</param>
        /// <param name="paramName">the param name. PLEASE USE nameof() method</param>
        public static void GuardForNull(this object param, string paramName)
        {
            if (param == null)
            {
                throw new ArgumentNullException(nameof(paramName));
            }
        }

        public static void GuardForNullOrEmpty(this string value, string paramName)
        {
            value.GuardForNull(paramName);

            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("value cannot be empty", paramName);
            }
        }

        public static void GuardForNullOrWhitespace(this string value, string paramName)
        {
            value.GuardForNull(paramName);

            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("value cannot be null or whitespace", paramName);
            }
        }
    }
}