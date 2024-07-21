﻿
using Eshrimp.Modules.Tanks.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Eshrimp.Modules.Tanks.Api.Controllers
{
    [Route(TanksModule.BasePath)]
    public class HomeController : BaseController
    {
        [HttpGet]
        //public ActionResult<string> Get() => "Tanks API";
        public ActionResult<string> Get() => throw new InvalidTankCapacityException(3.26);
    }
}
