using System.Collections.Generic;
using System.Threading.Tasks;
using FlukeTestApp.DomainModels.Enums;
using FlukeTestApp.DomainModels.Models;
using FlukeTestApp.Models.Request;
using FlukeTestApp.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace FlukeTestApp.Controllers
{
    [Route("api/events")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventsController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Event>>> Get([FromQuery] EventsFilters filters)
        {
            var result = await _eventService
                .GetFilteredAsync(filters?.Limit ?? 20,
                    filters?.Source ?? string.Empty,
                    filters?.Days ?? 365,
                    filters?.OrderField ?? OrderField.Id,
                    filters?.OrderType ?? OrderType.Asc);

            return result;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> Get(string id)
        {
            var result = await _eventService.GetByIdAsync(id);
            return result;
        }
    }
}