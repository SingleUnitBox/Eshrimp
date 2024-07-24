using Eshrimp.Modules.Tanks.Application.Commands;
using Eshrimp.Shared.Abstractions.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Eshrimp.Modules.Tanks.Api.Controllers
{
    internal sealed class TanksController : BaseController
    {
        private readonly ICommandDispatcher _commandDispatcher;

        public TanksController(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }

        [HttpPost]
        public async Task<ActionResult> AddTank(AddTank command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return NoContent();
        }
    }
}
