using Eshrimp.Modules.Tanks.Application.Commands;
using Eshrimp.Modules.Tanks.Application.DTO;
using Eshrimp.Modules.Tanks.Application.Queries;
using Eshrimp.Shared.Abstractions.Commands;
using Eshrimp.Shared.Abstractions.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Eshrimp.Modules.Tanks.Api.Controllers
{
    internal sealed class TanksController : BaseController
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;

        public TanksController(ICommandDispatcher commandDispatcher ,IQueryDispatcher queryDispatcher)
        {
            _queryDispatcher = queryDispatcher;
            _commandDispatcher = commandDispatcher;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TankDetailsDto>> GetTank(Guid id)
            => OkOrNotFound(await _queryDispatcher.QueryAsync(new GetTank(id)));

        [HttpPost]
        public async Task<ActionResult> AddTank(AddTank command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return NoContent();
        }
    }
}
