using Leo.ControleCertificacoes.Core.Domain.Entities.Generic;

namespace Leo.ControleCertificacoes.Core.Repository.Interfaces.Generic
{
    public interface IRepositoryBase<TEntity> where TEntity : EntityWithIdAndCode
    {
        Task<TEntity> GetById(Guid id);

        Task<TEntity> GetByCode(int code);

        Task<int> Insert(TEntity entity);

        Task Update(TEntity entity);

        Task DeleteById(Guid id);

        Task DeleteByCode(int code);
    }
}
