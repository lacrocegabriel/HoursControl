using HoursControl.Application.Interfaces.Repository;
using HoursControl.Application.Model;

namespace HoursControl.Application.Repository
{
    internal class EmployeeRepository : IEmployeeRepository
    {
        public Employee SerchRegister(Guid id)
        {
            using var db = new ApplicationContext();
            var employee = db.Employees.FirstOrDefault(e => e.Id == id);
            return employee;
        }
        public Employee SearchForCPF(string cpf)
        {
            using var db = new ApplicationContext();
            var employee = db.Employees.FirstOrDefault(e => e.CPF == cpf);
            return employee;
        }

        public void AddRegister(Employee record)
        {
            using var context = new ApplicationContext();
            context.Employees.Add(record);
            context.SaveChanges();
        }

        public void RemoveRegister(Guid id)
        {
            using var db = new ApplicationContext();
            var record = db.Employees.FirstOrDefault(r => r.Id == id);
            db.Employees.Remove(record);
            db.SaveChanges();
        }

        public void UpdateRegister(Employee record)
        {
            using var context = new ApplicationContext();
            context.Employees.Update(record);
            context.SaveChanges();
        }
    }
}
