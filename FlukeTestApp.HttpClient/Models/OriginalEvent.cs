using System.Collections.Generic;

namespace FlukeTestApp.DataProvider.Models
{
    public class OriginalEvent
    {
        public string id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string link { get; set; }
        public List<OriginalCategory> categories { get; set; }
        public List<OriginalSource> sources { get; set; }
        public List<OriginalGeometry> geometries { get; set; }

    }
}
