using HoursControl.Application.Model;

namespace HoursControl.Application.Interfaces
{
    public interface IRecordService
    {
        void SerchRegister(Guid id);
        void AddRegister(Record record);
        void RemoveRegister(Record record);
        void UpdateRegister(Record record);
    }
}
