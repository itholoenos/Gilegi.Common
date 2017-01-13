using System;

namespace Gilegi.Common.Extensions
{
    public static class StringExtensions
    {
        public static string GetLast(this string input, int tailLength)
        {
            return tailLength >= input.Length ? input : input.Substring(input.Length - tailLength);
        }

        public static string Remove(this string input, string value)
        {
            return input.Replace(value, string.Empty);
        }

        public static string RemoveWhitespaces(this string value)
        {
            return value.Remove(" ");
        }

        public static string StripDashes(this string value)
        {
            return value.ToLowerInvariant().Replace("-", "");
        }

        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        public static bool IsNullOrWhiteSpace(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        public static Guid ToGuid(this string value)
        {
            Guid guid;

            if (Guid.TryParse(value, out guid))
            {
                return guid;
            }

            return Guid.Empty;
        }
    }
}