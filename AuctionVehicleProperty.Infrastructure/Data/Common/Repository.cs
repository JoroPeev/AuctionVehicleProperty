using AuctionVehicleProperty.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AuctionVehicleProperty.Infrastructure.Data.Common
{

    public class Repository : IRepository
    {
        private readonly DbContext context;

        public Repository(ApplicationDbContext _context)
        {
            context = _context;
        }

        private DbSet<T> DbSet<T>() where T : class
        {
            return context.Set<T>();
        }

        public IQueryable<T> All<T>() where T : class
        {
            return DbSet<T>();
        }

        public IQueryable<T> AllReadOnly<T>() where T : class
        {
            return DbSet<T>()
                .AsNoTracking();
        }

        public async Task AddAsync<T>(T entity) where T : class
        {
            await DbSet<T>().AddAsync(entity);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await context.SaveChangesAsync();
        }

        public async Task<T?> GetByIdAsync<T>(object id) where T : class
        {
            return await DbSet<T>().FindAsync(id);
        }

        public async Task DeleteEntity<T>(int id) where T : class
        {
            var entity = await context.Set<T>().FindAsync(id);
            if (entity != null)
            {
                context.Set<T>().Remove(entity);
                await context.SaveChangesAsync();
            }
        }
        public async Task UpdateAsync<T>(T entity) where T : class
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
        public IQueryable<TEntity> Query<TEntity>() where TEntity : class
        {
            return context.Set<TEntity>();
        }
    }
}
