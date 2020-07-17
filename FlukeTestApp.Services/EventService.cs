using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlukeTestApp.DataProvider.Abstractions;
using FlukeTestApp.DomainModels.Enums;
using FlukeTestApp.DomainModels.Models;
using FlukeTestApp.Services.Abstractions;

namespace FlukeTestApp.Services
{
    internal class EventService : IEventService
    {
        private readonly IDataProvider _dataProvider;

        private readonly Dictionary<OrderField, Func<Event, object>> _orderingContainer =
            new Dictionary<OrderField, Func<Event, object>>
            {
                {OrderField.Id, x => x.Id},
                {OrderField.Description, x => x.Description},
                {OrderField.Link, x => x.Link},
                {OrderField.Title, x => x.Title}
            };


        public EventService(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public async Task<List<Event>> GetFilteredAsync(int limit, string source, int days, OrderField field,
            OrderType type)
        {
            var data = await _dataProvider.Get(limit, source, days);

            var result = type == OrderType.Asc
                ? data.OrderBy(_orderingContainer[field])
                : data.OrderByDescending(_orderingContainer[field]);

            return result.ToList();
        }

        public async Task<Event> GetByIdAsync(string id)
        {
            var result = await _dataProvider.Get(id);

            return result;
        }
    }
}