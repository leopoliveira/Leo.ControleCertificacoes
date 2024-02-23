using Leo.ControleCertificacoes.Core.Domain.Entities;
using Leo.ControleCertificacoes.Core.Infra.AppDbContext;
using Leo.ControleCertificacoes.Core.Repository.Implementation.Generic;
using Leo.ControleCertificacoes.Core.Repository.Interfaces;

namespace Leo.ControleCertificacoes.Core.Repository.Implementation
{
    public class CertifiedRepository : RepositoryBase<Certified>, ICertifiedRepository
    {
        public CertifiedRepository(AppDbContext context) : base(context)
        {
        }
    }
}
