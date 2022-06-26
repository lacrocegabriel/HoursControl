using HoursControl.Application.Model;

namespace HoursControl.Application.Interfaces.Service
{
    public interface IEmployeeService
    {
        Employee SearchRegister(Guid id);
        Employee SearchForCPF(string cpf);
        void AddRegister(Employee employee);
        void RemoveRegister(Guid id);
        void UpdateRegister(Employee employee);
    }
}
