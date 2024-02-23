using Leo.ControleCertificacoes.Core.Domain.Entities.Generic;
using Leo.ControleCertificacoes.Core.Repository.Interfaces.Generic;

namespace Leo.ControleCertificacoes.Core.Repository.Implementation.Generic
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : EntityWithIdAndCode
    {
        public Task<TEntity> GetByCode(int code)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Insert(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByCode(int code)
        {
            throw new NotImplementedException();
        }

        public Task DeleteById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
