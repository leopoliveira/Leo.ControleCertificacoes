using Leo.ControleCertificacoes.Core.Domain.Entities;
using Leo.ControleCertificacoes.Core.Infra.AppDbContext;
using Leo.ControleCertificacoes.Core.Repository.Implementation.Generic;
using Leo.ControleCertificacoes.Core.Repository.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace Leo.ControleCertificacoes.Core.Repository.Implementation
{
    internal class CertifiedRepository : RepositoryBase<Certified>, ICertifiedRepository
    {
        private readonly AppDbContext _context;

        public CertifiedRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Certified>> GetByEmployeeCode(int employeeCode)
        {
            return await _context.Certifieds
                .AsNoTracking()
                .Where(x => x.Employee.Code == employeeCode)
                .ToListAsync();
        }
    }
}
