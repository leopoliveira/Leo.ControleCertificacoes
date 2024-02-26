using Leo.ControleCertificacoes.Core.Application.Dtos.Certified;
using Leo.ControleCertificacoes.Core.Application.Dtos.Employee;
using Leo.ControleCertificacoes.Core.Application.Mapper;
using Leo.ControleCertificacoes.Core.Domain.Entities;
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

        public async Task<EmployeeDto> GetByIdAsync(Guid id)
        {
            Employee employee = await _repository.GetByIdAsync(id);

            if (employee is null)
            {
                return null;
            }

            return employee.ToEmployeeReadDto();
        }

        public async Task<EmployeeDto> GetByCodeAsync(int code)
        {
            Employee employee = await _repository.GetByCodeAsync(code);

            if (employee is null)
            {
                return null;
            }

            return employee.ToEmployeeReadDto();
        }

        public async Task<int> CountAsyncAsync()
        {
            return await _repository.CountAsyncAsync();
        }

        public async Task<int> InsertAsync(EmployeeCreateDto dto)
        {
            Employee employee = dto.ToEmployee();

            return await _repository.InsertAsync(employee);
        }

        public async Task<int> UpdateAsync(EmployeeDto dto)
        {
            Employee employee = await _repository.GetByIdAsync(dto.Id);

            if (employee is null)
            {
                return 0;
            }

            employee = dto.ToEmployee();

            return await _repository.UpdateAsync(employee);
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
