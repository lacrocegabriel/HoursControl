using HoursControl.Application.Interfaces.Repository;
using HoursControl.Application.Interfaces.Service;
using HoursControl.Application.Model;

namespace HoursControl.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public Employee SerchRegister(Guid id)
        {
            return _employeeRepository.SerchRegister(id);
        }
        public Employee SerchForCPF(string cpf)
        {
            return _employeeRepository.SearchForCPF(cpf);
        }

        public void AddRegister(Employee record)
        {
            if (_employeeRepository.SearchForCPF(record.CPF) != null)
            {
                Console.WriteLine("O CPF informado já se encontra cadastrado");
            }
            else
            {
                _employeeRepository.AddRegister(record);
            }
        }

        public void RemoveRegister(Guid id)
        {
            _employeeRepository.RemoveRegister(id);
        }

        public void UpdateRegister(Employee record)
        {
            _employeeRepository.UpdateRegister(record);
        }
    }
}
