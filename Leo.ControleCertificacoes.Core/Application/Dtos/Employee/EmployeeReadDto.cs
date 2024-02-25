namespace Leo.ControleCertificacoes.Core.Application.Dtos.Employee
{
    public record EmployeeReadDto
    {
        public string Name { get; set; } = null!;

        public string? Department { get; set; }

        public int NumberOfCertifieds { get; set; }
    }
}
