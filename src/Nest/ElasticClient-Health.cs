using System;
using System.Linq.Expressions;
using System.Text;

namespace Nest
{
	public partial class ElasticClient
    {
        /// <summary>
        /// Gets the health status of the cluster, at the specified level.
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        public IHealthResponse Health(HealthLevel level)
        {
            return this._Health(new HealthParams {CheckLevel = level});
        } 

		/// <summary>
		/// Gets the health status of the cluster according to the healthparams passed.
		/// </summary>
		/// <param name="healthParams"></param>
		/// <returns></returns>
		public IHealthResponse Health(HealthParams healthParams)
		{
			return this._Health(healthParams);
		} 

		private HealthResponse _Health(HealthParams healthParams)
		{
		    var path = this.PathResolver.CreateClusterPath("health") + "?level=";
		    path += (healthParams.CheckLevel ?? HealthLevel.Cluster).ToString().ToLower();

		    if (!healthParams.Timeout.IsNullOrEmpty())
		        path += "&timeout=" + healthParams.Timeout;
		    if (healthParams.WaitForMinNodes.HasValue)
		        path += "&wait_for_nodes=" + healthParams.WaitForMinNodes;
		    if (healthParams.WaitForStatus.HasValue)
		        path += "&wait_for_status=" + healthParams.WaitForStatus.Value.ToString().ToLower();
		    if (healthParams.WaitForRelocatingShards.HasValue)
		        path += "&wait_for_relocating_shards=" + healthParams.WaitForRelocatingShards;

			var status = this.Connection.GetSync(path);
		    var r = this.ToParsedResponse<HealthResponse>(status);
			return r;
		}
	}
}
