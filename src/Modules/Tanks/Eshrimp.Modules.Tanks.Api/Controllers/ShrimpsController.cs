using Eshrimp.Modules.Tanks.Application.Commands;
using Eshrimp.Modules.Tanks.Application.DTO;
using Eshrimp.Modules.Tanks.Application.Queries;
using Eshrimp.Shared.Abstractions.Commands;
using Eshrimp.Shared.Abstractions.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Eshrimp.Modules.Tanks.Api.Controllers
{
    internal sealed class ShrimpsController : BaseController
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;

        public ShrimpsController(ICommandDispatcher commandDispatcher,
            IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ShrimpDetailsDto>> GetShrimp(Guid id)
            => OkOrNotFound(await _queryDispatcher.QueryAsync(new GetShrimp(id)));

        [HttpPost]
        public async Task<ActionResult> AddShrimp(AddShrimp command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return CreatedAtAction(nameof(GetShrimp), new { id = command.Id }, null);
        }
    }
}
