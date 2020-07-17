using System;
using System.Collections;

namespace FlukeTestApp.DomainModels.Models
{
    public class Geometrie
    {
        public DateTimeOffset Date { get; set; }
        public string Type { get; set; }
        public ArrayList Coordinates { get; set; }
    }
}
