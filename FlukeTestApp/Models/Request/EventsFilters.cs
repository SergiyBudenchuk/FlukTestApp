namespace FlukeTestApp.Models.Request
{
    public class EventsFilters
    {
        public int? Limit { get; set; }
        public string Source { get; set; }
        public int? Days { get; set; }
    }
}