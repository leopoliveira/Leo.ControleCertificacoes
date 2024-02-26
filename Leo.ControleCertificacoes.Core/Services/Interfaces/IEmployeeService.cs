using Leo.ControleCertificacoes.Core.Application.Dtos.Employee;

namespace Leo.ControleCertificacoes.Core.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<EmployeeReadDto> GetByIdAsync(Guid id);

        Task<EmployeeReadDto> GetByCodeAsync(int code);

        Task<int> CountAsyncAsync();

        Task<int> InsertAsync(EmployeeCreateDto dto);

        Task<int> UpdateAsync(EmployeeReadDto dto);

        Task<int> DeleteAsync(EmployeeReadDto dto);
    }
}
