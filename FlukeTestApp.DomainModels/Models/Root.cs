using System.Collections.Generic;

namespace FlukeTestApp.DomainModels.Models
{
    public class Root
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public List<Event> Events { get; set; }
    }
}