using System;
using System.Text.RegularExpressions;

namespace Gilegi.Common.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// tries to parse the input value to a Guid. returns Guid.Empty on fail
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Guid ToGuid(this string value)
        {
            Guid guid;

            if (Guid.TryParse(value, out guid))
            {
                return guid;
            }

            return Guid.Empty;
        }

        /// <summary>
        /// the same as string.IsNullOrEmpty. it just helps with readability and code writing flow
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        /// <summary>
        /// the same as string.IsNullOrWhiteSpace. it just helps with readability and code writing flow
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNullOrWhiteSpace(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        /// <summary>
        /// returns the last X chars of a string
        /// </summary>
        /// <param name="input"></param>
        /// <param name="tailLength"></param>
        /// <returns></returns>
        public static string GetLast(this string input, int tailLength)
        {
            return tailLength >= input.Length ? input : input.Substring(input.Length - tailLength);
        }

        /// <summary>
        /// returns first X chars of a string
        /// </summary>
        /// <param name="value"></param>
        /// <param name="maxLength"></param>
        /// <returns></returns>
        public static string Truncate(this string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value))
            {
                return value;
            }

            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }

        /// <summary>
        /// used to remove non alphanumeric values
        /// </summary>
        private static readonly Regex AlphanumericRegex = new Regex("[^a-zA-Z0-9 -]", RegexOptions.Compiled, TimeSpan.FromMilliseconds(50));

        /// <summary>
        /// removes non alphanumeric values from a string
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string RemoveNonAlphanumeric(this string value)
        {
            return AlphanumericRegex.Replace(value, string.Empty);
        }

        /// <summary>
        /// replaces the valueToRemove with empty string
        /// </summary>
        /// <param name="value"></param>
        /// <param name="valueToRemove"></param>
        /// <returns></returns>
        public static string Remove(this string value, string valueToRemove)
        {
            return value.Replace(valueToRemove, string.Empty);
        }

        /// <summary>
        /// removes whitespaces from string value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string RemoveWhitespaces(this string value)
        {
            return value.Remove(" ");
        }

        /// <summary>
        /// removes dashes from string value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string StripDashes(this string value)
        {
            return value.Remove("-");
        }

        /// <summary>
        /// replaces spaces with underscores from the given string
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ReplaceSpacesWithUnderscore(this string value)
        {
            return value.Replace(" ", "_");
        }


        /// <summary>
        /// replaces spaces with dashes from the given string
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ReplaceSpacesWithDashes(this string value)
        {
            return value.Replace(" ", "-");
        }
    }
}