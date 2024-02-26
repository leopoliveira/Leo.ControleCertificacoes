using Leo.ControleCertificacoes.Core.Application.Dtos.Employee;

namespace Leo.ControleCertificacoes.Core.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<EmployeeDto> GetByIdAsync(Guid id);

        Task<EmployeeDto> GetByCodeAsync(int code);

        Task<int> CountAsyncAsync();

        Task<int> InsertAsync(EmployeeCreateDto dto);

        Task<int> UpdateAsync(EmployeeDto dto);

        Task<int> DeleteAsync(EmployeeDto dto);
    }
}
