using System;
using System.Collections;

namespace FlukeTestApp.DataProvider.Models
{
    public class OriginalGeometry
    {
        public DateTimeOffset date { get; set; }
        public string type { get; set; }
        public ArrayList coordinates { get; set; }

    }
}
