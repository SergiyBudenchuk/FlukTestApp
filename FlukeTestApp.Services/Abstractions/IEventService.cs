using System.Collections.Generic;
using System.Threading.Tasks;
using FlukeTestApp.DomainModels.Models;

namespace FlukeTestApp.Services.Abstractions
{
    public interface IEventService
    {
        Task<List<Event>> GetFilteredAsync(int limit = 20, string source = "", int days = 365);
        Task<Event> GetByIdAsync(string id);
    }
}