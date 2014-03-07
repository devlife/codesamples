using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;

namespace SampleWCFService
{
    public class Service1Client : ClientBase<IService1>, IService1
    {
        public Service1Client(Binding binding, EndpointAddress address)
            : base(binding, address)
        {

        }

        public async Task<CompositeType> GetDataUsingDataContractAsync(CompositeType composite)
        {
            return await Channel.GetDataUsingDataContractAsync(composite);
        }
    }
}