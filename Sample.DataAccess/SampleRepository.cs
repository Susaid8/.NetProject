using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.DataAccess
{
    public class SampleRepository : ISampleRepository
    {
        private readonly SampleContext _context;
        public SampleRepository(SampleContext context)
        {
            _context= context;
        }
        public async Task<SampleEntity> AddSample(SampleEntity entity)
        {
            var result = await _context.Samples.AddAsync(entity);
            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task DeleteSample(int id)
        {
            var entity = _context.Samples.SingleOrDefault(s => s.Id == id);
             _context.Remove(entity);
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<SampleEntity>> GetSamples()
        {
            var results = await _context.Samples.ToListAsync();
            return results;
        }

        public async Task<SampleEntity> GetSampleById(int id)
        {
            var entity = await _context.Samples.SingleOrDefaultAsync(s => s.Id == id);
            return entity;
        }
    }
}
