using Leo.ControleCertificacoes.Core.Domain.Entities.Generic;

namespace Leo.ControleCertificacoes.Core.Domain.Entities
{
    public class Certified : EntityWithIdAndCode
    {
        public string Name { get; set; } = null!;

        public DateOnly Expiration { get; set; }

        public string? Description { get; set; }

        public Guid EmployeeId { get; set; }
        public Employee Employee{ get; set; } = null!;
    }
}
