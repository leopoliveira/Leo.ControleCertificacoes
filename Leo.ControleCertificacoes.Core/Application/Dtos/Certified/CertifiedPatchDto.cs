namespace Leo.ControleCertificacoes.Core.Application.Dtos.Certified
{
    public record CertifiedPatchDto
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public DateTime? Expiration { get; set; }

        public string? Description { get; set; }
    }
}
