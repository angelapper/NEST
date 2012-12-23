using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Nest
{
	[JsonObject]
	public class IndexingStats : IndexStats
	{
		[JsonProperty(PropertyName = "types")]
		public Dictionary<string, TypeStats> Types { get; set; }
	}
}
