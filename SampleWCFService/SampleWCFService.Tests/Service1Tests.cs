using System.Threading.Tasks;
using NUnit.Framework;

namespace SampleWCFService.Tests
{
    [TestFixture]
    public class Service1Tests
    {
        [Test]
        public async Task Test_operation()
        {
            var client = new Service1Client(TestHosts.Binding, TestHosts.Service1Address);
            var result = await client.GetDataUsingDataContractAsync(new CompositeType
            {
                BoolValue = true,
                StringValue = "Hello!"
            });

            Assert.AreEqual("Hello!Suffix", result.StringValue);
        }
    }
}