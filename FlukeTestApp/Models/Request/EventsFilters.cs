using FlukeTestApp.DomainModels.Enums;
using Newtonsoft.Json;

namespace FlukeTestApp.Models.Request
{
    public class EventsFilters
    {
        [JsonProperty("limit")]
        public int? Limit { get; set; }
        [JsonProperty("source")]
        public string Source { get; set; }
        [JsonProperty("days")]
        public int? Days { get; set; }
        [JsonProperty("orderField")]
        public OrderField OrderField { get; set; }
        [JsonProperty("orderType")]
        public OrderType OrderType { get; set; }
    }
}