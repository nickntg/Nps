using System.Linq;
using System.Net.Http;

namespace ETravel.Nps.Service.Filters
{
    /// <summary>
    /// Apply this to an NPS PUT operation to validate the NPS model.
    /// </summary>
    public class NpsPutAttribute : NpsPostAttribute
    {
        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            var args = actionContext.ActionArguments.Keys.Where(key => key != "id")
                .ToDictionary(key => key, key => actionContext.ActionArguments[key]);

            var response = Validate(args, true);
            if (response != null)
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(response.StatusCode, response.Message);
            }
        }
    }
}