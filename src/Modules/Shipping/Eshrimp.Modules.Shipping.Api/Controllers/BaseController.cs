using Microsoft.AspNetCore.Mvc;

namespace Eshrimp.Modules.Shipping.Api.Controllers
{
    [ApiController]
    [Route(ShippingModule.BasePath + "/[controller]")]
    internal class BaseController : ControllerBase
    {

    }
}
