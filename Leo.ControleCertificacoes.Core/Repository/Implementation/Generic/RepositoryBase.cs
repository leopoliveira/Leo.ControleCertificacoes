using Leo.ControleCertificacoes.Core.Domain.Entities.Generic;
using Leo.ControleCertificacoes.Core.Infra.AppDbContext;
using Leo.ControleCertificacoes.Core.Repository.Interfaces.Generic;

using Microsoft.EntityFrameworkCore;

namespace Leo.ControleCertificacoes.Core.Repository.Implementation.Generic
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : EntityWithIdAndCode
    {
        private readonly AppDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public RepositoryBase(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public async Task<TEntity> GetByCodeAsync(int code)
        {
            return await _dbSet
                .AsNoTracking()
                .FirstOrDefaultAsync(entity => entity.Code == code);
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await _dbSet
                .AsNoTracking()
                .FirstOrDefaultAsync(entity => entity.Id == id);
        }

        public async Task<int> CountAsyncAsync()
        {
            return await _dbSet.CountAsync();
        }

        public async Task<int> InsertAsync(TEntity entity)
        {
            _dbSet.Add(entity);

            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.Entry(entity).Property(entity => entity.Code).IsModified = false;

            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(TEntity entity)
        {
            _dbSet.Remove(entity);

            return await _context.SaveChangesAsync();
        }
    }
}
