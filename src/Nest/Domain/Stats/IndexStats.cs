using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Nest
{
    [JsonObject]
    public class IndexStats
    {
        [JsonProperty(PropertyName = "index_total")]
        public int Total { get; internal set; }
        [JsonProperty(PropertyName = "index_time")]
        public string Time { get; internal set; }
        [JsonProperty(PropertyName = "index_time_in_millis")]
        public double TimeInMilliseconds { get; internal set; }
        [JsonProperty(PropertyName = "index_current")]
        public int Current { get; internal set; }
        [JsonProperty(PropertyName = "delete_total")]
        public int DeleteTotal { get; internal set; }
        [JsonProperty(PropertyName = "delete_time")]
        public string DeleteTime { get; internal set; }
        [JsonProperty(PropertyName = "delete_time_in_millis")]
        public double DeleteTimeInMilliseconds { get; internal set; }
        [JsonProperty(PropertyName = "delete_current")]
        public int DeleteCurrent { get; internal set; }
    }
}
