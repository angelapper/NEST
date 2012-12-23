﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Nest
{
	public partial class ElasticClient
    {
        /// <summary>
        /// Gets the health status of the cluster.
        /// </summary>
        public INodeInfoResponse NodeInfo(NodesInfo nodesInfo)
        {
            var path = this.PathResolver.CreateNodePath();
            return _NodeInfo(path, nodesInfo);
        }

        /// <summary>
        /// Gets the health status of the cluster, for the specified nodes.
        /// </summary>
        public INodeInfoResponse NodeInfo(IEnumerable<string> nodes, NodesInfo nodesInfo)
        {
            var path = this.PathResolver.CreateNodePath(nodes);
            return _NodeInfo(path, nodesInfo);
        }

        public NodeInfoResponse _NodeInfo(string path, NodesInfo nodesInfo)
        {
            if (nodesInfo.HasFlag(NodesInfo.All))
            {
                path += "?all=true";
            }
            else
            {
                var options = new List<string>();
                if (nodesInfo.HasFlag(NodesInfo.Settings))
                    options.Add("settings=true");
                if (nodesInfo.HasFlag(NodesInfo.OS))
                    options.Add("os=true");
                if (nodesInfo.HasFlag(NodesInfo.Process))
                    options.Add("process=true");
                if (nodesInfo.HasFlag(NodesInfo.JVM))
                    options.Add("jvm=true");
                if (nodesInfo.HasFlag(NodesInfo.ThreadPool))
                    options.Add("thread_pool=true");
                if (nodesInfo.HasFlag(NodesInfo.Network))
                    options.Add("network=true");
                if (nodesInfo.HasFlag(NodesInfo.Transport))
                    options.Add("transport=true");
                if (nodesInfo.HasFlag(NodesInfo.HTTP))
                    options.Add("http=true");
                path += "?" + string.Join("&", options);
            }
            var status = this.Connection.GetSync(path);
            var r = this.ToParsedResponse<NodeInfoResponse>(status);
            return r;
        }

        /// <summary>
        /// Gets the health status of each node in the cluster, for the specified indexes.
        /// </summary>
        public INodeStatsResponse NodeStats(NodeStatsInfo nodeStatsInfo)
        {
            var path = this.PathResolver.CreateNodePath("stats");
            return this._NodeStats(path, nodeStatsInfo);
        }

        /// <summary>
        /// Gets the health status of each node in the cluster, for the specified indexes.
        /// </summary>
        public INodeStatsResponse NodeStats(IEnumerable<string> nodes, NodeStatsInfo nodeStatsInfo)
        {
            var path = this.PathResolver.CreateNodePath("stats");
            return this._NodeStats(path, nodeStatsInfo);
        }
        
        public NodeStatsResponse _NodeStats(string path, NodeStatsInfo nodeStatsInfo)
        {
            if (nodeStatsInfo.HasFlag(NodeStatsInfo.All))
            {
                path += "?all=true";
            }
            else
            {
                var options = new List<string>();
                if (nodeStatsInfo.HasFlag(NodeStatsInfo.FileSystem))
                    options.Add("fs=true");
                if (nodeStatsInfo.HasFlag(NodeStatsInfo.Indices))
                    options.Add("indices=true");
                if (nodeStatsInfo.HasFlag(NodeStatsInfo.OS))
                    options.Add("os=true");
                if (nodeStatsInfo.HasFlag(NodeStatsInfo.Process))
                    options.Add("process=true");
                if (nodeStatsInfo.HasFlag(NodeStatsInfo.JVM))
                    options.Add("jvm=true");
                if (nodeStatsInfo.HasFlag(NodeStatsInfo.ThreadPool))
                    options.Add("thread_pool=true");
                if (nodeStatsInfo.HasFlag(NodeStatsInfo.Network))
                    options.Add("network=true");
                if (nodeStatsInfo.HasFlag(NodeStatsInfo.Transport))
                    options.Add("transport=true");
                if (nodeStatsInfo.HasFlag(NodeStatsInfo.HTTP))
                    options.Add("http=true");
                path += "?" + string.Join("&", options);
            }
            var status = this.Connection.GetSync(path);
            var r = this.ToParsedResponse<NodeStatsResponse>(status);
            return r;
        }
	}
}
