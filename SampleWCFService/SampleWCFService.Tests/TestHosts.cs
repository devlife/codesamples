using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace SampleWCFService.Tests
{
    internal static class TestHosts
    {
        internal static NetNamedPipeBinding Binding;

        internal static EndpointAddress Service1Address;

        private static ServiceHost _service1ServiceHost;

        internal static void InitializeServiceHosts()
        {
            var baseAddress = new Uri("net.pipe://localhost/" + Guid.NewGuid());

            Binding = new NetNamedPipeBinding
            {
                TransactionFlow = true,
                SendTimeout = TimeSpan.FromMinutes(5)  // useful when debugging and stepping through code
            };

            var service1Uri = new Uri(baseAddress, "/Service1.svc");

            Service1Address = new EndpointAddress(service1Uri);

            var directory = new DirectoryCatalog(AppDomain.CurrentDomain.BaseDirectory);
            var container = new CompositionContainer(directory);

            _service1ServiceHost = CreateHost<IService1>(container, service1Uri);
        }

        private static ServiceHost CreateHost<TContract>(CompositionContainer container, Uri uri)
        {
            var manager = container.GetExportedValue<TContract>();

            var host = new ServiceHost(manager, uri);

            host.AddServiceEndpoint(typeof(TContract), Binding, uri);
            host.Description.Behaviors.Find<ServiceBehaviorAttribute>().InstanceContextMode = InstanceContextMode.Single;
            host.Description.Behaviors.Find<ServiceDebugBehavior>().IncludeExceptionDetailInFaults = true;
            host.Open();

            return host;
        }

        internal static void CloseHosts()
        {
            _service1ServiceHost.Close();
        }
    }
}
