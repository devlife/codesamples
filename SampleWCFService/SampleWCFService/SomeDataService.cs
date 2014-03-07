using System;
using System.ComponentModel.Composition;
using System.Threading.Tasks;

namespace SampleWCFService
{
    [Export(typeof(ISomeDataService))]
    internal class SomeDataService : ISomeDataService
    {
        public async Task<CompositeType> GetDataAsync(CompositeType composite)
        {
            return await Task.Run(() =>
            {
                if (composite == null)
                {
                    throw new ArgumentNullException("composite");
                }
                if (composite.BoolValue)
                {
                    composite.StringValue += "Suffix";
                }
                return composite;
            });
        }
    }
}