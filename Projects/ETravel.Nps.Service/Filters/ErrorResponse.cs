using System.Net;

namespace ETravel.Nps.Service.Filters
{
    /// <summary>
    /// The error response is a construct to faciliate unit testing.
    /// </summary>
    public class ErrorResponse
    {
        /// <summary>
        /// Status code corresponding to a validation error.
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// Message corresponding to a validation error.
        /// </summary>
        public string Message { get; set; }
    }
}