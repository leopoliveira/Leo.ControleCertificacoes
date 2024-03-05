using Leo.ControleCertificacoes.Core.Application.Dtos.Employee;
using Leo.ControleCertificacoes.Core.Application.Mapper;
using Leo.ControleCertificacoes.Core.Domain.Entities;
using Leo.ControleCertificacoes.Core.Enums;
using Leo.ControleCertificacoes.Core.Repository.Interfaces;
using Leo.ControleCertificacoes.Core.Services.Interfaces;

namespace Leo.ControleCertificacoes.Core.Services.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<EmployeeDto>> GetAll()
        {
            var employees = await _repository.GetAll();

            if (employees.Any())
            {
                return employees.Select(x => x.ToEmployeeDto());
            }

            return null;
        }

        public async Task<EmployeeDto> GetByIdAsync(Guid id)
        {
            Employee employee = await _repository.GetByIdAsync(id);

            if (employee is null)
            {
                return null;
            }

            return employee.ToEmployeeDto();
        }

        public async Task<EmployeeDto> GetByCodeAsync(int code)
        {
            Employee employee = await _repository.GetByCodeAsync(code);

            if (employee is null)
            {
                return null;
            }

            return employee.ToEmployeeDto();
        }

        public async Task<int> CountAsyncAsync()
        {
            return await _repository.CountAsyncAsync();
        }

        public async Task<EmployeeDto> InsertAsync(EmployeeCreateDto dto)
        {
            Employee employee = dto.ToEmployee();

            if (await _repository.InsertAsync(employee) == 0)
            {
                return null;
            }

            return await GetByIdAsync(employee.Id);
        }

        public async Task<EmployeeDto> UpdateAsync(EmployeePatchDto dto)
        {
            Employee employee = await _repository.GetByIdAsync(dto.Id);

            if (employee is null)
            {
                return null;
            }

            employee.PatchEmployee(dto);

            if (await _repository.UpdateAsync(employee) == 0)
            {
                return null;
            }

            return await GetByIdAsync(employee.Id);
        }

        public async Task UpdateNumberOfCertifiedsAsync(Guid employeeId, EnumDataBaseOperation operation)
        {
            Employee employee = await _repository.GetByIdAsync(employeeId) ?? throw new InvalidOperationException("There is no employee with this given id.");

            if (operation == EnumDataBaseOperation.INSERT)
            {
                employee.NumberOfCertifieds++;
            }
            else if (operation == EnumDataBaseOperation.DELETE)
            {
                employee.NumberOfCertifieds = employee.NumberOfCertifieds <= 0
                    ? 0
                    : employee.NumberOfCertifieds - 1;
            }

            _ = await _repository.UpdateAsync(employee);
        }

        public async Task<int> DeleteAsync(EmployeeDto dto)
        {
            Employee employee = await _repository.GetByIdAsync(dto.Id);

            if (employee is null)
            {
                return 0;
            }

            return await _repository.DeleteAsync(employee);
        }
    }
}
