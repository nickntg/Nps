using System.Runtime.InteropServices;
using System.Web.Http;
using System.Web.Http.Description;

namespace ETravel.Nps.Service.Controllers
{
    /// <summary>
    /// The NPS service can be used to retrieve, create and update NPS ratings.
    /// </summary>
    public class NpsController : ApiController
    {
        /// <summary>
        /// Returns a list of NPS ratings based on ratable ID and/or ratable type.
        /// </summary>
        /// <param name="ratable_id">Ratable id of the NPS rating.</param>
        /// <param name="ratable_type">Type of the NPS rating.</param>
        /// <returns>List of <seealso cref="Models.Nps">NPS</seealso> matching the parameters.</returns>
        [Route("ratings")]
        public IHttpActionResult GetRatings([Optional] [DefaultParameterValue("empty string")] string ratable_id, [Optional] [DefaultParameterValue("empty string")] string ratable_type)
        {
            return NotFound();
        }

        /// <summary>
        /// Returns a single NPS rating based on its ID.
        /// </summary>
        /// <param name="id">Id of the NPS rating.</param>
        /// <returns>An <seealso cref="Models.Nps">NPS</seealso> matching the id.</returns>
        [Route("ratings")]
        public IHttpActionResult GetRating(string id)
        {
            return NotFound();
        }

        /// <summary>
        /// Creates a new NPS rating.
        /// </summary>
        /// <param name="nps">The NPS to create (id is ignored).</param>
        /// <returns>Created <seealso cref="Models.Nps">NPS</seealso>.</returns>
        [Route("ratings")]
        [HttpPost]
        [ResponseType(typeof(Models.Nps))]
        public IHttpActionResult CreateRating([FromBody] Models.Nps nps)
        {
            return NotFound();
        }

        /// <summary>
        /// Updates an existing NPS rating.
        /// </summary>
        /// <param name="id">Id of the NPS to update.</param>
        /// <param name="nps">The NPS to update.</param>
        /// <returns>Updated <seealso cref="Models.Nps">NPS</seealso>.</returns>
        [Route("ratings/{id}")]
        [HttpPut]
        [ResponseType(typeof(Models.Nps))]
        public IHttpActionResult UpdateRating(string id, [FromBody] Models.Nps nps)
        {
            return NotFound();
        }
    }
}
