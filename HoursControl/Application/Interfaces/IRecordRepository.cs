using HoursControl.Application.Model;

namespace HoursControl.Application.Interfaces
{
    public interface IRecordRepository
    {
        void SerchRegister(Guid id);
        void AddRegister(Record record);
        void UpdateRegister(Record record);
        void RemoveRegister(Record record);
        
    }
}
