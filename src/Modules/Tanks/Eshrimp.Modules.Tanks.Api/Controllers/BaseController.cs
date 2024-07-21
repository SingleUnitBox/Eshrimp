using Microsoft.AspNetCore.Mvc;

namespace Eshrimp.Modules.Tanks.Api.Controllers
{
    [ApiController]
    [Route(TanksModule.BasePath + "/[controller]")]
    internal class BaseController : ControllerBase
    {
    }
}
