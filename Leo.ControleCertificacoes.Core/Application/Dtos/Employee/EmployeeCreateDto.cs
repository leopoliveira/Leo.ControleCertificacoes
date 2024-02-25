namespace Leo.ControleCertificacoes.Core.Application.Dtos.Employee
{
    public record EmployeeCreateDto
    {
        public string Name { get; set; } = null!;

        public string? Department { get; set; }
    }
}
