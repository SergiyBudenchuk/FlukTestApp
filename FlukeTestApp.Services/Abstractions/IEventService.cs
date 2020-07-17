using System.Collections.Generic;
using System.Threading.Tasks;
using FlukeTestApp.DomainModels.Enums;
using FlukeTestApp.DomainModels.Models;

namespace FlukeTestApp.Services.Abstractions
{
    public interface IEventService
    {
        Task<List<Event>> GetFilteredAsync(int limit, string source, int days, OrderField f, OrderType t);
        Task<Event> GetByIdAsync(string id);
    }
}