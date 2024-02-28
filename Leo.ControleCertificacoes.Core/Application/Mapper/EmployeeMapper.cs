using Leo.ControleCertificacoes.Core.Application.Dtos.Employee;
using Leo.ControleCertificacoes.Core.Domain.Entities;

namespace Leo.ControleCertificacoes.Core.Application.Mapper
{
    public static class EmployeeMapper
    {
        #region "Employee"

        public static Employee ToEmployee(this EmployeeCreateDto employee)
        {
            return new Employee
            {
                Name = employee.Name,
                Department = employee.Department
            };
        }

        #endregion

        #region "EmployeeCreateDto"

        public static EmployeeCreateDto ToEmployeeCreateDto(this Employee employee)
        {
            return new EmployeeCreateDto
            {
                Name = employee.Name,
                Department = employee.Department
            };
        }

        #endregion

        #region "EmployeeReadDto"

        public static EmployeeDto ToEmployeeDto(this Employee employee)
        {
            return new EmployeeDto
            {
                Id = employee.Id,
                Code = employee.Code,
                Name = employee.Name,
                Department = employee.Department,
                NumberOfCertifieds = employee.NumberOfCertifieds
            };
        }

        public static Employee ToEmployee(this EmployeeDto employee)
        {
            return new Employee
            {
                Id = employee.Id,
                Code = employee.Code,
                Name = employee.Name,
                Department = employee.Department,
                NumberOfCertifieds = employee.NumberOfCertifieds
            };
        }

        #endregion
    }
}
