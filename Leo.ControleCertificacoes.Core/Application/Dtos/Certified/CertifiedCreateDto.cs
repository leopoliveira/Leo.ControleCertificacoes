using System.ComponentModel.DataAnnotations;

namespace Leo.ControleCertificacoes.Core.Application.Dtos.Certified
{
    public record CertifiedCreateDto
    {
        [Required]
        [StringLength(256)]
        public string Name { get; set; } = null!;

        [Required]
        [DataType(DataType.Date)]
        public DateOnly Expiration { get; set; }

        [StringLength(256)]
        public string? Description { get; set; }

        [Required]
        public Guid EmployeeId { get; set; }
    }
}
