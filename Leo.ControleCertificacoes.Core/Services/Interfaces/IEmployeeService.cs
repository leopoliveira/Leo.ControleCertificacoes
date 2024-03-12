using Leo.ControleCertificacoes.Core.Application.Dtos.Employee;
using Leo.ControleCertificacoes.Core.Enums;

namespace Leo.ControleCertificacoes.Core.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDto>> GetAll();

        Task<EmployeeDto> GetByIdAsync(Guid id);

        Task<EmployeeDto> GetByCodeAsync(int code);

        Task<int> CountAsyncAsync();

        Task<EmployeeDto> InsertAsync(EmployeeCreateDto dto);

        Task<EmployeeDto> UpdateAsync(EmployeePatchDto dto);

        Task UpdateNumberOfCertifiedsAsync(Guid employeeId, EnumDataBaseOperation operation);

        Task<int> DeleteAsync(Guid id);
    }
}
