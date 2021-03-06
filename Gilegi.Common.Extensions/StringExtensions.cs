﻿using System;
using System.Collections.Generic;
using System.Linq;
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

        public static string ReplaceIgnoreCase(this string input, string pattern, string replacement)
        {
            return Regex.Replace(input, pattern, replacement, RegexOptions.IgnoreCase);
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

        /// <summary>
        /// returns the first or default item that starts with the given value
        /// </summary>
        /// <param name="list"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string FirstOrDefault(this IEnumerable<string> list, string value)
        {
            return list.FirstOrDefault(i => i.StartsWith(value));
        }
    }
}