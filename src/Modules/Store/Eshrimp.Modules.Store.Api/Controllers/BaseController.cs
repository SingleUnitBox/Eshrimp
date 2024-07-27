using Microsoft.AspNetCore.Mvc;

namespace Eshrimp.Modules.Store.Api.Controllers
{
    [ApiController]
    [Route(StoreModule.BasePath + "/[controller]")]
    internal class BaseController : ControllerBase
    {
        public ActionResult<T> OkOrNotFound<T>(T model)
        {
            if (model is null)
            {
                return NotFound();
            }

            return Ok(model);
        }
    }
}
