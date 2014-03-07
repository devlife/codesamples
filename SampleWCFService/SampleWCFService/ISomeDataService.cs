using System.Threading.Tasks;

namespace SampleWCFService
{
    public interface ISomeDataService
    {
        Task<CompositeType> GetDataAsync(CompositeType composite);
    }
}