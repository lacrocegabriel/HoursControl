using HoursControl.Application.Model;

namespace HoursControl.Application.Interfaces.Service
{
    public interface IEmployeeService
    {
        Employee SerchRegister(Guid id);
        Employee SerchForCPF(string cpf);
        void AddRegister(Employee employee);
        void RemoveRegister(Guid id);
        void UpdateRegister(Employee employee);
    }
}
