using Microsoft.AspNetCore.Mvc;

namespace Eshrimp.Modules.Store.Api.Controllers
{
    [Route(StoreModule.BasePath)]
    internal class HomeController : BaseController
    {
        [HttpGet]
        public ActionResult<string> Get() => "Store API";
    }
}
