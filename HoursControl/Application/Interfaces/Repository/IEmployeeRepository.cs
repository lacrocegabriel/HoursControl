using HoursControl.Application.Model;

namespace HoursControl.Application.Interfaces.Repository
{
    public interface IEmployeeRepository
    {
        Employee SerchRegister(Guid id);
        Employee SearchForCPF(string cpf);
        void AddRegister(Employee employee);
        void UpdateRegister(Employee employee);
        void RemoveRegister(Guid id);

    }
}
