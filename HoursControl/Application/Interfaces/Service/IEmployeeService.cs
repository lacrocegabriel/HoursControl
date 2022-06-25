using HoursControl.Application.Model;

namespace HoursControl.Application.Interfaces.Service
{
    public interface IEmployeeService
    {
        Employee SerchRegister(Guid id);
        void AddRegister(Employee employee);
        void RemoveRegister(Guid id);
        void UpdateRegister(Employee employee);
    }
}
