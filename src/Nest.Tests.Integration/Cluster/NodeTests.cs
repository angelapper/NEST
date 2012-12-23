using System.Linq;
using Nest.Tests.MockData.Domain;
using NUnit.Framework;

namespace Nest.Tests.Integration.Cluster
{
	[TestFixture]
	public class NodeTests : BaseElasticSearchTests
	{
	    [Test]
	    public void NodeInfo()
	    {
	        var r = this.ConnectedClient.NodeInfo(NodesInfo.All);
	        Assert.True(r.IsValid);
	        Assert.IsNotNull(r.Nodes);
	        var node = r.Nodes.Values.First();
	        Assert.IsNotNull(node.Settings);
	        Assert.IsNotNull(node.OS);
	        Assert.IsNotNull(node.Process);
	        Assert.IsNotNull(node.JVM);
	        Assert.IsNotNull(node.ThreadPool);
	        Assert.IsNotNull(node.Network);
	        Assert.IsNotNull(node.Transport);
	        Assert.IsNotNull(node.HTTP);
	    }

        [Test]
        public void NodeStats()
        {
            var r = this.ConnectedClient.NodeStats(NodeStatsInfo.All);
            Assert.True(r.IsValid);
            Assert.IsNotNull(r.Nodes);
            var node = r.Nodes.Values.First();
            Assert.IsNotNull(node.Indices);
            Assert.IsNotNull(node.FileSystem);
            Assert.IsNotNull(node.OS);
            Assert.IsNotNull(node.Process);
            Assert.IsNotNull(node.JVM);
            Assert.IsNotNull(node.ThreadPool);
            Assert.IsNotNull(node.Network);
            Assert.IsNotNull(node.Transport);
            Assert.IsNotNull(node.HTTP);
        }
	}
}