using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Nest
{
	public partial class ElasticClient
    {
        /// <summary>
        /// Gets the health status of the cluster, at the specified level, for the specified indexes.
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        public INodeInfoResponse NodeInfo(NodeInfoParams nodeInfoParams)
        {
            var path = this.PathResolver.CreateNodePath();
            return this._NodeInfo(path, nodeInfoParams);
        }

        private NodeInfoResponse _NodeInfo(string path, NodeInfoParams nodeInfoParams)
        {
            var infoOn = nodeInfoParams.InfoOn;
            if (infoOn.HasFlag(NodesInfo.All))
            {
                path += "?all=true";
            }
            else
            {
                var options = new List<string>();
                if(infoOn.HasFlag(NodesInfo.Settings))
                    options.Add("settings=true");
                if (infoOn.HasFlag(NodesInfo.OS))
                    options.Add("os=true");
                if (infoOn.HasFlag(NodesInfo.Process))
                    options.Add("process=true");
                if (infoOn.HasFlag(NodesInfo.JVM))
                    options.Add("jvm=true");
                if (infoOn.HasFlag(NodesInfo.ThreadPool))
                    options.Add("thread_pool=true");
                if (infoOn.HasFlag(NodesInfo.Network))
                    options.Add("network=true");
                if (infoOn.HasFlag(NodesInfo.Transport))
                    options.Add("transport=true");
                if (infoOn.HasFlag(NodesInfo.HTTP))
                    options.Add("http=true");
                path += "?" + string.Join("&", options);
            }

            var status = this.Connection.GetSync(path);
            var r = this.ToParsedResponse<NodeInfoResponse>(status);
            return r;
        }
	}
}
