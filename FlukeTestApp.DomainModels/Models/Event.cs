using System.Collections.Generic;

namespace FlukeTestApp.DomainModels.Models
{
    public class Event
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public List<Category> Categories { get; set; }
        public List<Source> Sources { get; set; }
        public List<Geometrie> Geometries { get; set; }
    }
}