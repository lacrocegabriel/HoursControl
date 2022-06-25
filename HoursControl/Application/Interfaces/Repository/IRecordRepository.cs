using HoursControl.Application.Model;

namespace HoursControl.Application.Interfaces.Repository
{
    public interface IRecordRepository
    {
        Record SerchRegister(Guid id);
        Record SerchForCode(int code);
        void AddRegister(Record record);
        void UpdateRegister(Record record);
        void RemoveRegister(Guid id);

    }
}
