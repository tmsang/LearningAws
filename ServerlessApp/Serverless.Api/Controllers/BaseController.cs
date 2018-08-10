using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;

namespace Serverless.Api.Controllers
{
    public abstract class BaseController : Controller
    {       
        protected IActionResult CreatedJsonResult(object value)
        {
            return new JsonResult(value)
            {
                StatusCode = (int)HttpStatusCode.Created
            };
        }
    }
}
