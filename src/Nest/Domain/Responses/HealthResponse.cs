using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Nest
{
    public interface IHealthResponse : IResponse
    {
        string ClusterName { get; }
        string Status { get; }
        bool TimedOut { get; }
        int NumberOfNodes { get; }
        int NumberOfDataNodes { get; }
        int ActivePrimaryShards { get; }
        int ActiveShards { get; }
        int RelocatingShards { get; }
        int InitializingShards { get; }
        int UnassignedShards { get; }
        Dictionary<string, IndexHealthStats> Indices { get; }
    }

    [JsonObject]
    public class HealthResponse : BaseResponse, IHealthResponse
    {
        public HealthResponse()
        {
            this.IsValid = true;
        }

        [JsonProperty(PropertyName = "cluster_name")]
        public string ClusterName { get; set; }
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
        [JsonProperty(PropertyName = "timed_out")]
        public bool TimedOut { get; set; }

        [JsonProperty(PropertyName = "number_of_nodes")]
        public int NumberOfNodes { get; set; }
        [JsonProperty(PropertyName = "number_of_data_nodes")]
        public int NumberOfDataNodes { get; set; }

        [JsonProperty(PropertyName = "active_primary_shards")]
        public int ActivePrimaryShards { get; set; }
        [JsonProperty(PropertyName = "active_shards")]
        public int ActiveShards { get; set; }
        [JsonProperty(PropertyName = "relocating_shards")]
        public int RelocatingShards { get; set; }
        [JsonProperty(PropertyName = "initializing_shards")]
        public int InitializingShards { get; set; }
        [JsonProperty(PropertyName = "unassigned_shards")]
        public int UnassignedShards { get; set; }

        [JsonProperty(PropertyName = "indices")]
        public Dictionary<string, IndexHealthStats> Indices { get; set; }
    }
}
