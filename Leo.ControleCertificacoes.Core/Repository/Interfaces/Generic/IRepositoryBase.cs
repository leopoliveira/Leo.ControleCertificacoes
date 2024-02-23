using Leo.ControleCertificacoes.Core.Domain.Entities.Generic;

namespace Leo.ControleCertificacoes.Core.Repository.Interfaces.Generic
{
    public interface IRepositoryBase<TEntity> where TEntity : EntityWithIdAndCode
    {
        Task<TEntity> GetByIdAsync(Guid id);

        Task<TEntity> GetByCodeAsync(int code);

        Task<int> CountAsyncAsync();

        Task<int> InsertAsync(TEntity entity);

        Task<int> UpdateAsync(TEntity entity);

        Task<int> DeleteAsync(TEntity entity);
    }
}
