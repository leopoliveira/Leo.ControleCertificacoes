using System.Runtime.Serialization;

using Leo.ControleCertificacoes.Core.Domain.Entities.Generic;
using Leo.ControleCertificacoes.Core.Infra.AppDbContext;
using Leo.ControleCertificacoes.Core.Repository.Interfaces.Generic;

using Microsoft.EntityFrameworkCore;

namespace Leo.ControleCertificacoes.Core.Repository.Implementation.Generic
{
    internal class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : EntityWithIdAndCode
    {
        private readonly AppDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        protected readonly int MinCode = 1;
        protected readonly int MaxCode = 999999;

        public RepositoryBase(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public virtual async Task<TEntity> GetByCodeAsync(int code)
        {
            return await _dbSet
                .AsNoTracking()
                .FirstOrDefaultAsync(entity => entity.Code == code);
        }

        public virtual async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await _dbSet
                .AsNoTracking()
                .FirstOrDefaultAsync(entity => entity.Id == id);
        }

        public virtual async Task<int> CountAsyncAsync()
        {
            return await _dbSet.CountAsync();
        }

        public virtual async Task<int> InsertAsync(TEntity entity)
        {
            entity.Code = await GenerateCode();

            _dbSet.Add(entity);

            return await _context.SaveChangesAsync();
        }

        public virtual async Task<int> UpdateAsync(TEntity entity)
        {
            _dbSet.Update(entity);

            return await _context.SaveChangesAsync();
        }

        public virtual async Task<int> DeleteAsync(TEntity entity)
        {
            _dbSet.Remove(entity);

            return await _context.SaveChangesAsync();
        }

        protected async Task<int> GenerateCode()
        {
            List<int> codeList = await _dbSet
                .AsNoTracking()
                .Select(entity => entity.Code)
                .ToListAsync();

            if (codeList.Count < MinCode)
            {
                return MinCode;
            }

            int newCode = codeList.Max() + 1;

            if (newCode + 1  > MaxCode)
            {
                var codeRange = Enumerable.Range(MinCode, MaxCode - MinCode);

                int code = codeRange
                    .Except(codeList)
                    .FirstOrDefault();

                if (code == 0)
                {
                    throw new ArgumentOutOfRangeException("The code sequence limit was reached.");
                }

                return code;
            }

            return newCode;
        }
    }
}
