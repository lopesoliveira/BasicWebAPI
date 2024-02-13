using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace AppSettings.BasicWebAPI.Application.Utils {
    public interface IDbContext : IDisposable {
        /// <summary>
        /// Interface to abstract the use of DbContext of Entity Framework. Add
        /// other methods as required
        /// </summary>
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
        ChangeTracker ChangeTracker { get; }
    }
}
