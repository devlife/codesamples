using ServiceModel.Composition;
using System.ComponentModel.Composition;
using System.Threading.Tasks;

namespace SampleWCFService
{
    [ExportService]
    [Export(typeof(IService1))]
    public class Service1 : IService1
    {
        private readonly ISomeDataService _dataService;

        [ImportingConstructor]
        public Service1(ISomeDataService dataService)
        {
            _dataService = dataService;
        }

        public async Task<CompositeType> GetDataUsingDataContractAsync(CompositeType composite)
        {
            return await _dataService.GetDataAsync(composite);
        }
    }
}