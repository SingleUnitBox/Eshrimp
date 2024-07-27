using Microsoft.AspNetCore.Mvc;

namespace Eshrimp.Modules.Store.Api.Controllers
{
    internal class StoreController : BaseController
    {
        [HttpGet]
        public ActionResult<string> Get() => "dsasadas";
    }
}
