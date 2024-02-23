using Leo.ControleCertificacoes.Core.Domain.Entities;
using Leo.ControleCertificacoes.Core.Infra.AppDbContext;
using Leo.ControleCertificacoes.Core.Repository.Implementation.Generic;
using Leo.ControleCertificacoes.Core.Repository.Interfaces;

namespace Leo.ControleCertificacoes.Core.Repository.Implementation
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(AppDbContext context) : base(context)
        {
        }
    }
}
