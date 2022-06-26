using HoursControl.Application.Model;

namespace HoursControl.Application.Interfaces.Service
{
    public interface IRecordService
    {
        Record SearchRegister(Guid id);
        Record SearchForCode(int code);
        void AddRegister(Record record);
        void RemoveRegister(Guid id);
        void UpdateRegister(Record record);
    }
}
