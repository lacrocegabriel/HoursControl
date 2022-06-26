using HoursControl.Application.Interfaces.Repository;
using HoursControl.Application.Interfaces.Service;
using HoursControl.Application.Model;

namespace HoursControl.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IRecordRepository _recordRepository;

        public EmployeeService(
            IEmployeeRepository employeeRepository, 
            IRecordRepository recordRepository)
        {
            _employeeRepository = employeeRepository;
            _recordRepository = recordRepository;
        }

        public Employee SearchRegister(Guid id)
        {
            return _employeeRepository.SearchRegister(id);
        }
        public Employee SearchForCPF(string cpf)
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
            if(_recordRepository.SearchForEmployee(id) != null) 
            {
                Console.WriteLine("Não é possível remover o funcionário, pois há tarefas cadastradas nesse CPF");
            }
            else
            {
                _employeeRepository.RemoveRegister(id);
            }
            
        }

        public void UpdateRegister(Employee record)
        {
            _employeeRepository.UpdateRegister(record);
        }
    }
}
