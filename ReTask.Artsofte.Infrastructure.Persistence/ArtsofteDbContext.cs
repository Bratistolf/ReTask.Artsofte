using Microsoft.EntityFrameworkCore;
using ReTask.Artsofte.Application.Common.Interfaces;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace ReTask.Artsofte.Infrastructure.Persistence
{
    public class ArtsofteDbContext : DbContext, IArtsofteDbContext
    {
        public ArtsofteDbContext(DbContextOptions<ArtsofteDbContext> options) : base(options)
        {
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}
