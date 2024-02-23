using Leo.ControleCertificacoes.Core.Domain.Entities.Generic;

namespace Leo.ControleCertificacoes.Core.Domain.Entities
{
    public class Employee : EntityWithIdAndCode
    {
        public string Name { get; set; } = null!;

        public string? Department { get; set; }

        public int NumberOfCertifieds { get; set; }
    }
}
