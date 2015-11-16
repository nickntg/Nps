using System.Runtime.InteropServices;
using System.Web.Http;

namespace ETravel.Nps.Service.Controllers
{
    /// <summary>
    /// The NPS controller.
    /// </summary>
    public class NpsController : ApiController
    {
        /// <summary>
        /// Returns a list of NPS ratings based on ratable ID and/or ratable type.
        /// </summary>
        /// <param name="ratable_id">Id of the NPS rating.</param>
        /// <param name="ratable_type">Type of the NPS rating.</param>
        /// <returns>List of NPS matching the parameters.</returns>
        /// <summary>test</summary>
        /// <remarks>remarks</remarks>
        [Route("ratings")]
        public IHttpActionResult GetRatings(string ratable_id, string ratable_type)
        {
            return NotFound();
        }
    }
}
