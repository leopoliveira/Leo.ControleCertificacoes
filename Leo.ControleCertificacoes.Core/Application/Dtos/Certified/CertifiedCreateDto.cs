namespace Leo.ControleCertificacoes.Core.Application.Dtos.Certified
{
    public record CertifiedCreateDto
    {
        public string Name { get; set; } = null!;

        public DateOnly Expiration { get; set; }

        public string? Description { get; set; }

        public Guid EmployeeId { get; set; }
    }
}
