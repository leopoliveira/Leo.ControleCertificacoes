using System.ComponentModel.DataAnnotations;

namespace Leo.ControleCertificacoes.Core.Application.Dtos.Employee
{
    public record EmployeeCreateDto
    {
        [Required]
        [StringLength(256)]
        public string Name { get; set; } = null!;

        [StringLength(256)]
        public string? Department { get; set; }
    }
}
