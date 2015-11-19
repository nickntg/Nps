using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace ETravel.Nps.Service.Filters
{
    /// <summary>
    /// Apply this to an NPS Get operation with ratable id and type arguments.
    /// </summary>
    public class NpsGetAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            var response = Validate(actionContext.ActionArguments);
            if (response != null)
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(response.StatusCode, response.Message);
            }
        }

        /// <summary>
        /// Validates arguments. Public for easy testing.
        /// </summary>
        /// <param name="arguments"></param>
        /// <returns></returns>
        public ErrorResponse Validate(Dictionary<string, object> arguments)
        {
            if (arguments == null || arguments.Count != 2)
            {
                return new ErrorResponse { StatusCode = HttpStatusCode.BadRequest, Message = ValidationMessages.NoArguments };
            }

            var ratableId = arguments["ratable_id"] as string;
            var ratableType = arguments["ratable_type"] as string;

            if (string.IsNullOrEmpty(ratableId) && string.IsNullOrEmpty(ratableType))
            {
                return new ErrorResponse { StatusCode = (HttpStatusCode)422, Message = ValidationMessages.RatableIdAndTypeMustNotBothBeEmpty };
            }

            return null;
        }
    }
}