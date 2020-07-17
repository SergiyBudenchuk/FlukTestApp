using System.Collections.Generic;

namespace FlukeTestApp.DataProvider.Models
{
    public class OriginalRoot
    {
        public string title { get; set; }
        public string description { get; set; }
        public string link { get; set; }
        public List<OriginalEvent> events { get; set; }

    }
}
