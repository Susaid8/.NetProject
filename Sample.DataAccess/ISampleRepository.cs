using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.DataAccess
{
    public interface ISampleRepository
    {
        Task<SampleEntity> AddSample(SampleEntity entity);
        Task<IEnumerable<SampleEntity>> GetSamples();
        Task<SampleEntity> GetSampleById(int id);
        Task DeleteSample(int id);

    }
}
