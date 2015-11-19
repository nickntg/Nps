﻿using System.Runtime.InteropServices;
using System.Web.Http;
using System.Web.Http.Description;
using ETravel.Nps.DataAccess.Repositories.Interfaces;
using ETravel.Nps.Service.Factories;
using ETravel.Nps.Service.Filters;

namespace ETravel.Nps.Service.Controllers
{
    /// <summary>
    /// The NPS service can be used to retrieve, create and update NPS ratings.
    /// </summary>
    public class NpsController : ApiController
    {
        public INpsRepository NpsRepository { get; set; }

        /// <summary>
        /// Returns a list of NPS ratings based on ratable ID and/or ratable type.
        /// </summary>
        /// <param name="ratable_id">Ratable id of the NPS rating.</param>
        /// <param name="ratable_type">Type of the NPS rating.</param>
        /// <returns>List of <seealso cref="Models.Nps">NPS</seealso> matching the parameters.</returns>
        [Route("ratings")]
        [NpsGet]
        [ResponseType(typeof(Models.Nps[]))]
        public IHttpActionResult GetRatings(string ratable_id = "", string ratable_type = "")
        {
            DataAccess.Entities.Nps[] nps = null;

            nps = string.IsNullOrEmpty(ratable_id)
                ? NpsRepository.RetrieveByRatableType(ratable_type)
                : string.IsNullOrEmpty(ratable_type)
                    ? NpsRepository.RetrieveByRatableId(ratable_id)
                    : NpsRepository.RetrieveByRatableTypeAndId(ratable_type, ratable_id);
            if (nps == null || nps.Length == 0)
            {
                return Ok(new Models.Nps[0]);
            }

            return Ok(nps.ToModel());
        }

        /// <summary>
        /// Returns a single NPS rating based on its ID.
        /// </summary>
        /// <param name="id">Id of the NPS rating.</param>
        /// <returns>An <seealso cref="Models.Nps">NPS</seealso> matching the id.</returns>
        [Route("ratings")]
        [ResponseType(typeof(Models.Nps))]
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
        [NpsPost]
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
