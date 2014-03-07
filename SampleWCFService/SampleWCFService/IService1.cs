using System.ServiceModel;
using System.Threading.Tasks;

namespace SampleWCFService
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        Task<CompositeType> GetDataUsingDataContractAsync(CompositeType composite);
    }
}