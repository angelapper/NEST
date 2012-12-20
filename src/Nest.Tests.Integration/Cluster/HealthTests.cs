using Nest.Tests.MockData.Domain;
using NUnit.Framework;

namespace Nest.Tests.Integration.Cluster
{
	[TestFixture]
	public class HealthTests : BaseElasticSearchTests
	{
		[Test]
		public void ClusterHealth()
		{
		    var r = this.ConnectedClient.Health(HealthLevel.Cluster);
		    Assert.True(r.IsValid);
		}
		[Test]
		public void IndexHealth()
        {
            var r = this.ConnectedClient.Health(HealthLevel.Indices);
            Assert.True(r.IsValid);
		}
        [Test]
        public void ShardHealth()
        {
            var r = this.ConnectedClient.Health(HealthLevel.Shards);
            Assert.True(r.IsValid);
        }
        [Test]
        public void DetailedHealth()
        {
            var r = this.ConnectedClient.Health(new HealthParams
                {
                    CheckLevel = HealthLevel.Shards,
                    Timeout = "30s",
                    WaitForMinNodes = 1,
                    WaitForRelocatingShards = 0
                });
            Assert.True(r.IsValid);
        }
	}
}