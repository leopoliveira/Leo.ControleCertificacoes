namespace Leo.ControleCertificacoes.Core.Application.Dtos.Certified
{
    public record CertifiedReadDto
    {
        public string Name { get; set; } = null!;

        public DateOnly Expiration { get; set; }

        public string? Description { get; set; }

        public string EmployeeName { get; set; }
    }
}
