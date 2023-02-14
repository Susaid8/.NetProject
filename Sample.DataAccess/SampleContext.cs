using Microsoft.EntityFrameworkCore;

namespace Sample.DataAccess
{
    public class SampleContext : DbContext
    {
        public SampleContext(DbContextOptions<SampleContext> options) : base(options)
        {
                
        }

        public DbSet<SampleEntity> Samples { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SampleEntity>().ToTable("Sample");
        }
    }
}
