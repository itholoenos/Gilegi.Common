using System;

namespace Gilegi.Common.Extensions
{
    public static class GuidExtensions
    {
        public static string StripDashes(this Guid guid)
        {
            return guid.ToString("N");
        }
    }
}