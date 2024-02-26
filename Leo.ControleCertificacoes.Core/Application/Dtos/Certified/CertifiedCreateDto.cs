using System.ComponentModel.DataAnnotations;

namespace Leo.ControleCertificacoes.Core.Application.Dtos.Certified
{
    public record CertifiedCreateDto
    {
        [Required(ErrorMessage = "O {0} é obrigatório.")]
        [StringLength(256, ErrorMessage = "O {0} deve ter um tamanho máximo de {1}.")]
        [Display(Name = "Nome")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "O {0} é obrigatório.")]
        [DataType(DataType.Date, ErrorMessage = "Informe um formato válido para Data.")]
        [Display(Name = "Data de expiração")]
        public DateOnly Expiration { get; set; }

        [StringLength(256, ErrorMessage = "O {0} deve ter um tamanho máximo de {1}.")]
        [Display(Name = "Descrição")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "O {0} é obrigatório.")]
        [Display(Name = "Id do Funcionário")]
        public Guid EmployeeId { get; set; }
    }
}
