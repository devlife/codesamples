using NUnit.Framework;

namespace SampleWCFService.Tests
{
    [SetUpFixture]
    public class AssemblyStartFinish
    {
        [SetUp]
        public void Setup()
        {
            TestHosts.InitializeServiceHosts();
        }

        [TearDown]
        public void TearDown()
        {
            TestHosts.CloseHosts();
        }
    }
}