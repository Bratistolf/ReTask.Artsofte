using Microsoft.EntityFrameworkCore;
using ReTask.Artsofte.Application.Common.Exceptions;
using ReTask.Artsofte.Application.Common.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ReTask.Artsofte.Infrastructure.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly IArtsofteDbContext _artsofteDbContext;

        public GenericRepository(IArtsofteDbContext artsofteDbContext)
        {
            _artsofteDbContext = artsofteDbContext;
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _artsofteDbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            T entity = await _artsofteDbContext.Set<T>().FindAsync(id);
            if (entity is null)
            {
                throw new NotFoundException($"The resource with ID `{id}` was not found.");
            }
            return entity;
        }

        public async Task AddAsync(T entity, CancellationToken cancellationToken)
        {
            _artsofteDbContext.Set<T>().Add(entity);
            await _artsofteDbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(T entity, CancellationToken cancellationToken)
        {
            _artsofteDbContext.Set<T>().Update(entity);
            await _artsofteDbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(T entity, CancellationToken cancellationToken)
        {
            _artsofteDbContext.Set<T>().Remove(entity);
            await _artsofteDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
