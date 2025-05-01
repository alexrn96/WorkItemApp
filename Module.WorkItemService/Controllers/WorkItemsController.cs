using Microsoft.AspNetCore.Mvc;
using Module.WorkItemService.Shared.DataTransferObjects;
using Module.WorkItemService.Shared.Interfaces;

namespace Module.WorkItemService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkItemsController : ControllerBase
    {
        private readonly IWorkItemService _service;

        public WorkItemsController(IWorkItemService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var item = await _service.GetByIdAsync(id);
            return item == null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] WorkItemDto item)
        {
            var created = await _service.CreateAsync(item);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}/complete")]
        public async Task<IActionResult> Complete(Guid id)
        {
            await _service.MarkAsCompletedAsync(id);
            return NoContent();
        }

        [HttpGet("by-user/{username}")]
        public async Task<IActionResult> GetByUser(string username) => Ok(await _service.GetByUserAsync(username));

        [HttpGet("stats")]
        public async Task<IActionResult> GetStats() => Ok(await _service.GetPendingStatsAsync());
        
    }
}
