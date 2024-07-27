using Microsoft.AspNetCore.Mvc;

namespace Eshrimp.Modules.Shipping.Api.Controllers
{
    [Route(ShippingModule.BasePath)]
    internal class HomeController : BaseController
    {
        public ActionResult<string> Get() => "Shipping API";
    }
}
