using Leo.ControleCertificacoes.Core.Application.Dtos.Base;

namespace Leo.ControleCertificacoes.Core.Application.Dtos.Certified
{
    public record CertifiedDto : BaseDtoWithIdAndCorde
    {
        public string Name { get; set; } = null!;

        public DateTime Expiration { get; set; }

        public string? Description { get; set; }

        public Guid EmployeeId { get; set; }
    }
}
