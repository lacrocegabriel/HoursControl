using HoursControl.Application.Model;

namespace HoursControl.Application.Interfaces.Repository
{
    public interface IRecordRepository
    {
        Record SearchRegister(Guid id);
        Record SearchForCode(int code);
        Record SearchForEmployee(Guid id);
        void AddRegister(Record record);
        void UpdateRegister(Record record);
        void RemoveRegister(Guid id);

    }
}
