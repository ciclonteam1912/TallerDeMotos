using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace TallerDeMotos.Models.AtributosDeValidacion
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var modelState = actionContext.ModelState;

            if (!modelState.IsValid)
            {
                dynamic errors = new JsonObject();
                foreach (var key in modelState.Keys)
                {
                    var state = modelState[key];
                    if(state.Errors.Any()){
                        errors[key] = state.Errors.First().ErrorMessage;
                    }
                }

                actionContext.Response = actionContext.Request
                    .CreateErrorResponse(HttpStatusCode.BadRequest, modelState);
            }
               
        }
    }
}