using Leo.ControleCertificacoes.Core.Application.Dtos.Employee;
using Leo.ControleCertificacoes.Core.Domain.Entities;

namespace Leo.ControleCertificacoes.Core.Application.Mapper
{
    public static class EmployeeMap
    {
        #region "Employee"

        public static Employee ToEmployee(this EmployeeCreateDto Employee)
        {
            return new Employee
            {
                Name = Employee.Name,
                Department = Employee.Department
            };
        }

        #endregion

        #region "EmployeeCreateDto"

        public static EmployeeCreateDto ToEmployeeCreateDto(this Employee Employee)
        {
            return new EmployeeCreateDto
            {
                Name = Employee.Name,
                Department = Employee.Department
            };
        }

        #endregion

        #region "EmployeeReadDto"

        public static EmployeeReadDto ToEmployeeReadDto(this Employee Employee)
        {
            return new EmployeeReadDto
            {
                Name = Employee.Name,
                Department = Employee.Department,
                NumberOfCertifieds = Employee.NumberOfCertifieds
            };
        }

        #endregion
    }
}
