using System;

namespace ETravel.Nps.Service.Extensions
{
    /// <summary>
    /// Date helper methods.
    /// </summary>
    public static class DateExtensions
    {
        /// <summary>
        /// Converts a date to ISO8601 format.
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string ToIso8601(this DateTime dt)
        {
            return dt.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'sszzz");
        }
    }
}