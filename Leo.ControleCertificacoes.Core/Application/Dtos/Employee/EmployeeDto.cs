using Leo.ControleCertificacoes.Core.Application.Dtos.Base;

namespace Leo.ControleCertificacoes.Core.Application.Dtos.Employee
{
    public record EmployeeDto : BaseDtoWithIdAndCode
    {
        public string Name { get; set; } = null!;

        public string? Department { get; set; }

        public int NumberOfCertifieds { get; set; }
    }
}
