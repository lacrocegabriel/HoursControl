using HoursControl.Application.Model;

namespace HoursControl.Application.Interfaces.Service
{
    public interface IRecordService
    {
        Record SerchRegister(Guid id);
        Record SerchForCode(int code);
        void AddRegister(Record record);
        void RemoveRegister(Guid id);
        void UpdateRegister(Record record);
    }
}
