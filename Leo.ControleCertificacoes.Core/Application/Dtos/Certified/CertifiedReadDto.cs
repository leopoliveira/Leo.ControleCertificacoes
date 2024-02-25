using Leo.ControleCertificacoes.Core.Application.Dtos.Base;

namespace Leo.ControleCertificacoes.Core.Application.Dtos.Certified
{
    public record CertifiedReadDto : BaseDtoWithIdAndCorde
    {
        public string Name { get; set; } = null!;

        public DateOnly Expiration { get; set; }

        public string? Description { get; set; }

        public string EmployeeName { get; set; } = null!;
    }
}
