using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlukeTestApp.DataProvider.Abstractions;
using FlukeTestApp.DomainModels.Models;
using FlukeTestApp.Services.Abstractions;

namespace FlukeTestApp.Services
{
    internal class EventService : IEventService
    {
        private readonly IDataProvider _dataProvider;

        public EventService(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public async Task<List<Event>> GetFilteredAsync(int limit = 20, string source = "", int days = 365)
        {
            var result = await _dataProvider.Get(limit, source, days);

            return result.ToList();
        }

        public async Task<Event> GetByIdAsync(string id)
        {
            var result = await _dataProvider.Get(id);

            return result;
        }
    }
}