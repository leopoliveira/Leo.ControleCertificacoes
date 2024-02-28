namespace Leo.ControleCertificacoes.Core.Application.Dtos.Employee
{
    public record EmployeePatchDto
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? Department { get; set; }
    }
}
