using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace ETravel.Nps.Service.Filters
{
    /// <summary>
    /// Apply this to an NPS POST operation to validate the NPS model.
    /// </summary>
    public class NpsPostAttribute : ActionFilterAttribute
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
            if (arguments == null || arguments.Count != 1)
            {
                return new ErrorResponse {StatusCode = HttpStatusCode.BadRequest, Message = ValidationMessages.NoNpsArguments};
            }

            var validator = new NpsValidator();
            var results = validator.Validate(arguments["nps"] as Models.Nps);
            if (!results.IsValid)
            {
                return new ErrorResponse
                {
                    StatusCode = (HttpStatusCode) results.Errors[0].CustomState,
                    Message = results.Errors[0].ErrorMessage
                };
            }

            return null;
        }
    }
}