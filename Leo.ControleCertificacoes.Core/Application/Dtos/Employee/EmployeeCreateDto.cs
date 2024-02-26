using System.ComponentModel.DataAnnotations;

namespace Leo.ControleCertificacoes.Core.Application.Dtos.Employee
{
    public record EmployeeCreateDto
    {
        [Required(ErrorMessage = "O {0} é obrigatório.")]
        [StringLength(256, ErrorMessage = "O {0} deve ter um tamanho máximo de {1}.")]
        [Display(Name = "Nome")]
        public string Name { get; set; } = null!;

        [StringLength(256, ErrorMessage = "O {0} deve ter um tamanho máximo de {1}.")]
        [Display(Name = "Departamento/Setor")]
        public string? Department { get; set; }
    }
}
